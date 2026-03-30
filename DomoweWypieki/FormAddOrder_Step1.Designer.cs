namespace DomoweWypieki
{
    partial class FormAddOrder_Step1
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
            this.lbl_cake = new System.Windows.Forms.Label();
            this.cb_Cakes = new System.Windows.Forms.ComboBox();
            this.chbDecorationPremium = new System.Windows.Forms.CheckBox();
            this.chbTopperPremium = new System.Windows.Forms.CheckBox();
            this.chbTastePremium = new System.Windows.Forms.CheckBox();
            this.lbl_price = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CalculatePrice = new System.Windows.Forms.Button();
            this.gb_PremiumAdds = new System.Windows.Forms.GroupBox();
            this.btn_NextStep = new System.Windows.Forms.Button();
            this.btn_CancelOrder = new System.Windows.Forms.Button();
            this.gb_AddItems = new System.Windows.Forms.GroupBox();
            this.btn_AddToCart = new System.Windows.Forms.Button();
            this.gb_AddCake = new System.Windows.Forms.GroupBox();
            this.nup_Cakes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_Cart = new System.Windows.Forms.GroupBox();
            this.dgv_Cart = new System.Windows.Forms.DataGridView();
            this.gb_PremiumAdds.SuspendLayout();
            this.gb_AddItems.SuspendLayout();
            this.gb_AddCake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Cakes)).BeginInit();
            this.gb_Cart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cart)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_cake
            // 
            this.lbl_cake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_cake.Location = new System.Drawing.Point(28, 38);
            this.lbl_cake.Name = "lbl_cake";
            this.lbl_cake.Size = new System.Drawing.Size(409, 25);
            this.lbl_cake.TabIndex = 4;
            this.lbl_cake.Text = "Wybierz rodzaj wypieku:";
            this.lbl_cake.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Cakes
            // 
            this.cb_Cakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_Cakes.FormattingEnabled = true;
            this.cb_Cakes.Location = new System.Drawing.Point(26, 66);
            this.cb_Cakes.Name = "cb_Cakes";
            this.cb_Cakes.Size = new System.Drawing.Size(411, 33);
            this.cb_Cakes.TabIndex = 5;
            // 
            // chbDecorationPremium
            // 
            this.chbDecorationPremium.AutoSize = true;
            this.chbDecorationPremium.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbDecorationPremium.Location = new System.Drawing.Point(7, 29);
            this.chbDecorationPremium.Name = "chbDecorationPremium";
            this.chbDecorationPremium.Size = new System.Drawing.Size(112, 24);
            this.chbDecorationPremium.TabIndex = 6;
            this.chbDecorationPremium.Text = "Dekoracja ";
            this.chbDecorationPremium.UseVisualStyleBackColor = true;
            // 
            // chbTopperPremium
            // 
            this.chbTopperPremium.AutoSize = true;
            this.chbTopperPremium.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.chbTopperPremium.Location = new System.Drawing.Point(151, 29);
            this.chbTopperPremium.Name = "chbTopperPremium";
            this.chbTopperPremium.Size = new System.Drawing.Size(88, 24);
            this.chbTopperPremium.TabIndex = 7;
            this.chbTopperPremium.Text = "Topper ";
            this.chbTopperPremium.UseVisualStyleBackColor = true;
            // 
            // chbTastePremium
            // 
            this.chbTastePremium.AutoSize = true;
            this.chbTastePremium.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.chbTastePremium.Location = new System.Drawing.Point(260, 29);
            this.chbTastePremium.Name = "chbTastePremium";
            this.chbTastePremium.Size = new System.Drawing.Size(145, 24);
            this.chbTastePremium.TabIndex = 8;
            this.chbTastePremium.Text = "Smak Premium";
            this.chbTastePremium.UseVisualStyleBackColor = true;
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
            this.label1.Size = new System.Drawing.Size(964, 69);
            this.label1.TabIndex = 15;
            this.label1.Text = "UTWÓRZ ZAMÓWIENIE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_CalculatePrice
            // 
            this.btn_CalculatePrice.BackColor = System.Drawing.Color.Salmon;
            this.btn_CalculatePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_CalculatePrice.Location = new System.Drawing.Point(14, 420);
            this.btn_CalculatePrice.Name = "btn_CalculatePrice";
            this.btn_CalculatePrice.Size = new System.Drawing.Size(444, 35);
            this.btn_CalculatePrice.TabIndex = 16;
            this.btn_CalculatePrice.Text = "Usuń z koszyka";
            this.btn_CalculatePrice.UseVisualStyleBackColor = false;
            // 
            // gb_PremiumAdds
            // 
            this.gb_PremiumAdds.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gb_PremiumAdds.Controls.Add(this.chbDecorationPremium);
            this.gb_PremiumAdds.Controls.Add(this.chbTopperPremium);
            this.gb_PremiumAdds.Controls.Add(this.chbTastePremium);
            this.gb_PremiumAdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gb_PremiumAdds.Location = new System.Drawing.Point(26, 127);
            this.gb_PremiumAdds.Name = "gb_PremiumAdds";
            this.gb_PremiumAdds.Size = new System.Drawing.Size(411, 60);
            this.gb_PremiumAdds.TabIndex = 17;
            this.gb_PremiumAdds.TabStop = false;
            this.gb_PremiumAdds.Text = "Dodatki Premium";
            // 
            // btn_NextStep
            // 
            this.btn_NextStep.BackColor = System.Drawing.Color.Green;
            this.btn_NextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_NextStep.Location = new System.Drawing.Point(678, 546);
            this.btn_NextStep.Name = "btn_NextStep";
            this.btn_NextStep.Size = new System.Drawing.Size(278, 51);
            this.btn_NextStep.TabIndex = 18;
            this.btn_NextStep.Text = "Dalej ➔ Przejdź do finalizacji";
            this.btn_NextStep.UseVisualStyleBackColor = false;
            // 
            // btn_CancelOrder
            // 
            this.btn_CancelOrder.BackColor = System.Drawing.Color.Red;
            this.btn_CancelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_CancelOrder.Location = new System.Drawing.Point(12, 546);
            this.btn_CancelOrder.Name = "btn_CancelOrder";
            this.btn_CancelOrder.Size = new System.Drawing.Size(278, 51);
            this.btn_CancelOrder.TabIndex = 19;
            this.btn_CancelOrder.Text = "Anuluj i wyjdź ";
            this.btn_CancelOrder.UseVisualStyleBackColor = false;
            this.btn_CancelOrder.Click += new System.EventHandler(this.btn_CancelOrder_Click);
            // 
            // gb_AddItems
            // 
            this.gb_AddItems.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gb_AddItems.Controls.Add(this.btn_AddToCart);
            this.gb_AddItems.Controls.Add(this.gb_AddCake);
            this.gb_AddItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_AddItems.Location = new System.Drawing.Point(6, 113);
            this.gb_AddItems.Name = "gb_AddItems";
            this.gb_AddItems.Size = new System.Drawing.Size(471, 388);
            this.gb_AddItems.TabIndex = 25;
            this.gb_AddItems.TabStop = false;
            this.gb_AddItems.Text = "Dodaj produkt do zamówienia";
            // 
            // btn_AddToCart
            // 
            this.btn_AddToCart.BackColor = System.Drawing.Color.Salmon;
            this.btn_AddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_AddToCart.Location = new System.Drawing.Point(6, 339);
            this.btn_AddToCart.Name = "btn_AddToCart";
            this.btn_AddToCart.Size = new System.Drawing.Size(452, 37);
            this.btn_AddToCart.TabIndex = 26;
            this.btn_AddToCart.Text = "Dodaj do zamówienia";
            this.btn_AddToCart.UseVisualStyleBackColor = false;
            // 
            // gb_AddCake
            // 
            this.gb_AddCake.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gb_AddCake.Controls.Add(this.cb_Cakes);
            this.gb_AddCake.Controls.Add(this.nup_Cakes);
            this.gb_AddCake.Controls.Add(this.gb_PremiumAdds);
            this.gb_AddCake.Controls.Add(this.lbl_cake);
            this.gb_AddCake.Controls.Add(this.label4);
            this.gb_AddCake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gb_AddCake.Location = new System.Drawing.Point(6, 29);
            this.gb_AddCake.Name = "gb_AddCake";
            this.gb_AddCake.Size = new System.Drawing.Size(452, 304);
            this.gb_AddCake.TabIndex = 28;
            this.gb_AddCake.TabStop = false;
            this.gb_AddCake.Text = "Skonfiguruj wypiek";
            // 
            // nup_Cakes
            // 
            this.nup_Cakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nup_Cakes.Location = new System.Drawing.Point(236, 219);
            this.nup_Cakes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nup_Cakes.Name = "nup_Cakes";
            this.nup_Cakes.Size = new System.Drawing.Size(74, 30);
            this.nup_Cakes.TabIndex = 27;
            this.nup_Cakes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(105, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Podaj ilość";
            // 
            // gb_Cart
            // 
            this.gb_Cart.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gb_Cart.Controls.Add(this.dgv_Cart);
            this.gb_Cart.Controls.Add(this.btn_CalculatePrice);
            this.gb_Cart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_Cart.Location = new System.Drawing.Point(483, 72);
            this.gb_Cart.Name = "gb_Cart";
            this.gb_Cart.Size = new System.Drawing.Size(473, 468);
            this.gb_Cart.TabIndex = 26;
            this.gb_Cart.TabStop = false;
            this.gb_Cart.Text = "Produkty w zamówieniu";
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
            // FormAddOrder_Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(964, 602);
            this.Controls.Add(this.gb_Cart);
            this.Controls.Add(this.gb_AddItems);
            this.Controls.Add(this.btn_CancelOrder);
            this.Controls.Add(this.btn_NextStep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_price);
            this.Name = "FormAddOrder_Step1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddOrder";
            this.gb_PremiumAdds.ResumeLayout(false);
            this.gb_PremiumAdds.PerformLayout();
            this.gb_AddItems.ResumeLayout(false);
            this.gb_AddCake.ResumeLayout(false);
            this.gb_AddCake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Cakes)).EndInit();
            this.gb_Cart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_cake;
        private System.Windows.Forms.ComboBox cb_Cakes;
        private System.Windows.Forms.CheckBox chbDecorationPremium;
        private System.Windows.Forms.CheckBox chbTopperPremium;
        private System.Windows.Forms.CheckBox chbTastePremium;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CalculatePrice;
        private System.Windows.Forms.GroupBox gb_PremiumAdds;
        private System.Windows.Forms.Button btn_NextStep;
        private System.Windows.Forms.Button btn_CancelOrder;
        private System.Windows.Forms.GroupBox gb_AddItems;
        private System.Windows.Forms.NumericUpDown nup_Cakes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_AddCake;
        private System.Windows.Forms.Button btn_AddToCart;
        private System.Windows.Forms.GroupBox gb_Cart;
        private System.Windows.Forms.DataGridView dgv_Cart;
    }
}