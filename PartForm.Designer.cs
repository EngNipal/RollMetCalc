
namespace RollMetCalc
{
    partial class PartForm
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
            this.lbFlatType = new System.Windows.Forms.Label();
            this.cbFlatType = new System.Windows.Forms.ComboBox();
            this.lbPartName = new System.Windows.Forms.Label();
            this.tbPartName = new System.Windows.Forms.TextBox();
            this.lbMass = new System.Windows.Forms.Label();
            this.tbPartMass = new System.Windows.Forms.TextBox();
            this.lbLength = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbThickness = new System.Windows.Forms.Label();
            this.tbLength = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbThickness = new System.Windows.Forms.TextBox();
            this.Dimensions = new System.Windows.Forms.GroupBox();
            this.lbShortShelf = new System.Windows.Forms.Label();
            this.tbShortShelf = new System.Windows.Forms.TextBox();
            this.gbMaterial = new System.Windows.Forms.GroupBox();
            this.lbDensVal = new System.Windows.Forms.Label();
            this.lbDensDim = new System.Windows.Forms.Label();
            this.cbPartMaterial = new System.Windows.Forms.ComboBox();
            this.lbPartCount = new System.Windows.Forms.Label();
            this.tbPartCount = new System.Windows.Forms.TextBox();
            this.btCheckData = new System.Windows.Forms.Button();
            this.btSavePart = new System.Windows.Forms.Button();
            this.lbPartID = new System.Windows.Forms.Label();
            this.tbPartID = new System.Windows.Forms.TextBox();
            this.lbDensity = new System.Windows.Forms.Label();
            this.tbDensity = new System.Windows.Forms.TextBox();
            this.btCheckID = new System.Windows.Forms.Button();
            this.Dimensions.SuspendLayout();
            this.gbMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFlatType
            // 
            this.lbFlatType.AutoSize = true;
            this.lbFlatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFlatType.Location = new System.Drawing.Point(13, 67);
            this.lbFlatType.Name = "lbFlatType";
            this.lbFlatType.Size = new System.Drawing.Size(110, 20);
            this.lbFlatType.TabIndex = 12;
            this.lbFlatType.Text = "Вид проката:";
            // 
            // cbFlatType
            // 
            this.cbFlatType.FormattingEnabled = true;
            this.cbFlatType.Items.AddRange(new object[] {
            "Арматура",
            "Лист",
            "Полоса",
            "Труба",
            "Уголок"});
            this.cbFlatType.Location = new System.Drawing.Point(168, 66);
            this.cbFlatType.Name = "cbFlatType";
            this.cbFlatType.Size = new System.Drawing.Size(200, 21);
            this.cbFlatType.TabIndex = 2;
            this.cbFlatType.SelectionChangeCommitted += new System.EventHandler(this.FlatTypeBox_SelectionChangeCommitted);
            // 
            // lbPartName
            // 
            this.lbPartName.AutoSize = true;
            this.lbPartName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPartName.Location = new System.Drawing.Point(13, 38);
            this.lbPartName.Name = "lbPartName";
            this.lbPartName.Size = new System.Drawing.Size(126, 20);
            this.lbPartName.TabIndex = 11;
            this.lbPartName.Text = "Наименование:";
            // 
            // tbPartName
            // 
            this.tbPartName.Location = new System.Drawing.Point(168, 38);
            this.tbPartName.Name = "tbPartName";
            this.tbPartName.Size = new System.Drawing.Size(200, 20);
            this.tbPartName.TabIndex = 1;
            // 
            // lbMass
            // 
            this.lbMass.AutoSize = true;
            this.lbMass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMass.Location = new System.Drawing.Point(13, 98);
            this.lbMass.Name = "lbMass";
            this.lbMass.Size = new System.Drawing.Size(122, 20);
            this.lbMass.TabIndex = 13;
            this.lbMass.Text = "Масса 1 шт, кг:";
            // 
            // tbPartMass
            // 
            this.tbPartMass.Location = new System.Drawing.Point(168, 98);
            this.tbPartMass.Name = "tbPartMass";
            this.tbPartMass.Size = new System.Drawing.Size(200, 20);
            this.tbPartMass.TabIndex = 3;
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Location = new System.Drawing.Point(7, 18);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(40, 13);
            this.lbLength.TabIndex = 3;
            this.lbLength.Text = "Длина";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(75, 18);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(46, 13);
            this.lbWidth.TabIndex = 4;
            this.lbWidth.Text = "Ширина";
            // 
            // lbThickness
            // 
            this.lbThickness.AutoSize = true;
            this.lbThickness.Location = new System.Drawing.Point(136, 18);
            this.lbThickness.Name = "lbThickness";
            this.lbThickness.Size = new System.Drawing.Size(53, 13);
            this.lbThickness.TabIndex = 5;
            this.lbThickness.Text = "Толщина";
            // 
            // tbLength
            // 
            this.tbLength.Location = new System.Drawing.Point(10, 34);
            this.tbLength.Name = "tbLength";
            this.tbLength.Size = new System.Drawing.Size(50, 20);
            this.tbLength.TabIndex = 0;
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(78, 34);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(50, 20);
            this.tbWidth.TabIndex = 1;
            // 
            // tbThickness
            // 
            this.tbThickness.Location = new System.Drawing.Point(142, 34);
            this.tbThickness.Name = "tbThickness";
            this.tbThickness.Size = new System.Drawing.Size(50, 20);
            this.tbThickness.TabIndex = 2;
            // 
            // Dimensions
            // 
            this.Dimensions.Controls.Add(this.lbShortShelf);
            this.Dimensions.Controls.Add(this.tbShortShelf);
            this.Dimensions.Controls.Add(this.tbThickness);
            this.Dimensions.Controls.Add(this.tbWidth);
            this.Dimensions.Controls.Add(this.tbLength);
            this.Dimensions.Controls.Add(this.lbThickness);
            this.Dimensions.Controls.Add(this.lbWidth);
            this.Dimensions.Controls.Add(this.lbLength);
            this.Dimensions.Location = new System.Drawing.Point(12, 163);
            this.Dimensions.Name = "Dimensions";
            this.Dimensions.Size = new System.Drawing.Size(212, 84);
            this.Dimensions.TabIndex = 5;
            this.Dimensions.TabStop = false;
            this.Dimensions.Text = "Размеры, мм";
            // 
            // lbShortShelf
            // 
            this.lbShortShelf.AutoSize = true;
            this.lbShortShelf.Location = new System.Drawing.Point(7, 63);
            this.lbShortShelf.Name = "lbShortShelf";
            this.lbShortShelf.Size = new System.Drawing.Size(62, 13);
            this.lbShortShelf.TabIndex = 7;
            this.lbShortShelf.Text = "Кор.полка:";
            this.lbShortShelf.Visible = false;
            // 
            // tbShortShelf
            // 
            this.tbShortShelf.Location = new System.Drawing.Point(78, 60);
            this.tbShortShelf.Name = "tbShortShelf";
            this.tbShortShelf.Size = new System.Drawing.Size(50, 20);
            this.tbShortShelf.TabIndex = 6;
            this.tbShortShelf.Visible = false;
            // 
            // gbMaterial
            // 
            this.gbMaterial.Controls.Add(this.lbDensVal);
            this.gbMaterial.Controls.Add(this.lbDensDim);
            this.gbMaterial.Controls.Add(this.cbPartMaterial);
            this.gbMaterial.Location = new System.Drawing.Point(230, 163);
            this.gbMaterial.Name = "gbMaterial";
            this.gbMaterial.Size = new System.Drawing.Size(135, 84);
            this.gbMaterial.TabIndex = 6;
            this.gbMaterial.TabStop = false;
            this.gbMaterial.Text = "Вид материала";
            // 
            // lbDensVal
            // 
            this.lbDensVal.AutoSize = true;
            this.lbDensVal.Location = new System.Drawing.Point(107, 54);
            this.lbDensVal.Name = "lbDensVal";
            this.lbDensVal.Size = new System.Drawing.Size(22, 13);
            this.lbDensVal.TabIndex = 2;
            this.lbDensVal.Text = "7,8";
            // 
            // lbDensDim
            // 
            this.lbDensDim.AutoSize = true;
            this.lbDensDim.Location = new System.Drawing.Point(6, 54);
            this.lbDensDim.Name = "lbDensDim";
            this.lbDensDim.Size = new System.Drawing.Size(100, 13);
            this.lbDensDim.TabIndex = 1;
            this.lbDensDim.Text = "Плотность, г/см3:";
            // 
            // cbPartMaterial
            // 
            this.cbPartMaterial.FormattingEnabled = true;
            this.cbPartMaterial.Items.AddRange(new object[] {
            "Алюминий",
            "Нержавейка",
            "Сталь"});
            this.cbPartMaterial.Location = new System.Drawing.Point(5, 18);
            this.cbPartMaterial.Name = "cbPartMaterial";
            this.cbPartMaterial.Size = new System.Drawing.Size(123, 21);
            this.cbPartMaterial.TabIndex = 0;
            this.cbPartMaterial.SelectionChangeCommitted += new System.EventHandler(this.CbPartMaterial_SelectionChangeCommitted);
            // 
            // lbPartCount
            // 
            this.lbPartCount.AutoSize = true;
            this.lbPartCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPartCount.Location = new System.Drawing.Point(11, 250);
            this.lbPartCount.Name = "lbPartCount";
            this.lbPartCount.Size = new System.Drawing.Size(203, 20);
            this.lbPartCount.TabIndex = 15;
            this.lbPartCount.Text = "Количество в сборке, шт:";
            // 
            // tbPartCount
            // 
            this.tbPartCount.Location = new System.Drawing.Point(230, 250);
            this.tbPartCount.Name = "tbPartCount";
            this.tbPartCount.Size = new System.Drawing.Size(135, 20);
            this.tbPartCount.TabIndex = 7;
            // 
            // btCheckData
            // 
            this.btCheckData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCheckData.Location = new System.Drawing.Point(12, 278);
            this.btCheckData.Name = "btCheckData";
            this.btCheckData.Size = new System.Drawing.Size(170, 60);
            this.btCheckData.TabIndex = 8;
            this.btCheckData.Text = "Проверка данных";
            this.btCheckData.UseVisualStyleBackColor = true;
            this.btCheckData.Click += new System.EventHandler(this.BtCheckData_Click);
            // 
            // btSavePart
            // 
            this.btSavePart.Enabled = false;
            this.btSavePart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSavePart.Location = new System.Drawing.Point(197, 278);
            this.btSavePart.Name = "btSavePart";
            this.btSavePart.Size = new System.Drawing.Size(170, 60);
            this.btSavePart.TabIndex = 9;
            this.btSavePart.Text = "Сохранить деталь";
            this.btSavePart.UseVisualStyleBackColor = true;
            this.btSavePart.Click += new System.EventHandler(this.SavePartBtn_Click);
            // 
            // lbPartID
            // 
            this.lbPartID.AutoSize = true;
            this.lbPartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPartID.Location = new System.Drawing.Point(12, 9);
            this.lbPartID.Name = "lbPartID";
            this.lbPartID.Size = new System.Drawing.Size(91, 20);
            this.lbPartID.TabIndex = 10;
            this.lbPartID.Text = "ID детали:";
            this.lbPartID.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tbPartID
            // 
            this.tbPartID.Location = new System.Drawing.Point(168, 9);
            this.tbPartID.Name = "tbPartID";
            this.tbPartID.Size = new System.Drawing.Size(100, 20);
            this.tbPartID.TabIndex = 0;
            this.tbPartID.TextChanged += new System.EventHandler(this.TbPartID_TextChanged);
            // 
            // lbDensity
            // 
            this.lbDensity.AutoSize = true;
            this.lbDensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDensity.Location = new System.Drawing.Point(13, 128);
            this.lbDensity.Name = "lbDensity";
            this.lbDensity.Size = new System.Drawing.Size(144, 20);
            this.lbDensity.TabIndex = 14;
            this.lbDensity.Text = "Плотность, г/см3:";
            // 
            // tbDensity
            // 
            this.tbDensity.Location = new System.Drawing.Point(168, 128);
            this.tbDensity.Name = "tbDensity";
            this.tbDensity.Size = new System.Drawing.Size(200, 20);
            this.tbDensity.TabIndex = 4;
            // 
            // btCheckID
            // 
            this.btCheckID.Location = new System.Drawing.Point(282, 9);
            this.btCheckID.Name = "btCheckID";
            this.btCheckID.Size = new System.Drawing.Size(83, 20);
            this.btCheckID.TabIndex = 16;
            this.btCheckID.Text = "Проверить";
            this.btCheckID.UseVisualStyleBackColor = true;
            this.btCheckID.Click += new System.EventHandler(this.BtCheckID_Click);
            // 
            // PartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 347);
            this.Controls.Add(this.btCheckID);
            this.Controls.Add(this.tbDensity);
            this.Controls.Add(this.lbDensity);
            this.Controls.Add(this.tbPartID);
            this.Controls.Add(this.lbPartID);
            this.Controls.Add(this.btSavePart);
            this.Controls.Add(this.btCheckData);
            this.Controls.Add(this.tbPartCount);
            this.Controls.Add(this.lbPartCount);
            this.Controls.Add(this.gbMaterial);
            this.Controls.Add(this.Dimensions);
            this.Controls.Add(this.tbPartMass);
            this.Controls.Add(this.lbMass);
            this.Controls.Add(this.tbPartName);
            this.Controls.Add(this.lbPartName);
            this.Controls.Add(this.cbFlatType);
            this.Controls.Add(this.lbFlatType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PartForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Деталь";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartForm_FormClosing);
            this.Dimensions.ResumeLayout(false);
            this.Dimensions.PerformLayout();
            this.gbMaterial.ResumeLayout(false);
            this.gbMaterial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFlatType;
        private System.Windows.Forms.ComboBox cbFlatType;
        private System.Windows.Forms.Label lbPartName;
        private System.Windows.Forms.TextBox tbPartName;
        private System.Windows.Forms.Label lbMass;
        private System.Windows.Forms.TextBox tbPartMass;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbThickness;
        private System.Windows.Forms.TextBox tbLength;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbThickness;
        private System.Windows.Forms.GroupBox Dimensions;
        private System.Windows.Forms.GroupBox gbMaterial;
        private System.Windows.Forms.Label lbDensVal;
        private System.Windows.Forms.Label lbDensDim;
        private System.Windows.Forms.ComboBox cbPartMaterial;
        private System.Windows.Forms.Label lbPartCount;
        private System.Windows.Forms.TextBox tbPartCount;
        private System.Windows.Forms.Button btCheckData;
        private System.Windows.Forms.Button btSavePart;
        private System.Windows.Forms.Label lbPartID;
        private System.Windows.Forms.TextBox tbPartID;
        private System.Windows.Forms.Label lbDensity;
        private System.Windows.Forms.TextBox tbDensity;
        private System.Windows.Forms.Button btCheckID;
        private System.Windows.Forms.Label lbShortShelf;
        private System.Windows.Forms.TextBox tbShortShelf;
    }
}