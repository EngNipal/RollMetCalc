using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Math;
using static RollMetCalc.Service;
using Excel = Microsoft.Office.Interop.Excel;

namespace RollMetCalc
{
    public static class Result
    {
        internal static bool IsCalculated;
        // Списки деталей из определённого материала.
        private static List<Part> AlumParts = new List<Part>();
        private static List<Part> LegirParts = new List<Part>();
        private static List<Part> SteelParts = new List<Part>();

        // Данные о прокате из определённого материала.
        private static Roll AlRoll = new Roll(128);
        private static Roll LegRoll = new Roll(128);
        private static Roll SteelRoll = new Roll(128);

        private static readonly (int Width, int Length)[] SheetTypes = { (1000, 2000), (1500, 6000) };          // Типоразмеры листов.
        private static readonly int[] LenTypes = { 1000, 2000, 3000, 4000, 5000, 6000, 11700 };                 // Типоразмеры не_листов.
        /// <summary>
        /// Сортировка заказа по типу проката.
        /// </summary>
        public static void SortOrderByType()
        {
            foreach (Assembly asm in CurrOrder.AsmList)
            {
                foreach (Part part in asm.PartList)
                {
                    if (part.Material == "Алюминий")
                    {
                        AlumParts.Add(part);
                    }
                    else if (part.Material == "Нержавейка")
                    {
                        LegirParts.Add(part);
                    }
                    else
                    {
                        SteelParts.Add(part);
                    }
                }
            }
            AlumParts.Sort();
            LegirParts.Sort();
            SteelParts.Sort();
        }
        /// <summary>
        /// Заполнение всех списков проката.
        /// </summary>
        private static void FillAllRolls()
        {
            if (AlumParts.Count != 0)
            {
                FillRoll(AlumParts, AlRoll);
            }

            if (LegirParts.Count != 0)
            {
                FillRoll(LegirParts, LegRoll);
            }

            if (SteelParts.Count != 0)
            {
                FillRoll(SteelParts, SteelRoll);
            }
        }
        /// <summary>
        /// Заполнение конкретного списка.
        /// </summary>
        /// <param name="parts"></param>
        /// <param name="roll"></param>
        private static void FillRoll(List<Part> parts, Roll roll)
        {
            roll.AddNewPartType(parts[0]);
            int k = 0;
            for (int i = 1; i < parts.Count(); i++)
            {
                Part previous = parts[i - 1];
                Part current = parts[i];
                if (current != previous)                // Новый тип детали
                {
                    roll.AddNewPartType(current);
                    k++;
                }
                else                                    // Такой же тип детали.
                {
                    roll.Update_kType(k, current);
                }
            }
        }
        /// <summary>
        /// Анализатор списка проката.
        /// </summary>
        /// <param name="roll"></param>
        private static void Analyze(Roll roll)
        {
            int k = 0;
            foreach (Part part in roll.PartTypes)       // Перебираем все типы деталей.
            {
                int n;
                if (part is Sheet sheet)                // Если деталь листовая.
                {
                    for (int i = 0; i < LenTypes.Length; i++)           // Для всех полей стандартных длин этого типа деталей пишем (-1, -1)
                    {
                        roll.StdLen[k].Add((-1, -1));
                    }
                    foreach ((int, int) stdSheet in SheetTypes)         // Затем для всех стандартных листов из списка...
                    {
                        if (sheet.Width > stdSheet.Item2)               // Если ширина детали (меньший размер) больше, чем длина листа (бОльший размер)
                        {
                            roll.StdSheet[k].Add((-1, -1));             // То она не влезет.
                        }
                        else                                            // Иначе считаем необходимое кол-во стандартных листов.
                        {
                            n = NumOfSHeets(sheet, roll.Counts[k], stdSheet, out double percent);
                            roll.StdSheet[k].Add((n, percent));
                        }
                    }
                }
                else                                    // Если деталь "мерной длины".
                {
                    for (int i = 0; i < SheetTypes.Length; i++)         // Для всех полей стандартных листов этого типа деталей пишем (-1, -1)
                    {
                        roll.StdSheet[k].Add((-1, -1));
                    }
                    foreach (int stdLength in LenTypes)                 // Затем для всех стандартных длин из списка...
                    {
                        if (part.Length > stdLength)                    // Если деталь длиннее стандартной меры
                        {
                            roll.StdLen[k].Add((-1, -1));               // То она не влезет.
                        }
                        else                                            // Иначе считаем необходимое кол-во стандартных длин.
                        {
                            n = NumOfLengthes(stdLength, part, roll.Counts[k], roll.Lengthes[k], out double percent);
                            roll.StdLen[k].Add((n, percent));
                        }
                    }
                }
                k++;
            }
        }
        /// <summary>
        /// Располагаем детали на листе.
        /// </summary>
        /// <param name="sheet"> Деталь, которую нужно расположить </param>
        /// <param name="numofparts"> Количество этих деталей </param>
        /// <param name="small"> Малый размер листа </param>
        /// <param name="big"> Большой размер листа </param>
        /// <param name="percent"></param>
        /// <returns></returns>
        private static int NumOfSHeets(Sheet sheet, uint numofparts, (int, int) stdSheet, out double percent)
        {
            int Along;
            int Across;
            int n;
            // Случай первый - располагаем длинную вдоль длинной, короткую вдоль короткой. - Метод "Вдоль".
            int divSmall = (int)Truncate(stdSheet.Item1 / sheet.Width);
            int divBig = DivRem(stdSheet.Item2, (int)sheet.Length, out int residueWidth);
            Along = divBig * divSmall;
            if (residueWidth > sheet.Width && stdSheet.Item1 > sheet.Length)        // Если на остатке можно разместить листы поперёк - считаем сколько.
            {
                divSmall = (int)Truncate(residueWidth / sheet.Width);
                divBig = (int)Truncate(stdSheet.Item1 / sheet.Length);
                Along += divBig * divSmall;
            }
            // Случай второй - располагаем длинную вдоль короткой, короткую вдоль длинной. - Метод "Поперёк".
            divSmall = DivRem(stdSheet.Item1, (int)sheet.Length, out residueWidth);
            divBig = (int)Truncate(stdSheet.Item2 / sheet.Width);
            Across = divBig * divSmall;
            if (residueWidth > sheet.Width)                                         // Если на остатке можно разместить листы вдоль - считаем сколько.
            {
                divSmall = (int)Truncate(residueWidth / sheet.Width);
                divBig = (int)Truncate(stdSheet.Item2 / sheet.Length);
                Across += divBig * divSmall;
            }
            Along = (Along > Across) ? Along : Across;                                      // Столько максимум помещается на одном листе stdSheet.
            n = Along != 0 ? (int)Ceiling((decimal)(numofparts / Along)) : -1;              // Столько листов потребуется.
            percent = (n * stdSheet.Item1 * stdSheet.Item2) / (sheet.Length * sheet.Width * numofparts);
            percent = (percent - 1) * 100;                                                  // Процент отходов.
            return n;
        }
        /// <summary>
        /// Вычисляется необходимое количество стандартных длин
        /// </summary>
        /// <param name="stdL">стандартная длина</param>
        /// <param name="part">деталь</param>
        /// <param name="numofparts">необходимое количество деталей</param>
        /// <param name="length"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        private static int NumOfLengthes(int stdL, Part part, uint numofparts, float length, out double percent)
        {
            int n;
            n = Convert.ToInt32(Truncate(stdL / part.Length));              // Столько деталей из stdL-метровой штуки.
            n = Convert.ToInt32(numofparts / n);                            // Сколько стандартных штук понадобится.
            percent = (n * stdL * 100 / length) - 100;                      // Процент отходов (уже в процентах).
            return n;
        }
        /// <summary>
        /// Выгрузка данных в Excel-файл.
        /// </summary>
        internal static void OutputToExcel(string pathName)
        {
            string invalidString = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string orderName = Regex.Replace(CurrOrder.Name, "[" + invalidString + "]", "");
            string filename = pathName + "\\" + orderName + "_результат" + ".xlsx";
            Excel.Application xlApp = new Excel.Application();
            xlApp.Visible = false;
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
            xlWorkBook.SaveAs(filename);
            Excel.Worksheet AlumSheet = xlWorkBook.Sheets[1];
            Excel.Worksheet LegirSheet = (Excel.Worksheet) xlWorkBook.Sheets.Add(Type.Missing, xlWorkBook.Sheets[1]);
            Excel.Worksheet SteelSheet = (Excel.Worksheet)xlWorkBook.Sheets.Add(Type.Missing, xlWorkBook.Sheets[2]);
            AlumSheet.Name = "Алюминий";
            LegirSheet.Name = "Нержавейка";
            SteelSheet.Name = "Сталь";
            foreach (Excel.Worksheet xlSheet in xlWorkBook.Sheets)
            {
                // Заполняем заголовки.
                for (int i = 2; i < 8; i++)
                {
                    Excel.Range range = xlSheet.Range[xlSheet.Cells[1, i], xlSheet.Cells[2, i]];
                    range.Merge(Type.Missing);
                }
                xlSheet.Cells[1, 2] = "Тип проката";
                xlSheet.Cells[1, 3] = "Длина";
                xlSheet.Cells[1, 4] = "Ширина/диаметр";
                xlSheet.Cells[1, 5] = "Масса 1 шт.";
                xlSheet.Cells[1, 6] = "Количество";
                xlSheet.Cells[1, 7] = "Масса всего";
                int k = 8; // Номер столбца под запись заголовка.
                foreach ((int Width, int Length) in SheetTypes)
                {
                    Excel.Range range = xlSheet.Range[xlSheet.Cells[1, k], xlSheet.Cells[1, k + 1]];
                    range.Merge(Type.Missing);
                    xlSheet.Cells[1, k] = $"{Width} x {Length}";
                    xlSheet.Cells[1, k].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlSheet.Cells[2, k] = "Кол-во";
                    xlSheet.Cells[2, k + 1] = "% отходов";
                    k += 2;
                }
                foreach (int elem in LenTypes)
                {
                    Excel.Range range = xlSheet.Range[xlSheet.Cells[1, k], xlSheet.Cells[1, k + 1]];
                    range.Merge(Type.Missing);
                    xlSheet.Cells[1, k] = elem;
                    xlSheet.Cells[1, k].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlSheet.Cells[2, k] = "Кол-во";
                    xlSheet.Cells[2, k + 1] = "% отходов";
                    k += 2;
                }
                // Заполняем данными.
                if (xlSheet.Name == "Алюминий")
                {
                    FillSheetByData(xlSheet, AlRoll);
                }
                else if (xlSheet.Name == "Нержавейка")
                {
                    FillSheetByData(xlSheet, LegRoll);
                }
                else
                {
                    FillSheetByData(xlSheet, SteelRoll);
                }
            }
            xlWorkBook.Save();
            xlApp.Visible = true;
            //xlWorkBook.Close();
        }
        /// <summary>
        /// Заполнение листа worksheet данными из roll.
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="roll"></param>
        private static void FillSheetByData(Excel.Worksheet worksheet, Roll roll)
        {
            int RowNum = 3;
            int index = 0;
            foreach (Part part in roll.PartTypes)
            {
                worksheet.Cells[RowNum, 2] = part.FlatType;
                worksheet.Cells[RowNum, 3] = part.Length;
                if (part is Sheet sheet)
                {
                    worksheet.Cells[RowNum, 4] = sheet.Width;
                }
                else if (part is Armature armature)
                {
                    worksheet.Cells[RowNum, 4] = armature.Diameter;
                }
                else if (part is Pipe pipe)
                {
                    worksheet.Cells[RowNum, 4] = pipe.Diameter;
                }
                else
                {
                    worksheet.Cells[RowNum, 4] = ((Corner)part).LongShelf;
                }
                worksheet.Cells[RowNum, 5] = part.Mass;
                worksheet.Cells[RowNum, 6] = roll.Counts[index];
                worksheet.Cells[RowNum, 7] = roll.Masses[index];
                int k = 8;
                for (int i = 0; i < SheetTypes.Length; i++)
                {
                    worksheet.Cells[RowNum, k] = roll.StdSheet[index][i].Count;
                    worksheet.Cells[RowNum, k + 1] = roll.StdSheet[index][i].Percent;
                    k += 2;
                }
                for (int i = 0; i < LenTypes.Length; i++)
                {
                    worksheet.Cells[RowNum, k] = roll.StdLen[index][i].Count;
                    worksheet.Cells[RowNum, k + 1] = roll.StdLen[index][i].Percent;
                    k += 2;
                }
                RowNum++;
                index++;
            }
        }
        /// <summary>
        /// Основной метод расчёта.
        /// </summary>
        public static void Calculate()
        {
            SortOrderByType();
            FillAllRolls();
            Analyze(AlRoll);
            Analyze(LegRoll);
            Analyze(SteelRoll);
            IsCalculated = true;
        }
    }
}
