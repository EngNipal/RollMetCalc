
namespace RollMetCalc
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btNewOrder = new System.Windows.Forms.Button();
            this.btCalculation = new System.Windows.Forms.Button();
            this.btLoadOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btNewOrder
            // 
            this.btNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btNewOrder.Location = new System.Drawing.Point(12, 36);
            this.btNewOrder.Name = "btNewOrder";
            this.btNewOrder.Size = new System.Drawing.Size(138, 52);
            this.btNewOrder.TabIndex = 0;
            this.btNewOrder.Text = "Новый заказ";
            this.btNewOrder.UseVisualStyleBackColor = true;
            this.btNewOrder.Click += new System.EventHandler(this.BtNewOrder_Click);
            // 
            // btCalculation
            // 
            this.btCalculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCalculation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCalculation.Location = new System.Drawing.Point(100, 132);
            this.btCalculation.Name = "btCalculation";
            this.btCalculation.Size = new System.Drawing.Size(138, 49);
            this.btCalculation.TabIndex = 2;
            this.btCalculation.Text = "Расчёт";
            this.btCalculation.UseVisualStyleBackColor = true;
            this.btCalculation.Click += new System.EventHandler(this.BtCalculation_Click);
            // 
            // btLoadOrder
            // 
            this.btLoadOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btLoadOrder.Location = new System.Drawing.Point(179, 36);
            this.btLoadOrder.Name = "btLoadOrder";
            this.btLoadOrder.Size = new System.Drawing.Size(136, 51);
            this.btLoadOrder.TabIndex = 1;
            this.btLoadOrder.Text = "Загрузить заказ";
            this.btLoadOrder.UseVisualStyleBackColor = true;
            this.btLoadOrder.Click += new System.EventHandler(this.BtLoadOrder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 216);
            this.Controls.Add(this.btLoadOrder);
            this.Controls.Add(this.btCalculation);
            this.Controls.Add(this.btNewOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RollMetCalc";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btNewOrder;
        private System.Windows.Forms.Button btCalculation;
        private System.Windows.Forms.Button btLoadOrder;
    }
}

