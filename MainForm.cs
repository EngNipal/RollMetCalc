using System;
using System.Windows.Forms;

namespace RollMetCalc
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Клик по кнопке "Новый заказ".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtNewOrder_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm
            {
                Owner = this,
                Text = "Заказ",
            };
            orderForm.FormClosed += ChildFormClosed;
            Hide();
            _ = orderForm.ShowDialog();
        }
        /// <summary>
        /// Закрытие дочерней формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildFormClosed(object sender, EventArgs e)
        {
            (sender as OrderForm).Dispose();
            Show();
        }
        /// <summary>
        /// Клик по кнопке "Расчёт".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCalculation_Click(object sender, EventArgs e)
        {
            if (!Result.IsCalculated)
            {
                Result.Calculate();
            }
            FolderBrowserDialog path = new FolderBrowserDialog();
            DialogResult result = path.ShowDialog();
            if (result == DialogResult.OK)
            {
                Result.OutputToExcel(path.SelectedPath);
            }
        }
        /// <summary>
        /// Клик по кнопке "Загрузить заказ"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtLoadOrder_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            DialogResult result = open.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = open.FileName;
                Service.GetDataFromExcel(filename);
            }
        }
    }
}
