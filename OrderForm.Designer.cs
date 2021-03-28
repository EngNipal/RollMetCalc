
namespace RollMetCalc
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btAddAsm = new System.Windows.Forms.Button();
            this.btSaveOrder = new System.Windows.Forms.Button();
            this.dgvAsmList = new System.Windows.Forms.DataGridView();
            this.lbOrderName = new System.Windows.Forms.Label();
            this.tbOrderName = new System.Windows.Forms.TextBox();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.lbOrderID = new System.Windows.Forms.Label();
            this.tbOrderID = new System.Windows.Forms.TextBox();
            this.btCheckID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsmList)).BeginInit();
            this.SuspendLayout();
            // 
            // btAddAsm
            // 
            this.btAddAsm.Enabled = false;
            this.btAddAsm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddAsm.Location = new System.Drawing.Point(16, 259);
            this.btAddAsm.Name = "btAddAsm";
            this.btAddAsm.Size = new System.Drawing.Size(140, 60);
            this.btAddAsm.TabIndex = 4;
            this.btAddAsm.Text = "Добавить сборку";
            this.btAddAsm.UseVisualStyleBackColor = true;
            this.btAddAsm.Click += new System.EventHandler(this.BtAddAsm_Click);
            // 
            // btSaveOrder
            // 
            this.btSaveOrder.Enabled = false;
            this.btSaveOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSaveOrder.Location = new System.Drawing.Point(178, 259);
            this.btSaveOrder.Name = "btSaveOrder";
            this.btSaveOrder.Size = new System.Drawing.Size(140, 60);
            this.btSaveOrder.TabIndex = 5;
            this.btSaveOrder.Text = "Сохранить заказ";
            this.btSaveOrder.UseVisualStyleBackColor = true;
            this.btSaveOrder.Click += new System.EventHandler(this.BtSaveOrder_Click);
            // 
            // dgvAsmList
            // 
            this.dgvAsmList.AllowUserToAddRows = false;
            this.dgvAsmList.AllowUserToDeleteRows = false;
            this.dgvAsmList.AllowUserToResizeColumns = false;
            this.dgvAsmList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsmList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvAsmList.Location = new System.Drawing.Point(16, 97);
            this.dgvAsmList.MultiSelect = false;
            this.dgvAsmList.Name = "dgvAsmList";
            this.dgvAsmList.ReadOnly = true;
            this.dgvAsmList.RowHeadersVisible = false;
            this.dgvAsmList.RowTemplate.ReadOnly = true;
            this.dgvAsmList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsmList.Size = new System.Drawing.Size(300, 156);
            this.dgvAsmList.TabIndex = 9;
            // 
            // lbOrderName
            // 
            this.lbOrderName.AutoSize = true;
            this.lbOrderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOrderName.Location = new System.Drawing.Point(12, 39);
            this.lbOrderName.Name = "lbOrderName";
            this.lbOrderName.Size = new System.Drawing.Size(142, 20);
            this.lbOrderName.TabIndex = 7;
            this.lbOrderName.Text = "Название заказа:";
            // 
            // tbOrderName
            // 
            this.tbOrderName.Location = new System.Drawing.Point(160, 41);
            this.tbOrderName.Name = "tbOrderName";
            this.tbOrderName.Size = new System.Drawing.Size(155, 20);
            this.tbOrderName.TabIndex = 2;
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCustomer.Location = new System.Drawing.Point(12, 69);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(84, 20);
            this.lbCustomer.TabIndex = 8;
            this.lbCustomer.Text = "Заказчик:";
            // 
            // tbCustomer
            // 
            this.tbCustomer.Location = new System.Drawing.Point(160, 71);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.Size = new System.Drawing.Size(155, 20);
            this.tbCustomer.TabIndex = 3;
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOrderID.Location = new System.Drawing.Point(12, 9);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(85, 20);
            this.lbOrderID.TabIndex = 6;
            this.lbOrderID.Text = "ID заказа:";
            // 
            // tbOrderID
            // 
            this.tbOrderID.Location = new System.Drawing.Point(160, 12);
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.Size = new System.Drawing.Size(70, 20);
            this.tbOrderID.TabIndex = 0;
            this.tbOrderID.TextChanged += new System.EventHandler(this.TbOrderID_TextChanged);
            // 
            // btCheckID
            // 
            this.btCheckID.Location = new System.Drawing.Point(236, 12);
            this.btCheckID.Name = "btCheckID";
            this.btCheckID.Size = new System.Drawing.Size(78, 20);
            this.btCheckID.TabIndex = 1;
            this.btCheckID.Text = "Проверить";
            this.btCheckID.UseVisualStyleBackColor = true;
            this.btCheckID.Click += new System.EventHandler(this.BtCheckID_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 332);
            this.Controls.Add(this.btCheckID);
            this.Controls.Add(this.tbOrderID);
            this.Controls.Add(this.lbOrderID);
            this.Controls.Add(this.tbCustomer);
            this.Controls.Add(this.lbCustomer);
            this.Controls.Add(this.tbOrderName);
            this.Controls.Add(this.lbOrderName);
            this.Controls.Add(this.dgvAsmList);
            this.Controls.Add(this.btSaveOrder);
            this.Controls.Add(this.btAddAsm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OrderForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderForm_FormClosing);
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsmList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddAsm;
        private System.Windows.Forms.Button btSaveOrder;
        private System.Windows.Forms.DataGridView dgvAsmList;
        private System.Windows.Forms.Label lbOrderName;
        private System.Windows.Forms.TextBox tbOrderName;
        private System.Windows.Forms.Label lbCustomer;
        private System.Windows.Forms.TextBox tbCustomer;
        private System.Windows.Forms.Label lbOrderID;
        private System.Windows.Forms.TextBox tbOrderID;
        private System.Windows.Forms.Button btCheckID;
    }
}