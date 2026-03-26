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
            this.cbCakeSize = new System.Windows.Forms.ComboBox();
            this.lbl_cake = new System.Windows.Forms.Label();
            this.cbCakes = new System.Windows.Forms.ComboBox();
            this.chbDecorationPremium = new System.Windows.Forms.CheckBox();
            this.chbTopperPremium = new System.Windows.Forms.CheckBox();
            this.chbTastePremium = new System.Windows.Forms.CheckBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_order_date = new System.Windows.Forms.Label();
            this.lbl_realization = new System.Windows.Forms.Label();
            this.dtpRealizationDate = new System.Windows.Forms.DateTimePicker();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.lbl_price = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_price = new System.Windows.Forms.Button();
            this.gb_premium = new System.Windows.Forms.GroupBox();
            this.btn_add_order = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.gb_premium.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCustomers
            // 
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(235, 138);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(210, 24);
            this.cbCustomers.TabIndex = 0;
            // 
            // lbl_client
            // 
            this.lbl_client.AutoSize = true;
            this.lbl_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lbl_client.Location = new System.Drawing.Point(18, 138);
            this.lbl_client.Name = "lbl_client";
            this.lbl_client.Size = new System.Drawing.Size(128, 22);
            this.lbl_client.TabIndex = 1;
            this.lbl_client.Text = "Wybrór Klienta";
            // 
            // lbl_size
            // 
            this.lbl_size.AutoSize = true;
            this.lbl_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lbl_size.Location = new System.Drawing.Point(18, 199);
            this.lbl_size.Name = "lbl_size";
            this.lbl_size.Size = new System.Drawing.Size(190, 22);
            this.lbl_size.TabIndex = 2;
            this.lbl_size.Text = "Wybór Rozmiaru Tortu";
            // 
            // cbCakeSize
            // 
            this.cbCakeSize.FormattingEnabled = true;
            this.cbCakeSize.Location = new System.Drawing.Point(235, 197);
            this.cbCakeSize.Name = "cbCakeSize";
            this.cbCakeSize.Size = new System.Drawing.Size(210, 24);
            this.cbCakeSize.TabIndex = 3;
            // 
            // lbl_cake
            // 
            this.lbl_cake.AutoSize = true;
            this.lbl_cake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lbl_cake.Location = new System.Drawing.Point(18, 257);
            this.lbl_cake.Name = "lbl_cake";
            this.lbl_cake.Size = new System.Drawing.Size(118, 22);
            this.lbl_cake.TabIndex = 4;
            this.lbl_cake.Text = "Wybór Ciasta";
            // 
            // cbCakes
            // 
            this.cbCakes.FormattingEnabled = true;
            this.cbCakes.Location = new System.Drawing.Point(235, 255);
            this.cbCakes.Name = "cbCakes";
            this.cbCakes.Size = new System.Drawing.Size(210, 24);
            this.cbCakes.TabIndex = 5;
            // 
            // chbDecorationPremium
            // 
            this.chbDecorationPremium.AutoSize = true;
            this.chbDecorationPremium.Location = new System.Drawing.Point(6, 30);
            this.chbDecorationPremium.Name = "chbDecorationPremium";
            this.chbDecorationPremium.Size = new System.Drawing.Size(148, 20);
            this.chbDecorationPremium.TabIndex = 6;
            this.chbDecorationPremium.Text = "Dekoracja Premium";
            this.chbDecorationPremium.UseVisualStyleBackColor = true;
            // 
            // chbTopperPremium
            // 
            this.chbTopperPremium.AutoSize = true;
            this.chbTopperPremium.Location = new System.Drawing.Point(6, 66);
            this.chbTopperPremium.Name = "chbTopperPremium";
            this.chbTopperPremium.Size = new System.Drawing.Size(130, 20);
            this.chbTopperPremium.TabIndex = 7;
            this.chbTopperPremium.Text = "Topper Premium";
            this.chbTopperPremium.UseVisualStyleBackColor = true;
            // 
            // chbTastePremium
            // 
            this.chbTastePremium.AutoSize = true;
            this.chbTastePremium.Location = new System.Drawing.Point(6, 103);
            this.chbTastePremium.Name = "chbTastePremium";
            this.chbTastePremium.Size = new System.Drawing.Size(120, 20);
            this.chbTastePremium.TabIndex = 8;
            this.chbTastePremium.Text = "Smak Premium";
            this.chbTastePremium.UseVisualStyleBackColor = true;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(738, 136);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 22);
            this.dtpOrderDate.TabIndex = 9;
            // 
            // lbl_order_date
            // 
            this.lbl_order_date.AutoSize = true;
            this.lbl_order_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lbl_order_date.Location = new System.Drawing.Point(483, 136);
            this.lbl_order_date.Name = "lbl_order_date";
            this.lbl_order_date.Size = new System.Drawing.Size(215, 22);
            this.lbl_order_date.TabIndex = 10;
            this.lbl_order_date.Text = "Data złożenia zamówienia";
            // 
            // lbl_realization
            // 
            this.lbl_realization.AutoSize = true;
            this.lbl_realization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lbl_realization.Location = new System.Drawing.Point(483, 195);
            this.lbl_realization.Name = "lbl_realization";
            this.lbl_realization.Size = new System.Drawing.Size(220, 22);
            this.lbl_realization.TabIndex = 11;
            this.lbl_realization.Text = "Data realizacji zamówienia";
            // 
            // dtpRealizationDate
            // 
            this.dtpRealizationDate.Location = new System.Drawing.Point(738, 195);
            this.dtpRealizationDate.Name = "dtpRealizationDate";
            this.dtpRealizationDate.Size = new System.Drawing.Size(200, 22);
            this.dtpRealizationDate.TabIndex = 12;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(738, 411);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(200, 22);
            this.txtTotalPrice.TabIndex = 13;
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
            this.label1.Size = new System.Drawing.Size(956, 90);
            this.label1.TabIndex = 15;
            this.label1.Text = "UTWÓRZ ZAMÓWIENIE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_price
            // 
            this.btn_price.BackColor = System.Drawing.Color.Salmon;
            this.btn_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btn_price.Location = new System.Drawing.Point(482, 391);
            this.btn_price.Name = "btn_price";
            this.btn_price.Size = new System.Drawing.Size(216, 58);
            this.btn_price.TabIndex = 16;
            this.btn_price.Text = "Oblicz kwotę zamówienia";
            this.btn_price.UseVisualStyleBackColor = false;
            this.btn_price.Click += new System.EventHandler(this.btn_price_Click);
            // 
            // gb_premium
            // 
            this.gb_premium.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.gb_premium.Controls.Add(this.chbDecorationPremium);
            this.gb_premium.Controls.Add(this.chbTopperPremium);
            this.gb_premium.Controls.Add(this.chbTastePremium);
            this.gb_premium.Location = new System.Drawing.Point(22, 311);
            this.gb_premium.Name = "gb_premium";
            this.gb_premium.Size = new System.Drawing.Size(423, 138);
            this.gb_premium.TabIndex = 17;
            this.gb_premium.TabStop = false;
            this.gb_premium.Text = "Dodatki Premium";
            // 
            // btn_add_order
            // 
            this.btn_add_order.BackColor = System.Drawing.Color.Green;
            this.btn_add_order.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btn_add_order.Location = new System.Drawing.Point(743, 496);
            this.btn_add_order.Name = "btn_add_order";
            this.btn_add_order.Size = new System.Drawing.Size(201, 63);
            this.btn_add_order.TabIndex = 18;
            this.btn_add_order.Text = "Utwórz zamówienie";
            this.btn_add_order.UseVisualStyleBackColor = false;
            this.btn_add_order.Click += new System.EventHandler(this.btn_add_order_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Red;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btn_cancel.Location = new System.Drawing.Point(28, 496);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(201, 63);
            this.btn_cancel.TabIndex = 19;
            this.btn_cancel.Text = "Anuluj dodawanie zamówienia";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(483, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Rabat na ciasto";
            // 
            // nudDiscount
            // 
            this.nudDiscount.Location = new System.Drawing.Point(743, 253);
            this.nudDiscount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(195, 22);
            this.nudDiscount.TabIndex = 22;
            // 
            // FormAddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 571);
            this.Controls.Add(this.nudDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add_order);
            this.Controls.Add(this.gb_premium);
            this.Controls.Add(this.btn_price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_price);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.dtpRealizationDate);
            this.Controls.Add(this.lbl_realization);
            this.Controls.Add(this.lbl_order_date);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.cbCakes);
            this.Controls.Add(this.lbl_cake);
            this.Controls.Add(this.cbCakeSize);
            this.Controls.Add(this.lbl_size);
            this.Controls.Add(this.lbl_client);
            this.Controls.Add(this.cbCustomers);
            this.Name = "FormAddOrder";
            this.Text = "FormAddOrder";
            this.gb_premium.ResumeLayout(false);
            this.gb_premium.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.Label lbl_client;
        private System.Windows.Forms.Label lbl_size;
        private System.Windows.Forms.ComboBox cbCakeSize;
        private System.Windows.Forms.Label lbl_cake;
        private System.Windows.Forms.ComboBox cbCakes;
        private System.Windows.Forms.CheckBox chbDecorationPremium;
        private System.Windows.Forms.CheckBox chbTopperPremium;
        private System.Windows.Forms.CheckBox chbTastePremium;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lbl_order_date;
        private System.Windows.Forms.Label lbl_realization;
        private System.Windows.Forms.DateTimePicker dtpRealizationDate;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_price;
        private System.Windows.Forms.GroupBox gb_premium;
        private System.Windows.Forms.Button btn_add_order;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDiscount;
    }
}