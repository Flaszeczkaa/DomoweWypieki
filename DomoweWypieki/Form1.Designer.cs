namespace DomoweWypieki
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Orders = new System.Windows.Forms.Button();
            this.btn_Customers = new System.Windows.Forms.Button();
            this.btn_Cakes = new System.Windows.Forms.Button();
            this.btn_CakesSize = new System.Windows.Forms.Button();
            this.btn_Payments = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_raports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(956, 90);
            this.label1.TabIndex = 0;
            this.label1.Text = "SYSTEM ZARZĄDZANIA CUKIERNIĄ\r\nDOMOWE WYPIEKI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Orders
            // 
            this.btn_Orders.BackColor = System.Drawing.Color.Salmon;
            this.btn_Orders.FlatAppearance.BorderSize = 0;
            this.btn_Orders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Orders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Orders.Location = new System.Drawing.Point(137, 125);
            this.btn_Orders.Name = "btn_Orders";
            this.btn_Orders.Size = new System.Drawing.Size(285, 75);
            this.btn_Orders.TabIndex = 1;
            this.btn_Orders.Text = "🛒 ZAMÓWIENIA";
            this.btn_Orders.UseVisualStyleBackColor = false;
            this.btn_Orders.Click += new System.EventHandler(this.btn_Orders_Click);
            // 
            // btn_Customers
            // 
            this.btn_Customers.BackColor = System.Drawing.Color.Salmon;
            this.btn_Customers.FlatAppearance.BorderSize = 0;
            this.btn_Customers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Customers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Customers.Location = new System.Drawing.Point(549, 125);
            this.btn_Customers.Name = "btn_Customers";
            this.btn_Customers.Size = new System.Drawing.Size(285, 75);
            this.btn_Customers.TabIndex = 7;
            this.btn_Customers.Text = "👥 KLIENCI";
            this.btn_Customers.UseVisualStyleBackColor = false;
            // 
            // btn_Cakes
            // 
            this.btn_Cakes.BackColor = System.Drawing.Color.Salmon;
            this.btn_Cakes.FlatAppearance.BorderSize = 0;
            this.btn_Cakes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cakes.Location = new System.Drawing.Point(137, 241);
            this.btn_Cakes.Name = "btn_Cakes";
            this.btn_Cakes.Size = new System.Drawing.Size(285, 75);
            this.btn_Cakes.TabIndex = 8;
            this.btn_Cakes.Text = "🍰 KATALOG CIAST";
            this.btn_Cakes.UseVisualStyleBackColor = false;
            // 
            // btn_CakesSize
            // 
            this.btn_CakesSize.BackColor = System.Drawing.Color.Salmon;
            this.btn_CakesSize.FlatAppearance.BorderSize = 0;
            this.btn_CakesSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CakesSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_CakesSize.Location = new System.Drawing.Point(549, 241);
            this.btn_CakesSize.Name = "btn_CakesSize";
            this.btn_CakesSize.Size = new System.Drawing.Size(285, 75);
            this.btn_CakesSize.TabIndex = 9;
            this.btn_CakesSize.Text = "🎂 ROZMIARY TORTÓW";
            this.btn_CakesSize.UseVisualStyleBackColor = false;
            // 
            // btn_Payments
            // 
            this.btn_Payments.BackColor = System.Drawing.Color.Salmon;
            this.btn_Payments.FlatAppearance.BorderSize = 0;
            this.btn_Payments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Payments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Payments.Location = new System.Drawing.Point(549, 352);
            this.btn_Payments.Name = "btn_Payments";
            this.btn_Payments.Size = new System.Drawing.Size(285, 75);
            this.btn_Payments.TabIndex = 11;
            this.btn_Payments.Text = "💳 PŁATNOŚCI";
            this.btn_Payments.UseVisualStyleBackColor = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Exit.Location = new System.Drawing.Point(727, 492);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(203, 49);
            this.btn_Exit.TabIndex = 12;
            this.btn_Exit.Text = "WYJŚCIE";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_raports
            // 
            this.btn_raports.BackColor = System.Drawing.Color.Salmon;
            this.btn_raports.FlatAppearance.BorderSize = 0;
            this.btn_raports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_raports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_raports.Location = new System.Drawing.Point(137, 352);
            this.btn_raports.Name = "btn_raports";
            this.btn_raports.Size = new System.Drawing.Size(285, 75);
            this.btn_raports.TabIndex = 13;
            this.btn_raports.Text = "🍰 RAPORTY";
            this.btn_raports.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 571);
            this.Controls.Add(this.btn_raports);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Payments);
            this.Controls.Add(this.btn_CakesSize);
            this.Controls.Add(this.btn_Cakes);
            this.Controls.Add(this.btn_Customers);
            this.Controls.Add(this.btn_Orders);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Orders;
        private System.Windows.Forms.Button btn_Customers;
        private System.Windows.Forms.Button btn_Cakes;
        private System.Windows.Forms.Button btn_CakesSize;
        private System.Windows.Forms.Button btn_Payments;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_raports;
    }
}

