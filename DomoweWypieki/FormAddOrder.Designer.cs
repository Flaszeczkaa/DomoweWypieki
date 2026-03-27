namespace DomoweWypieki
{
    partial class FormAddOrder
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
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.lbl_client = new System.Windows.Forms.Label();
            this.lbl_size = new System.Windows.Forms.Label();
            this.cb_BirthdayCake = new System.Windows.Forms.ComboBox();
            this.lbl_cake = new System.Windows.Forms.Label();
            this.cb_Cakes = new System.Windows.Forms.ComboBox();
            this.chbDecorationPremium = new System.Windows.Forms.CheckBox();
            this.chbTopperPremium = new System.Windows.Forms.CheckBox();
            this.chbTastePremium = new System.Windows.Forms.CheckBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_order_date = new System.Windows.Forms.Label();
            this.lbl_realization = new System.Windows.Forms.Label();
            this.dtpRealizationDate = new System.Windows.Forms.DateTimePicker();
            this.txt_TotalPrice = new System.Windows.Forms.TextBox();
            this.lbl_price = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CalculatePrice = new System.Windows.Forms.Button();
            this.gb_PremiumAdds = new System.Windows.Forms.GroupBox();
            this.btn_AddOrder = new System.Windows.Forms.Button();
            this.btn_CancelOrder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.gb_OrderData = new System.Windows.Forms.GroupBox();
            this.gb_AddItems = new System.Windows.Forms.GroupBox();
            this.gb_AddBirthdayCake = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nup_BirthdayCake = new System.Windows.Forms.NumericUpDown();
            this.nup_Cakes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_AddCake = new System.Windows.Forms.GroupBox();
            this.btn_AddToCart = new System.Windows.Forms.Button();
            this.gb_Cart = new System.Windows.Forms.GroupBox();
            this.dgv_Cart = new System.Windows.Forms.DataGridView();
            this.gb_PremiumAdds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.gb_OrderData.SuspendLayout();
            this.gb_AddItems.SuspendLayout();
            this.gb_AddBirthdayCake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_BirthdayCake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Cakes)).BeginInit();
            this.gb_AddCake.SuspendLayout();
            this.gb_Cart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cart)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCustomers
            // 
            this.cbCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(248, 28);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(200, 24);
            this.cbCustomers.TabIndex = 0;
            // 
            // lbl_client
            // 
            this.lbl_client.AutoSize = true;
            this.lbl_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_client.Location = new System.Drawing.Point(12, 30);
            this.lbl_client.Name = "lbl_client";
            this.lbl_client.Size = new System.Drawing.Size(119, 20);
            this.lbl_client.TabIndex = 1;
            this.lbl_client.Text = "Wybrór Klienta";
            // 
            // lbl_size
            // 
            this.lbl_size.AutoSize = true;
            this.lbl_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_size.Location = new System.Drawing.Point(10, 26);
            this.lbl_size.Name = "lbl_size";
            this.lbl_size.Size = new System.Drawing.Size(178, 20);
            this.lbl_size.TabIndex = 2;
            this.lbl_size.Text = "Wybór Rozmiaru Tortu";
            // 
            // cb_BirthdayCake
            // 
            this.cb_BirthdayCake.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.cb_BirthdayCake.FormattingEnabled = true;
            this.cb_BirthdayCake.Location = new System.Drawing.Point(206, 24);
            this.cb_BirthdayCake.Name = "cb_BirthdayCake";
            this.cb_BirthdayCake.Size = new System.Drawing.Size(168, 24);
            this.cb_BirthdayCake.TabIndex = 3;
            // 
            // lbl_cake
            // 
            this.lbl_cake.AutoSize = true;
            this.lbl_cake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.lbl_cake.Location = new System.Drawing.Point(16, 26);
            this.lbl_cake.Name = "lbl_cake";
            this.lbl_cake.Size = new System.Drawing.Size(110, 20);
            this.lbl_cake.TabIndex = 4;
            this.lbl_cake.Text = "Wybór Ciasta";
            // 
            // cb_Cakes
            // 
            this.cb_Cakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.cb_Cakes.FormattingEnabled = true;
            this.cb_Cakes.Location = new System.Drawing.Point(140, 26);
            this.cb_Cakes.Name = "cb_Cakes";
            this.cb_Cakes.Size = new System.Drawing.Size(210, 24);
            this.cb_Cakes.TabIndex = 5;
            // 
            // chbDecorationPremium
            // 
            this.chbDecorationPremium.AutoSize = true;
            this.chbDecorationPremium.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbDecorationPremium.Location = new System.Drawing.Point(6, 21);
            this.chbDecorationPremium.Name = "chbDecorationPremium";
            this.chbDecorationPremium.Size = new System.Drawing.Size(95, 20);
            this.chbDecorationPremium.TabIndex = 6;
            this.chbDecorationPremium.Text = "Dekoracja ";
            this.chbDecorationPremium.UseVisualStyleBackColor = true;
            // 
            // chbTopperPremium
            // 
            this.chbTopperPremium.AutoSize = true;
            this.chbTopperPremium.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbTopperPremium.Location = new System.Drawing.Point(104, 21);
            this.chbTopperPremium.Name = "chbTopperPremium";
            this.chbTopperPremium.Size = new System.Drawing.Size(77, 20);
            this.chbTopperPremium.TabIndex = 7;
            this.chbTopperPremium.Text = "Topper ";
            this.chbTopperPremium.UseVisualStyleBackColor = true;
            // 
            // chbTastePremium
            // 
            this.chbTastePremium.AutoSize = true;
            this.chbTastePremium.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbTastePremium.Location = new System.Drawing.Point(187, 21);
            this.chbTastePremium.Name = "chbTastePremium";
            this.chbTastePremium.Size = new System.Drawing.Size(120, 20);
            this.chbTastePremium.TabIndex = 8;
            this.chbTastePremium.Text = "Smak Premium";
            this.chbTastePremium.UseVisualStyleBackColor = true;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpOrderDate.Location = new System.Drawing.Point(248, 58);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 22);
            this.dtpOrderDate.TabIndex = 9;
            // 
            // lbl_order_date
            // 
            this.lbl_order_date.AutoSize = true;
            this.lbl_order_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_order_date.Location = new System.Drawing.Point(12, 59);
            this.lbl_order_date.Name = "lbl_order_date";
            this.lbl_order_date.Size = new System.Drawing.Size(205, 20);
            this.lbl_order_date.TabIndex = 10;
            this.lbl_order_date.Text = "Data złożenia zamówienia";
            // 
            // lbl_realization
            // 
            this.lbl_realization.AutoSize = true;
            this.lbl_realization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_realization.Location = new System.Drawing.Point(12, 87);
            this.lbl_realization.Name = "lbl_realization";
            this.lbl_realization.Size = new System.Drawing.Size(210, 20);
            this.lbl_realization.TabIndex = 11;
            this.lbl_realization.Text = "Data realizacji zamówienia";
            // 
            // dtpRealizationDate
            // 
            this.dtpRealizationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpRealizationDate.Location = new System.Drawing.Point(248, 86);
            this.dtpRealizationDate.Name = "dtpRealizationDate";
            this.dtpRealizationDate.Size = new System.Drawing.Size(200, 22);
            this.dtpRealizationDate.TabIndex = 12;
            // 
            // txt_TotalPrice
            // 
            this.txt_TotalPrice.Location = new System.Drawing.Point(245, 421);
            this.txt_TotalPrice.Name = "txt_TotalPrice";
            this.txt_TotalPrice.Size = new System.Drawing.Size(213, 30);
            this.txt_TotalPrice.TabIndex = 13;
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lbl_price.Location = new System.Drawing.Point(564, 341);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(0, 22);
            this.lbl_price.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(956, 58);
            this.label1.TabIndex = 15;
            this.label1.Text = "UTWÓRZ ZAMÓWIENIE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_CalculatePrice
            // 
            this.btn_CalculatePrice.BackColor = System.Drawing.Color.Salmon;
            this.btn_CalculatePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btn_CalculatePrice.Location = new System.Drawing.Point(14, 420);
            this.btn_CalculatePrice.Name = "btn_CalculatePrice";
            this.btn_CalculatePrice.Size = new System.Drawing.Size(216, 35);
            this.btn_CalculatePrice.TabIndex = 16;
            this.btn_CalculatePrice.Text = "Oblicz kwotę ";
            this.btn_CalculatePrice.UseVisualStyleBackColor = false;

            // 
            // gb_PremiumAdds
            // 
            this.gb_PremiumAdds.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gb_PremiumAdds.Controls.Add(this.chbDecorationPremium);
            this.gb_PremiumAdds.Controls.Add(this.chbTopperPremium);
            this.gb_PremiumAdds.Controls.Add(this.chbTastePremium);
            this.gb_PremiumAdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_PremiumAdds.Location = new System.Drawing.Point(9, 54);
            this.gb_PremiumAdds.Name = "gb_PremiumAdds";
            this.gb_PremiumAdds.Size = new System.Drawing.Size(309, 50);
            this.gb_PremiumAdds.TabIndex = 17;
            this.gb_PremiumAdds.TabStop = false;
            this.gb_PremiumAdds.Text = "Dodatki Premium";
            // 
            // btn_AddOrder
            // 
            this.btn_AddOrder.BackColor = System.Drawing.Color.Green;
            this.btn_AddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btn_AddOrder.Location = new System.Drawing.Point(743, 546);
            this.btn_AddOrder.Name = "btn_AddOrder";
            this.btn_AddOrder.Size = new System.Drawing.Size(201, 44);
            this.btn_AddOrder.TabIndex = 18;
            this.btn_AddOrder.Text = "Utwórz zamówienie";
            this.btn_AddOrder.UseVisualStyleBackColor = false;

            // 
            // btn_CancelOrder
            // 
            this.btn_CancelOrder.BackColor = System.Drawing.Color.Red;
            this.btn_CancelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btn_CancelOrder.Location = new System.Drawing.Point(13, 546);
            this.btn_CancelOrder.Name = "btn_CancelOrder";
            this.btn_CancelOrder.Size = new System.Drawing.Size(201, 44);
            this.btn_CancelOrder.TabIndex = 19;
            this.btn_CancelOrder.Text = "Anuluj dodawanie ";
            this.btn_CancelOrder.UseVisualStyleBackColor = false;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Rabat na ciasto";
            // 
            // nudDiscount
            // 
            this.nudDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudDiscount.Location = new System.Drawing.Point(247, 114);
            this.nudDiscount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(201, 22);
            this.nudDiscount.TabIndex = 22;
            // 
            // gb_OrderData
            // 
            this.gb_OrderData.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gb_OrderData.Controls.Add(this.cbCustomers);
            this.gb_OrderData.Controls.Add(this.nudDiscount);
            this.gb_OrderData.Controls.Add(this.lbl_client);
            this.gb_OrderData.Controls.Add(this.label2);
            this.gb_OrderData.Controls.Add(this.dtpOrderDate);
            this.gb_OrderData.Controls.Add(this.lbl_order_date);
            this.gb_OrderData.Controls.Add(this.lbl_realization);
            this.gb_OrderData.Controls.Add(this.dtpRealizationDate);
            this.gb_OrderData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_OrderData.Location = new System.Drawing.Point(12, 72);
            this.gb_OrderData.Name = "gb_OrderData";
            this.gb_OrderData.Size = new System.Drawing.Size(465, 147);
            this.gb_OrderData.TabIndex = 24;
            this.gb_OrderData.TabStop = false;
            this.gb_OrderData.Text = "Dane Zamówienia";
 
            // 
            // gb_AddItems
            // 
            this.gb_AddItems.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gb_AddItems.Controls.Add(this.btn_AddToCart);
            this.gb_AddItems.Controls.Add(this.gb_AddCake);
            this.gb_AddItems.Controls.Add(this.gb_AddBirthdayCake);
            this.gb_AddItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_AddItems.Location = new System.Drawing.Point(13, 225);
            this.gb_AddItems.Name = "gb_AddItems";
            this.gb_AddItems.Size = new System.Drawing.Size(464, 315);
            this.gb_AddItems.TabIndex = 25;
            this.gb_AddItems.TabStop = false;
            this.gb_AddItems.Text = "Dodaj produkt do zamówienia";
            // 
            // gb_AddBirthdayCake
            // 
            this.gb_AddBirthdayCake.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gb_AddBirthdayCake.Controls.Add(this.nup_BirthdayCake);
            this.gb_AddBirthdayCake.Controls.Add(this.label3);
            this.gb_AddBirthdayCake.Controls.Add(this.cb_BirthdayCake);
            this.gb_AddBirthdayCake.Controls.Add(this.lbl_size);
            this.gb_AddBirthdayCake.Controls.Add(this.gb_PremiumAdds);
            this.gb_AddBirthdayCake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_AddBirthdayCake.Location = new System.Drawing.Point(6, 122);
            this.gb_AddBirthdayCake.Name = "gb_AddBirthdayCake";
            this.gb_AddBirthdayCake.Size = new System.Drawing.Size(452, 145);
            this.gb_AddBirthdayCake.TabIndex = 26;
            this.gb_AddBirthdayCake.TabStop = false;
            this.gb_AddBirthdayCake.Text = "Skonfiguruj tort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(16, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Podaj ilość";
            // 
            // nup_BirthdayCake
            // 
            this.nup_BirthdayCake.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.nup_BirthdayCake.Location = new System.Drawing.Point(112, 107);
            this.nup_BirthdayCake.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nup_BirthdayCake.Name = "nup_BirthdayCake";
            this.nup_BirthdayCake.Size = new System.Drawing.Size(98, 22);
            this.nup_BirthdayCake.TabIndex = 23;
            // 
            // nup_Cakes
            // 
            this.nup_Cakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.nup_Cakes.Location = new System.Drawing.Point(140, 56);
            this.nup_Cakes.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nup_Cakes.Name = "nup_Cakes";
            this.nup_Cakes.Size = new System.Drawing.Size(210, 22);
            this.nup_Cakes.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label4.Location = new System.Drawing.Point(16, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Podaj ilość";
            // 
            // gb_AddCake
            // 
            this.gb_AddCake.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gb_AddCake.Controls.Add(this.cb_Cakes);
            this.gb_AddCake.Controls.Add(this.nup_Cakes);
            this.gb_AddCake.Controls.Add(this.lbl_cake);
            this.gb_AddCake.Controls.Add(this.label4);
            this.gb_AddCake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_AddCake.Location = new System.Drawing.Point(6, 29);
            this.gb_AddCake.Name = "gb_AddCake";
            this.gb_AddCake.Size = new System.Drawing.Size(452, 87);
            this.gb_AddCake.TabIndex = 28;
            this.gb_AddCake.TabStop = false;
            this.gb_AddCake.Text = "Skonfiguruj ciasto";
            // 
            // btn_AddToCart
            // 
            this.btn_AddToCart.BackColor = System.Drawing.Color.Salmon;
            this.btn_AddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_AddToCart.Location = new System.Drawing.Point(6, 273);
            this.btn_AddToCart.Name = "btn_AddToCart";
            this.btn_AddToCart.Size = new System.Drawing.Size(452, 29);
            this.btn_AddToCart.TabIndex = 26;
            this.btn_AddToCart.Text = "Dodaj do koszyka zamówienia";
            this.btn_AddToCart.UseVisualStyleBackColor = false;
            // 
            // gb_Cart
            // 
            this.gb_Cart.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gb_Cart.Controls.Add(this.dgv_Cart);
            this.gb_Cart.Controls.Add(this.txt_TotalPrice);
            this.gb_Cart.Controls.Add(this.btn_CalculatePrice);
            this.gb_Cart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_Cart.Location = new System.Drawing.Point(483, 72);
            this.gb_Cart.Name = "gb_Cart";
            this.gb_Cart.Size = new System.Drawing.Size(473, 468);
            this.gb_Cart.TabIndex = 26;
            this.gb_Cart.TabStop = false;
            this.gb_Cart.Text = "Twój koszyk zamówienia";
            // 
            // dgv_Cart
            // 
            this.dgv_Cart.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_Cart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Cart.Location = new System.Drawing.Point(15, 28);
            this.dgv_Cart.Name = "dgv_Cart";
            this.dgv_Cart.RowHeadersWidth = 51;
            this.dgv_Cart.RowTemplate.Height = 24;
            this.dgv_Cart.Size = new System.Drawing.Size(443, 386);
            this.dgv_Cart.TabIndex = 0;
            // 
            // FormAddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 602);
            this.Controls.Add(this.gb_Cart);
            this.Controls.Add(this.gb_AddItems);
            this.Controls.Add(this.gb_OrderData);
            this.Controls.Add(this.btn_CancelOrder);
            this.Controls.Add(this.btn_AddOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_price);
            this.Name = "FormAddOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddOrder";

            this.gb_PremiumAdds.ResumeLayout(false);
            this.gb_PremiumAdds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.gb_OrderData.ResumeLayout(false);
            this.gb_OrderData.PerformLayout();
            this.gb_AddItems.ResumeLayout(false);
            this.gb_AddBirthdayCake.ResumeLayout(false);
            this.gb_AddBirthdayCake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_BirthdayCake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Cakes)).EndInit();
            this.gb_AddCake.ResumeLayout(false);
            this.gb_AddCake.PerformLayout();
            this.gb_Cart.ResumeLayout(false);
            this.gb_Cart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.Label lbl_client;
        private System.Windows.Forms.Label lbl_size;
        private System.Windows.Forms.ComboBox cb_BirthdayCake;
        private System.Windows.Forms.Label lbl_cake;
        private System.Windows.Forms.ComboBox cb_Cakes;
        private System.Windows.Forms.CheckBox chbDecorationPremium;
        private System.Windows.Forms.CheckBox chbTopperPremium;
        private System.Windows.Forms.CheckBox chbTastePremium;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lbl_order_date;
        private System.Windows.Forms.Label lbl_realization;
        private System.Windows.Forms.DateTimePicker dtpRealizationDate;
        private System.Windows.Forms.TextBox txt_TotalPrice;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CalculatePrice;
        private System.Windows.Forms.GroupBox gb_PremiumAdds;
        private System.Windows.Forms.Button btn_AddOrder;
        private System.Windows.Forms.Button btn_CancelOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.GroupBox gb_OrderData;
        private System.Windows.Forms.GroupBox gb_AddItems;
        private System.Windows.Forms.GroupBox gb_AddBirthdayCake;
        private System.Windows.Forms.NumericUpDown nup_BirthdayCake;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nup_Cakes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_AddCake;
        private System.Windows.Forms.Button btn_AddToCart;
        private System.Windows.Forms.GroupBox gb_Cart;
        private System.Windows.Forms.DataGridView dgv_Cart;
    }
}