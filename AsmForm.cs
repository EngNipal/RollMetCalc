using System;
using System.Windows.Forms;

namespace RollMetCalc
{
    public partial class AsmForm : Form
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public AsmForm()
        {
            InitializeComponent();
            tbAsmName.TextChanged += Service.SmthChanged;
            tbAsmCount.TextChanged += Service.SmthChanged;
            tbAsmID.TextChanged += Service.SmthChanged;
        }
        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsmForm_Load(object sender, EventArgs e)
        {
            // Создаём таблицу, отображающую детали в сборке, со следующими заголовками
            // Наименование, Тип, Материал, Вес, Количество.
            #region Datagrid
            DataGridViewColumn Column1 = new DataGridViewColumn
            {
                HeaderText = "Наименование",
                Name = "Name",
                Frozen = true,
                CellTemplate = new DataGridViewTextBoxCell()
            };
            DataGridViewColumn Column2 = new DataGridViewColumn
            {
                HeaderText = "Тип",
                Name = "FlatType",
                CellTemplate = new DataGridViewTextBoxCell()
            };
            DataGridViewColumn Column3 = new DataGridViewColumn
            {
                HeaderText = "Материал",
                Name = "Material",
                CellTemplate = new DataGridViewTextBoxCell()
            };
            DataGridViewColumn Column4 = new DataGridViewColumn
            {
                HeaderText = "Вес, кг",
                Name = "Weight",
                CellTemplate = new DataGridViewTextBoxCell()
            };
            DataGridViewColumn Column5 = new DataGridViewColumn
            {
                HeaderText = "Количество",
                Name = "Count",
                CellTemplate = new DataGridViewTextBoxCell()
            };
            _ = dgvPartList.Columns.Add(Column1);
            _ = dgvPartList.Columns.Add(Column2);
            _ = dgvPartList.Columns.Add(Column3);
            _ = dgvPartList.Columns.Add(Column4);
            _ = dgvPartList.Columns.Add(Column5);

            dgvPartList.AllowUserToAddRows = false;
            dgvPartList.AllowUserToDeleteRows = false;
            dgvPartList.ReadOnly = true;
            #endregion
        }
        /// <summary>
        /// Изменение ID в текстовом поле => меняется заголовок формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbAsmID_TextChanged(object sender, EventArgs e)
        {
            Text = $"Сборка {tbAsmID.Text}";
            btCheckID.Enabled = true;
            btSaveAsm.Enabled = false;
        }
        /// <summary>
        /// Клик по кнопке проверки ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCheckID_Click(object sender, EventArgs e)
        {
            btCheckID.Enabled = false;
            if (Service.AsmID_IsUnic(tbAsmID.Text))              // Если нет такого ID - выдаём сообщение об уникальности.
            {
                _ = MessageBox.Show(
                    "Это новый ID!",
                    "Проверено",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btSaveAsm.Enabled = true;
                tbAsmID.Enabled = false;
            }
            else                                                // Если есть - предлагаем выбрать другой.
            {
                _ = MessageBox.Show(
                    "Сборка с таким ID уже есть в базе!. Выберите другой ID.",
                    "Внимание!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                btSaveAsm.Enabled = false;
            }
        }
        /// <summary>
        /// Клик по кнопке добавления детали.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPartBtn_Click(object sender, EventArgs e)
        {
            PartForm partForm = new PartForm
            {
                Owner = this,
                Text = "Деталь"
            };
            partForm.FormClosed += ChildFormClosed;
            Hide();
            _ = partForm.ShowDialog();
        }
        /// <summary>
        /// Закрытие дочерней формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildFormClosed(object sender, EventArgs e)
        {
            (sender as PartForm).Dispose();
            Assembly myAsm = Service.CurrAssembly;
            dgvPartList.Rows.Clear();
            foreach (Part part in myAsm.PartList)
            {
                _ = dgvPartList.Rows.Add(part.Name, part.FlatType, part.Material, part.Mass, part.Count);
            }
            Show();
        }
        /// <summary>
        /// Клик по кнопке сохранения сборки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = tbAsmID.Text;
                string name = tbAsmName.Text;
                uint count = uint.Parse(tbAsmCount.Text);
                Service.SaveAsm(id, name, count);
                btAddPart.Enabled = true;
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Закрытие формы сборки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Service.ThereWereChanges)
            {
                DialogResult result = MessageBox.Show(
                    "У вас есть несохранённые изменения в сборке! Желаете сохранить изменённые данные? " +
                    "ДА - сохранить и закрыть, " +
                    "НЕТ - закрыть без сохранения, " +
                    "ОТМЕНА - корректировать данные.",
                    "Внимание!",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveAsmBtn_Click(this, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}