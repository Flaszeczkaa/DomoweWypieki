namespace DomoweWypieki
{
    partial class FormAddOrder_Step2
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
            this.gb_OrderData = new System.Windows.Forms.GroupBox();
            this.cb_Customers = new System.Windows.Forms.ComboBox();
            this.nud_Discount = new System.Windows.Forms.NumericUpDown();
            this.lbl_client = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_OrderDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_order_date = new System.Windows.Forms.Label();
            this.lbl_realization = new System.Windows.Forms.Label();
            this.dtp_RealizationDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txb_FinalPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_PaymentsMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_CancelOrder = new System.Windows.Forms.Button();
            this.btn_AddOrder = new System.Windows.Forms.Button();
            this.gb_OrderData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Discount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_OrderData
            // 
            this.gb_OrderData.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gb_OrderData.Controls.Add(this.cb_Customers);
            this.gb_OrderData.Controls.Add(this.nud_Discount);
            this.gb_OrderData.Controls.Add(this.lbl_client);
            this.gb_OrderData.Controls.Add(this.label2);
            this.gb_OrderData.Controls.Add(this.dtp_OrderDate);
            this.gb_OrderData.Controls.Add(this.lbl_order_date);
            this.gb_OrderData.Controls.Add(this.lbl_realization);
            this.gb_OrderData.Controls.Add(this.dtp_RealizationDate);
            this.gb_OrderData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_OrderData.Location = new System.Drawing.Point(12, 86);
            this.gb_OrderData.Name = "gb_OrderData";
            this.gb_OrderData.Size = new System.Drawing.Size(934, 274);
            this.gb_OrderData.TabIndex = 25;
            this.gb_OrderData.TabStop = false;
            this.gb_OrderData.Text = "Dane Zamówienia";
            // 
            // cb_Customers
            // 
            this.cb_Customers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_Customers.FormattingEnabled = true;
            this.cb_Customers.Location = new System.Drawing.Point(424, 42);
            this.cb_Customers.Name = "cb_Customers";
            this.cb_Customers.Size = new System.Drawing.Size(356, 33);
            this.cb_Customers.TabIndex = 0;
            // 
            // nud_Discount
            // 
            this.nud_Discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nud_Discount.Location = new System.Drawing.Point(424, 198);
            this.nud_Discount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_Discount.Name = "nud_Discount";
            this.nud_Discount.Size = new System.Drawing.Size(357, 30);
            this.nud_Discount.TabIndex = 22;
            // 
            // lbl_client
            // 
            this.lbl_client.AutoSize = true;
            this.lbl_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_client.Location = new System.Drawing.Point(160, 50);
            this.lbl_client.Name = "lbl_client";
            this.lbl_client.Size = new System.Drawing.Size(141, 25);
            this.lbl_client.TabIndex = 1;
            this.lbl_client.Text = "Wybrór Klienta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(160, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Rabat na ciasto";
            // 
            // dtp_OrderDate
            // 
            this.dtp_OrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtp_OrderDate.Location = new System.Drawing.Point(424, 95);
            this.dtp_OrderDate.Name = "dtp_OrderDate";
            this.dtp_OrderDate.Size = new System.Drawing.Size(357, 30);
            this.dtp_OrderDate.TabIndex = 9;
            this.dtp_OrderDate.Value = new System.DateTime(2026, 3, 29, 0, 0, 0, 0);
            // 
            // lbl_order_date
            // 
            this.lbl_order_date.AutoSize = true;
            this.lbl_order_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_order_date.Location = new System.Drawing.Point(160, 100);
            this.lbl_order_date.Name = "lbl_order_date";
            this.lbl_order_date.Size = new System.Drawing.Size(238, 25);
            this.lbl_order_date.TabIndex = 10;
            this.lbl_order_date.Text = "Data złożenia zamówienia";
            // 
            // lbl_realization
            // 
            this.lbl_realization.AutoSize = true;
            this.lbl_realization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_realization.Location = new System.Drawing.Point(160, 152);
            this.lbl_realization.Name = "lbl_realization";
            this.lbl_realization.Size = new System.Drawing.Size(241, 25);
            this.lbl_realization.TabIndex = 11;
            this.lbl_realization.Text = "Data realizacji zamówienia";
            // 
            // dtp_RealizationDate
            // 
            this.dtp_RealizationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtp_RealizationDate.Location = new System.Drawing.Point(424, 147);
            this.dtp_RealizationDate.Name = "dtp_RealizationDate";
            this.dtp_RealizationDate.Size = new System.Drawing.Size(357, 30);
            this.dtp_RealizationDate.TabIndex = 12;
            this.dtp_RealizationDate.Value = new System.DateTime(2026, 3, 29, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(958, 69);
            this.label1.TabIndex = 26;
            this.label1.Text = "UTWÓRZ ZAMÓWIENIE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.txb_FinalPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb_PaymentsMethod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 366);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 133);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podsumowanie i wybór płatności";
            // 
            // txb_FinalPrice
            // 
            this.txb_FinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txb_FinalPrice.Location = new System.Drawing.Point(425, 38);
            this.txb_FinalPrice.Name = "txb_FinalPrice";
            this.txb_FinalPrice.Size = new System.Drawing.Size(355, 30);
            this.txb_FinalPrice.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(160, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kwota ostateczna ";
            // 
            // cb_PaymentsMethod
            // 
            this.cb_PaymentsMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_PaymentsMethod.FormattingEnabled = true;
            this.cb_PaymentsMethod.Location = new System.Drawing.Point(424, 81);
            this.cb_PaymentsMethod.Name = "cb_PaymentsMethod";
            this.cb_PaymentsMethod.Size = new System.Drawing.Size(356, 33);
            this.cb_PaymentsMethod.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(160, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Metoda płatności";
            // 
            // btn_CancelOrder
            // 
            this.btn_CancelOrder.BackColor = System.Drawing.Color.Red;
            this.btn_CancelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_CancelOrder.Location = new System.Drawing.Point(12, 505);
            this.btn_CancelOrder.Name = "btn_CancelOrder";
            this.btn_CancelOrder.Size = new System.Drawing.Size(278, 51);
            this.btn_CancelOrder.TabIndex = 29;
            this.btn_CancelOrder.Text = "Anuluj i wyjdź ";
            this.btn_CancelOrder.UseVisualStyleBackColor = false;
            this.btn_CancelOrder.Click += new System.EventHandler(this.btn_CancelOrder_Click);
            // 
            // btn_AddOrder
            // 
            this.btn_AddOrder.BackColor = System.Drawing.Color.Green;
            this.btn_AddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_AddOrder.Location = new System.Drawing.Point(668, 505);
            this.btn_AddOrder.Name = "btn_AddOrder";
            this.btn_AddOrder.Size = new System.Drawing.Size(278, 51);
            this.btn_AddOrder.TabIndex = 28;
            this.btn_AddOrder.Text = "Zatwierdź i utwórz";
            this.btn_AddOrder.UseVisualStyleBackColor = false;
            // 
            // FormAddOrder_Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(958, 566);
            this.Controls.Add(this.btn_CancelOrder);
            this.Controls.Add(this.btn_AddOrder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_OrderData);
            this.Name = "FormAddOrder_Step2";
            this.Text = "FormAddOrder_Step2";
            this.gb_OrderData.ResumeLayout(false);
            this.gb_OrderData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Discount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_OrderData;
        private System.Windows.Forms.ComboBox cb_Customers;
        private System.Windows.Forms.NumericUpDown nud_Discount;
        private System.Windows.Forms.Label lbl_client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_OrderDate;
        private System.Windows.Forms.Label lbl_order_date;
        private System.Windows.Forms.Label lbl_realization;
        private System.Windows.Forms.DateTimePicker dtp_RealizationDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txb_FinalPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_PaymentsMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_CancelOrder;
        private System.Windows.Forms.Button btn_AddOrder;
    }
}