namespace DomoweWypieki
{
    partial class FormEditOffer
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
            this.label1 = new System.Windows.Forms.Label();
            this.nup_Price = new System.Windows.Forms.NumericUpDown();
            this.cb_OfferType = new System.Windows.Forms.ComboBox();
            this.lbl_CakesInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.txt_OfferTitle = new System.Windows.Forms.TextBox();
            this.lbl_surename = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Price)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(956, 90);
            this.label1.TabIndex = 18;
            this.label1.Text = "EDYTUJ OFERTĘ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nup_Price
            // 
            this.nup_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nup_Price.Location = new System.Drawing.Point(248, 363);
            this.nup_Price.Name = "nup_Price";
            this.nup_Price.Size = new System.Drawing.Size(225, 30);
            this.nup_Price.TabIndex = 60;
            // 
            // cb_OfferType
            // 
            this.cb_OfferType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_OfferType.FormattingEnabled = true;
            this.cb_OfferType.Location = new System.Drawing.Point(248, 210);
            this.cb_OfferType.Name = "cb_OfferType";
            this.cb_OfferType.Size = new System.Drawing.Size(225, 33);
            this.cb_OfferType.TabIndex = 59;
            // 
            // lbl_CakesInfo
            // 
            this.lbl_CakesInfo.AutoSize = true;
            this.lbl_CakesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_CakesInfo.ForeColor = System.Drawing.Color.Black;
            this.lbl_CakesInfo.Location = new System.Drawing.Point(283, 132);
            this.lbl_CakesInfo.Name = "lbl_CakesInfo";
            this.lbl_CakesInfo.Size = new System.Drawing.Size(440, 29);
            this.lbl_CakesInfo.TabIndex = 58;
            this.lbl_CakesInfo.Text = "FORMULARZ DO EDYCJI OFERTY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(24, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 57;
            this.label3.Text = "Podaj cenę";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(537, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 56;
            this.label2.Text = "Podaj opis";
            // 
            // txt_description
            // 
            this.txt_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_description.Location = new System.Drawing.Point(646, 210);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(255, 183);
            this.txt_description.TabIndex = 55;
            // 
            // txt_OfferTitle
            // 
            this.txt_OfferTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_OfferTitle.Location = new System.Drawing.Point(248, 285);
            this.txt_OfferTitle.Name = "txt_OfferTitle";
            this.txt_OfferTitle.Size = new System.Drawing.Size(225, 30);
            this.txt_OfferTitle.TabIndex = 54;
            // 
            // lbl_surename
            // 
            this.lbl_surename.AutoSize = true;
            this.lbl_surename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_surename.Location = new System.Drawing.Point(24, 290);
            this.lbl_surename.Name = "lbl_surename";
            this.lbl_surename.Size = new System.Drawing.Size(135, 25);
            this.lbl_surename.TabIndex = 53;
            this.lbl_surename.Text = "Podaj nazwę";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_name.Location = new System.Drawing.Point(24, 218);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(199, 25);
            this.lbl_name.TabIndex = 52;
            this.lbl_name.Text = "Podaj rodzaj oferty:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnCancel.Location = new System.Drawing.Point(29, 487);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(206, 61);
            this.btnCancel.TabIndex = 62;
            this.btnCancel.Text = "Anuluj i wyjdź";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnSave.Location = new System.Drawing.Point(700, 487);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(201, 61);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "Zapisz zmiany";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // FormEditOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 571);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nup_Price);
            this.Controls.Add(this.cb_OfferType);
            this.Controls.Add(this.lbl_CakesInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.txt_OfferTitle);
            this.Controls.Add(this.lbl_surename);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.label1);
            this.Name = "FormEditOffer";
            this.Text = "FormEditOffer";
            ((System.ComponentModel.ISupportInitialize)(this.nup_Price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nup_Price;
        private System.Windows.Forms.ComboBox cb_OfferType;
        private System.Windows.Forms.Label lbl_CakesInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.TextBox txt_OfferTitle;
        private System.Windows.Forms.Label lbl_surename;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}