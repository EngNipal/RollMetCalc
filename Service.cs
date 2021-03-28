using System;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Math;

namespace RollMetCalc
{
    public static class Service
    {
        public static Order CurrOrder { get; private set; }
        public static Assembly CurrAssembly { get; private set; }
        public static Part CurrPart { get; private set; }
        public static bool ThereWereChanges { get; set; }
        #region Всё о заказе
        /// <summary>
        /// Проверка уникальности ID заказа.
        /// </summary>
        /// <param name="id"></param>
        internal static bool OrderID_IsUnic(string id)
        {
            int hash = id.GetHashCode();
            return !Order.Base.ContainsKey(hash);
        }
        /// <summary>
        /// Сохранение заказа.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="customer"></param>
        internal static void SaveOrder(string id, string name, string customer)
        {
            int hash = id.GetHashCode();
            if (!Order.Base.TryGetValue(hash, out Order order))                     // Если такого заказа нет
            {
                order = new Order(id, name, customer);                              // Создаём новый
                Order.Base.Add(hash, order);
            }
            else                                                                    // Иначе обновляем существующий.
            {
                order.Name = name;
                order.Customer = customer;
                // TODO: Придумать как добавлять (обновлять и т.п.) сборки, отображённые в окне заказа. (2021-02-27)
            }
            CurrOrder = order;
            ThereWereChanges = false;
        }
        #endregion
        #region Всё о сборке
        /// <summary>
        /// Проверка уникальности ID сборки.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static bool AsmID_IsUnic(string id)
        {
            int hash = id.GetHashCode();
            return !Assembly.Base.ContainsKey(hash);
        }
        /// <summary>
        /// Сохранение сборки.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="count"></param>
        internal static void SaveAsm(string id, string name, uint count)
        {
            int hash = id.GetHashCode();
            if (!Assembly.Base.TryGetValue(hash, out Assembly assembly)) // Если такой сборки ещё не было - создаём!
            {
                assembly = new Assembly(id, name, count, CurrOrder);
                Assembly.Base.Add(hash, assembly);
                CurrOrder.AsmList.Add(assembly);                        // Добавляем к списку текущего заказа.
            }
            else                                                        // Если была - обновляем.
            {
                assembly.Name = name;
                assembly.Count = count;
                // TODO: Придумать как добавлять (обновлять и т.п.) детали, отображённые в окне сборки. (2021-02-27)
            }
            CurrAssembly = assembly;
            ThereWereChanges = false;
        }
        #endregion
        #region Всё о детали
        /// <summary>
        /// Проверка уникальности ID детали.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static bool PartID_IsUnic(string id)
        {
            int hash = id.GetHashCode();
            return !Part.Base.ContainsKey(hash);
        }
        /// <summary>
        /// Проверка введённых данных для детали.
        /// </summary>
        /// <param name="flatType"></param>
        /// <param name="matType"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="thickness"></param>
        /// <param name="shortShelf"></param>
        /// <param name="mass"></param>
        /// <param name="density"></param>
        /// <param name="densratio"></param>
        /// <returns></returns>
        internal static double CheckPartData(int flatType, int matType, float length, float width, float thickness, float shortShelf, float mass, float density, out double densratio)
        {
            double Dens = (matType == 0) ? 2.7 : 7.8; // Плотность в г/см^3.
            double Vol;         // Объем, мм^3.
            double LinDens;
            switch (flatType)
            {
                case 0:         // Арматура.
                    Vol = PI * width * width * length / 4;
                    break;
                case 3:         // Труба.
                    Vol = PI * thickness * (2 * width - thickness) * length / 4;
                    break;
                case 4:         // Уголок.
                    Vol = (width + shortShelf - thickness) * thickness * length;
                    break;
                default:        // Лист и полоса.
                    Vol = width * thickness * length;
                    break;
            }
            Vol /= 1000;                        // Перевели в см^3.
            double Mas = Vol * Dens / 1000;     // Масса в кг.
            double ratio = (Mas - mass) / mass;
            LinDens = Mas / length;
            densratio = (LinDens - density) / density;
            return ratio;
        }
        /// <summary>
        /// Сохранение детали.
        /// </summary>
        /// <param name="id"> Уникальный идентификатор </param>
        /// <param name="name"> Наименование детали </param>
        /// <param name="material"> Материал детали </param>
        /// <param name="mass"> Масса детали </param>
        /// <param name="density"> Плотность материала </param>
        /// <param name="length"> Длина детали </param>
        /// <param name="width"> Ширина детали </param>
        /// <param name="thickness"> Толщина металла </param>
        /// <param name="shortShelf"> Длина короткой полки для уголка </param>
        /// <param name="count"> Количество в сборке </param>
        /// <param name="flatType"> Тип материала </param>
        internal static void SavePart(string id, string name, string material, float mass, float density, float length, float width, float thickness, float shortShelf, uint count, int flatType)
        {
            int hash = id.GetHashCode();
            if (!Part.Base.TryGetValue(hash, out Part part))            // Если такой ещё не было - создаём!
            {
                switch (flatType)
                {
                    case 0:         // "Арматура"
                        part = new Armature(id, length, width, density, mass, count, name, material, CurrAssembly);
                        break;
                    case 3:         // "Труба"
                        part = new Pipe(id, length, width, thickness, density, mass, count, name, material, CurrAssembly);
                        break;
                    case 4:         // "Уголок"
                        part = new Corner(id, length, width, shortShelf, thickness, density, mass, count, name, material, CurrAssembly);
                        break;
                    default:        // "Лист и полоса"
                        part = new Sheet(id, length, width, thickness, density, mass, count, name, material, CurrAssembly);
                        break;
                }
                Part.Base.Add(hash, part);
                CurrAssembly.PartList.Add(part);
            }
            else                                                                    // Если был - обновляем!
            {
                part.Name = name;
                part.Length = length;
                part.Material = material;
                part.Mass = mass;
                part.Count = count;
                if (part is Armature armature)
                {
                    armature.Diameter = width;
                    armature.LinearDensity = density;
                }
                else if (part is Pipe pipe)
                {
                    pipe.Diameter = width;
                    pipe.Thickness = thickness;
                    pipe.LinearDensity = density;
                }
                else if (part is Corner corner)
                {
                    corner.LongShelf = width;
                    corner.ShortShelf = thickness;
                    corner.LinearDensity = density;
                }
                else
                {
                    Sheet sheet = part as Sheet;
                    sheet.Width = width;
                    sheet.Thickness = thickness;
                    sheet.Density = density;
                }
            }
            CurrPart = part;
            ThereWereChanges = false;
        }
        #endregion
        public static void SmthChanged(object sender, EventArgs e)
        {
            ThereWereChanges = true;
        }
        /// <summary>
        /// Получение данных из Excel-файла.
        /// </summary>
        /// <param name="filename"></param>
        internal static void GetDataFromExcel(string filename)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filename);
            filename = filename.Substring(filename.LastIndexOf('\\') + 1);
            filename = filename.Substring(0, filename.LastIndexOf('.'));
            Excel.Worksheet xlSheet = xlWorkBook.ActiveSheet;
            SaveOrder(Convert.ToString(xlSheet.Cells[1, 2].Value), filename, Convert.ToString(xlSheet.Cells[2, 2].Value));
            int LastRow = xlSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            for (int i = 4; i <= LastRow; i++)
            {
                int DataType;
                string Data = Convert.ToString(xlSheet.Cells[i, 2].Value);
                switch (Data)
                {
                    case "Сборка":
                        DataType = -1;
                        break;
                    case "Арматура":
                        DataType = 0;
                        break;
                    case "Труба":
                        DataType = 3; 
                        break;
                    case "Уголок":
                        DataType = 4;
                        break;
                    default:
                        DataType = 1;
                        break;
                }
                if (DataType == -1)
                {
                    SaveAsm(Convert.ToString(xlSheet.Cells[i, 1].Value),
                            Convert.ToString(xlSheet.Cells[i, 3].Value),
                            Convert.ToUInt32(xlSheet.Cells[i, 4].Value));
                }
                else
                {
                    SavePart(Convert.ToString(xlSheet.Cells[i, 1].Value),
                             Convert.ToString(xlSheet.Cells[i, 3].Value),
                             Convert.ToString(xlSheet.Cells[i, 11].Value),
                             Convert.ToSingle(xlSheet.Cells[i, 9].Value),
                             Convert.ToSingle(xlSheet.Cells[i, 10].Value),
                             Convert.ToSingle(xlSheet.Cells[i, 5].Value),
                             Convert.ToSingle(xlSheet.Cells[i, 6].Value),
                             Convert.ToSingle(xlSheet.Cells[i, 7].Value),
                             Convert.ToSingle(xlSheet.Cells[i, 8].Value),
                             Convert.ToUInt32(xlSheet.Cells[i, 4].Value),
                             DataType);
                }
            }
        }
    }
}
