using System;
using System.Windows.Forms;

namespace RollMetCalc
{
    public partial class PartForm : Form
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public PartForm()
        {
            InitializeComponent();
            tbLength.Text = "0";
            tbWidth.Text = "0";
            tbThickness.Text = "0";
            tbShortShelf.Text = "0";
            #region Подписки метода SmthChanged
            tbPartName.TextChanged += Service.SmthChanged;
            cbFlatType.SelectionChangeCommitted += Service.SmthChanged;
            tbPartMass.TextChanged += Service.SmthChanged;
            tbDensity.TextChanged += Service.SmthChanged;
            tbLength.TextChanged += Service.SmthChanged;
            tbWidth.TextChanged += Service.SmthChanged;
            tbThickness.TextChanged += Service.SmthChanged;
            tbShortShelf.TextChanged += Service.SmthChanged;
            cbPartMaterial.SelectionChangeCommitted += Service.SmthChanged;
            tbPartCount.TextChanged += Service.SmthChanged;
            tbPartID.TextChanged += Service.SmthChanged;
            #endregion
        }
        /// <summary>
        /// Изменение ID в текстовом поле => меняется заголовок формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbPartID_TextChanged(object sender, EventArgs e)
        {
            Text = $"Деталь {tbPartID.Text}";
            btCheckID.Enabled = true;
            btSavePart.Enabled = false;
        }
        /// <summary>
        /// Клик по кнопке проверки ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCheckID_Click(object sender, EventArgs e)
        {
            btCheckID.Enabled = false;
            if (Service.PartID_IsUnic(tbPartID.Text))               // Если нет такого ID - выдаём сообщение об уникальности.
            {
                _ = MessageBox.Show(
                    "Это новый ID!",
                    "Проверено",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btSavePart.Enabled = true;
                tbPartID.Enabled = false;
            }
            else
            {
                _ = MessageBox.Show(
                    "Деталь с таким ID уже есть в базе!. Выберите другой ID.",
                    "Внимание!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                btSavePart.Enabled = false;
            }
        }
        /// <summary>
        /// Клик по кнопке проверки данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCheckData_Click(object sender, EventArgs e)
        {
            try
            {
                float length = float.Parse(tbLength.Text);
                float width = float.Parse(tbWidth.Text);
                float thickness = float.Parse(tbThickness.Text);
                float shortShelf = float.Parse(tbShortShelf.Text);
                float mass = float.Parse(tbPartMass.Text);
                float density = float.Parse(tbDensity.Text);
                double Ratio = Service.CheckPartData(
                    cbFlatType.SelectedIndex,
                    cbPartMaterial.SelectedIndex,
                    length, width, thickness, shortShelf, mass, density,
                    out double DensRatio);
                Ratio = Math.Round((Ratio - 1) * 100, 2);                   // Перевести в проценты и округлить до 2 знака.
                DensRatio = Math.Round((DensRatio - 1) * 100, 2);
                if (shortShelf > width)
                {
                    string temp = tbWidth.Text;
                    tbWidth.Text = tbShortShelf.Text;
                    tbShortShelf.Text = temp;
                    _ = MessageBox.Show(
                        "Короткая полка оказалась больше длинной. Мы поменяли их значения местами.",
                        "Внимание!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                if (width > length)
                {
                    string temp = tbLength.Text;
                    tbLength.Text = tbWidth.Text;
                    tbWidth.Text = temp;
                    _ = MessageBox.Show(
                        "Ширина оказалась больше длины. Мы поменяли их значения местами.",
                        "Внимание!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                if (cbFlatType.SelectedIndex == 1 || cbFlatType.SelectedIndex == 2)
                {
                    if (Ratio >= -3 && Ratio <= 3)                        // Всё хорошо.
                    {
                        _ = MessageBox.Show(
                            "Все параметры в пределах нормы",
                            "Результат",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else                                                    // Всё плохо.
                    {
                        _ = MessageBox.Show(
                                $"Проверьте массу! Отличие расчёта от указанного значения {Ratio} %",
                                "Результат",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (!(DensRatio >= -3 && DensRatio <= 3))          // Плохая плотность
                    {
                        _ = MessageBox.Show(
                            $"Проверьте линейную плотность! Отличие расчёта от указанного значения {DensRatio} %",
                            "Результат",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else if (!(Ratio >= -3 && Ratio <= 3 ))             // Хорошая плотность, но плохая масса.
                    {
                        _ = MessageBox.Show(
                            $"Проверьте массу! Отличие расчёта от указанного значения {Ratio} %. При этом плотность выглядит верной.",
                            "Результат",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else                                                    // Всё хорошо.
                    {
                        _ = MessageBox.Show(
                            "Все параметры в пределах нормы",
                            "Результат",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Клик по кнопке сохранения детали.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePartBtn_Click(object sender, EventArgs e)
        {
            try             // Проверка введённых данных.
            {
                string id = tbPartID.Text;
                string name = tbPartName.Text;
                string material = cbPartMaterial.Text;
                float mass = float.Parse(tbPartMass.Text);
                float density = float.Parse(tbDensity.Text);
                float length = float.Parse(tbLength.Text);
                float width = float.Parse(tbWidth.Text);
                float thickness = float.Parse(tbThickness.Text);
                float shortShelf = float.Parse(tbShortShelf.Text);
                uint count = uint.Parse(tbPartCount.Text);
                int matType = cbFlatType.SelectedIndex;
                Service.SavePart(id, name, material, mass, density, length, width, thickness, shortShelf, count, matType);
                cbFlatType.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }
        /// <summary>
        /// Изменение вида проката.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlatTypeBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbFlatType.SelectedIndex)
            {
                case 0:         // "Арматура"
                    lbWidth.Text = "Диаметр";
                    lbDensity.Text = "Пог.плотн., кг/м";
                    lbShortShelf.Hide();
                    tbShortShelf.Hide();
                    lbThickness.Hide();
                    tbThickness.Hide();
                    break;
                case 3:         // "Труба"
                    lbWidth.Text = "Диаметр";
                    lbDensity.Text = "Пог.плотн., кг/м";
                    lbShortShelf.Hide();
                    tbShortShelf.Hide();
                    lbThickness.Show();
                    tbThickness.Show();
                    break;
                case 4:         // "Уголок"
                    lbWidth.Text = "Дл.полка";
                    lbDensity.Text = "Пог.плотн., кг/м";
                    lbShortShelf.Show();
                    tbShortShelf.Show();
                    lbThickness.Show();
                    tbThickness.Show();
                    break;
                default:        // "Лист и полоса"
                    lbWidth.Text = "Ширина";
                    lbDensity.Text = "Плотность, г/см3";
                    lbShortShelf.Hide();
                    tbShortShelf.Hide();
                    lbThickness.Show();
                    tbThickness.Show();
                    break;
            }
        }
        /// <summary>
        /// Изменение вида материала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbPartMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lbDensVal.Text = cbPartMaterial.SelectedIndex == 0 ?  "2,7" : "7,8";
        }
        /// <summary>
        /// Проверка при закрытии формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Service.ThereWereChanges)
            {
                DialogResult result = MessageBox.Show(
                    "У вас есть несохранённые изменения в детали! Желаете сохранить изменённые данные? " + "\n" +
                    "ДА - сохранить и закрыть, " + "\n" +
                    "НЕТ - закрыть без сохранения, " + "\n" +
                    "ОТМЕНА - корректировать данные.",
                    "Внимание!",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SavePartBtn_Click(this, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
