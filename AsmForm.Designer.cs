
namespace RollMetCalc
{
    partial class AsmForm
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
            this.dgvPartList = new System.Windows.Forms.DataGridView();
            this.btAddPart = new System.Windows.Forms.Button();
            this.btSaveAsm = new System.Windows.Forms.Button();
            this.lbAsmName = new System.Windows.Forms.Label();
            this.tbAsmName = new System.Windows.Forms.TextBox();
            this.tbAsmCount = new System.Windows.Forms.TextBox();
            this.lbAsmCount = new System.Windows.Forms.Label();
            this.lbAsmID = new System.Windows.Forms.Label();
            this.tbAsmID = new System.Windows.Forms.TextBox();
            this.btCheckID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPartList
            // 
            this.dgvPartList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartList.Location = new System.Drawing.Point(16, 99);
            this.dgvPartList.Name = "dgvPartList";
            this.dgvPartList.RowHeadersVisible = false;
            this.dgvPartList.Size = new System.Drawing.Size(300, 155);
            this.dgvPartList.TabIndex = 9;
            // 
            // btAddPart
            // 
            this.btAddPart.Enabled = false;
            this.btAddPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddPart.Location = new System.Drawing.Point(16, 260);
            this.btAddPart.Name = "btAddPart";
            this.btAddPart.Size = new System.Drawing.Size(140, 60);
            this.btAddPart.TabIndex = 4;
            this.btAddPart.Text = "Добавить деталь";
            this.btAddPart.UseVisualStyleBackColor = true;
            this.btAddPart.Click += new System.EventHandler(this.AddPartBtn_Click);
            // 
            // btSaveAsm
            // 
            this.btSaveAsm.Enabled = false;
            this.btSaveAsm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSaveAsm.Location = new System.Drawing.Point(182, 260);
            this.btSaveAsm.Name = "btSaveAsm";
            this.btSaveAsm.Size = new System.Drawing.Size(140, 60);
            this.btSaveAsm.TabIndex = 5;
            this.btSaveAsm.Text = "Сохранить сборку";
            this.btSaveAsm.UseVisualStyleBackColor = true;
            this.btSaveAsm.Click += new System.EventHandler(this.SaveAsmBtn_Click);
            // 
            // lbAsmName
            // 
            this.lbAsmName.AutoSize = true;
            this.lbAsmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAsmName.Location = new System.Drawing.Point(12, 39);
            this.lbAsmName.Name = "lbAsmName";
            this.lbAsmName.Size = new System.Drawing.Size(143, 20);
            this.lbAsmName.TabIndex = 7;
            this.lbAsmName.Text = "Название сборки:";
            // 
            // tbAsmName
            // 
            this.tbAsmName.Location = new System.Drawing.Point(161, 42);
            this.tbAsmName.Name = "tbAsmName";
            this.tbAsmName.Size = new System.Drawing.Size(155, 20);
            this.tbAsmName.TabIndex = 2;
            // 
            // tbAsmCount
            // 
            this.tbAsmCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbAsmCount.Location = new System.Drawing.Point(161, 73);
            this.tbAsmCount.Name = "tbAsmCount";
            this.tbAsmCount.Size = new System.Drawing.Size(155, 20);
            this.tbAsmCount.TabIndex = 3;
            // 
            // lbAsmCount
            // 
            this.lbAsmCount.AutoSize = true;
            this.lbAsmCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAsmCount.Location = new System.Drawing.Point(12, 73);
            this.lbAsmCount.Name = "lbAsmCount";
            this.lbAsmCount.Size = new System.Drawing.Size(133, 20);
            this.lbAsmCount.TabIndex = 8;
            this.lbAsmCount.Text = "Кол-во в заказе:";
            // 
            // lbAsmID
            // 
            this.lbAsmID.AutoSize = true;
            this.lbAsmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAsmID.Location = new System.Drawing.Point(12, 9);
            this.lbAsmID.Name = "lbAsmID";
            this.lbAsmID.Size = new System.Drawing.Size(86, 20);
            this.lbAsmID.TabIndex = 6;
            this.lbAsmID.Text = "ID cборки:";
            // 
            // tbAsmID
            // 
            this.tbAsmID.Location = new System.Drawing.Point(161, 12);
            this.tbAsmID.Name = "tbAsmID";
            this.tbAsmID.Size = new System.Drawing.Size(70, 20);
            this.tbAsmID.TabIndex = 0;
            this.tbAsmID.TextChanged += new System.EventHandler(this.TbAsmID_TextChanged);
            // 
            // btCheckID
            // 
            this.btCheckID.Location = new System.Drawing.Point(238, 12);
            this.btCheckID.Name = "btCheckID";
            this.btCheckID.Size = new System.Drawing.Size(78, 20);
            this.btCheckID.TabIndex = 1;
            this.btCheckID.Text = "Проверить";
            this.btCheckID.UseVisualStyleBackColor = true;
            this.btCheckID.Click += new System.EventHandler(this.BtCheckID_Click);
            // 
            // AsmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 332);
            this.Controls.Add(this.btCheckID);
            this.Controls.Add(this.tbAsmID);
            this.Controls.Add(this.lbAsmID);
            this.Controls.Add(this.tbAsmCount);
            this.Controls.Add(this.lbAsmCount);
            this.Controls.Add(this.tbAsmName);
            this.Controls.Add(this.lbAsmName);
            this.Controls.Add(this.btSaveAsm);
            this.Controls.Add(this.btAddPart);
            this.Controls.Add(this.dgvPartList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AsmForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AsmForm_FormClosing);
            this.Load += new System.EventHandler(this.AsmForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btAddPart;
        private System.Windows.Forms.Button btSaveAsm;
        private System.Windows.Forms.Label lbAsmName;
        private System.Windows.Forms.TextBox tbAsmName;
        private System.Windows.Forms.TextBox tbAsmCount;
        private System.Windows.Forms.Label lbAsmCount;
        private System.Windows.Forms.Label lbAsmID;
        private System.Windows.Forms.TextBox tbAsmID;
        private System.Windows.Forms.Button btCheckID;
        private System.Windows.Forms.DataGridView dgvPartList;
    }
}