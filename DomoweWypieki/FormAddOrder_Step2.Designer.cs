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
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.lbl_client = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_order_date = new System.Windows.Forms.Label();
            this.lbl_realization = new System.Windows.Forms.Label();
            this.dtpRealizationDate = new System.Windows.Forms.DateTimePicker();
            this.gb_OrderData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
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
            this.gb_OrderData.Location = new System.Drawing.Point(21, 42);
            this.gb_OrderData.Name = "gb_OrderData";
            this.gb_OrderData.Size = new System.Drawing.Size(465, 147);
            this.gb_OrderData.TabIndex = 25;
            this.gb_OrderData.TabStop = false;
            this.gb_OrderData.Text = "Dane Zamówienia";
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
            // FormAddOrder_Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 566);
            this.Controls.Add(this.gb_OrderData);
            this.Name = "FormAddOrder_Step2";
            this.Text = "FormAddOrder_Step2";
            this.gb_OrderData.ResumeLayout(false);
            this.gb_OrderData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_OrderData;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Label lbl_client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lbl_order_date;
        private System.Windows.Forms.Label lbl_realization;
        private System.Windows.Forms.DateTimePicker dtpRealizationDate;
    }
}