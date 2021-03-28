using System;
using System.Windows.Forms;

namespace RollMetCalc
{
    public partial class OrderForm : Form
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public OrderForm()
        {
            InitializeComponent();
            tbOrderName.TextChanged += Service.SmthChanged;
            tbCustomer.TextChanged += Service.SmthChanged;
            tbOrderID.TextChanged += Service.SmthChanged;
        }
        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderForm_Load(object sender, EventArgs e)         // TODO: Переработать поля отображения данных (2021-02-27).
        {
            // Создаём таблицу, отображающую сборки в заказе, со следующими колонками:
            // Название, Количество.
            #region Datagrid
            DataGridViewColumn Column1 = new DataGridViewColumn
            {
                HeaderText = "Название",                // текст в шапке.
                                                        // Column1.Width = 100; // ширина колонки.
                ReadOnly = true,                        // значение в этой колонке нельзя править.
                Name = "Name",                          // текстовое имя колонки, его можно использовать вместо обращений по индексу.
                Frozen = true,                          // флаг, что данная колонка всегда отображается на своем месте.
                CellTemplate = new DataGridViewTextBoxCell() // тип колонки
            };
            DataGridViewColumn Column2 = new DataGridViewColumn
            {
                ReadOnly = true,
                HeaderText = "Количество",
                Name = "Count",
                CellTemplate = new DataGridViewTextBoxCell()
            };
            _ = dgvAsmList.Columns.Add(Column1);
            _ = dgvAsmList.Columns.Add(Column2);

            dgvAsmList.AllowUserToAddRows = false;      // Запрещаем пользователю самому добавлять строки.
            dgvAsmList.AllowUserToDeleteRows = false;
            dgvAsmList.ReadOnly = true;
            #endregion
        }
        /// <summary>
        /// Изменение ID в текстовом поле => меняется заголовок формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbOrderID_TextChanged(object sender, EventArgs e)
        {
            Text = $"Заказ {tbOrderID.Text}";
            btCheckID.Enabled = true;
            btSaveOrder.Enabled = false;
        }
        /// <summary>
        /// Клик по кнопке проверки ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCheckID_Click(object sender, EventArgs e)
        {
            btCheckID.Enabled = false;
            if (Service.OrderID_IsUnic(tbOrderID.Text))          // Если нет такого ID - выдаём сообщение об уникальности.
            {
                _ = MessageBox.Show(
                    "Это новый ID!",
                    "Проверено",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btSaveOrder.Enabled = true;
                tbOrderID.Enabled = false;
            }
            else
            {
                _ = MessageBox.Show(
                    $"Заказ с таким ID уже есть в базе! Выберите другой ID.",
                    "Внимание!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                btSaveOrder.Enabled = false;
            }
        }
        /// <summary>
        /// Клик по кнопке добавления сборки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtAddAsm_Click(object sender, EventArgs e)
        {
            AsmForm asmForm = new AsmForm
            {
                Owner = this,
                Text = "Сборка"
            };
            asmForm.FormClosed += ChildFormClosed;
            Hide();
            _ = asmForm.ShowDialog();
        }
        /// <summary>
        /// Закрытие дочерней формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildFormClosed(object sender, FormClosedEventArgs e)
        {
            (sender as AsmForm).Dispose();
            Order myOrder = Service.CurrOrder;
            dgvAsmList.Rows.Clear();
            foreach (Assembly asm in myOrder.AsmList)
            {
                _ = dgvAsmList.Rows.Add(asm.Name, asm.Count);
            }
            Show();
        }
        /// <summary>
        /// Клик по кнопке сохранения заказа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string id = tbOrderID.Text;
                string name = tbOrderName.Text;
                string customer = tbCustomer.Text;
                Service.SaveOrder(id, name, customer);
                btAddAsm.Enabled = true;
            }
            catch (Exception ex)                        // TODO: доработать исключение (2021-03-06)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Закрытие формы заказа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Service.ThereWereChanges)
            {
                DialogResult result = MessageBox.Show(
                    "У вас есть несохранённые изменения в заказе! Желаете сохранить изменённые данные? " +
                    "ДА - сохранить и закрыть, " +
                    "НЕТ - закрыть без сохранения, " +
                    "ОТМЕНА - корректировать данные.",
                    "Внимание!",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    BtSaveOrder_Click(this, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
