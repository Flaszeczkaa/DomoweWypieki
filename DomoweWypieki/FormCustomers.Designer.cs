namespace DomoweWypieki
{
    partial class FormCustomers
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomers));
            this.bn_clients = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.lbl_search_criteria = new System.Windows.Forms.Label();
            this.btn_return = new System.Windows.Forms.Button();
            this.btn_delete_customer = new System.Windows.Forms.Button();
            this.btn_add_customer = new System.Windows.Forms.Button();
            this.dgv_customers = new System.Windows.Forms.DataGridView();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search_user = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bn_clients)).BeginInit();
            this.bn_clients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customers)).BeginInit();
            this.SuspendLayout();
            // 
            // bn_clients
            // 
            this.bn_clients.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bn_clients.CountItem = this.bindingNavigatorCountItem;
            this.bn_clients.DeleteItem = null;
            this.bn_clients.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bn_clients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bn_clients.Location = new System.Drawing.Point(0, 0);
            this.bn_clients.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn_clients.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn_clients.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn_clients.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn_clients.Name = "bn_clients";
            this.bn_clients.PositionItem = this.bindingNavigatorPositionItem;
            this.bn_clients.Size = new System.Drawing.Size(956, 27);
            this.bn_clients.TabIndex = 28;
            this.bn_clients.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Visible = false;
            // 
            // lbl_search_criteria
            // 
            this.lbl_search_criteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_search_criteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_search_criteria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_search_criteria.Location = new System.Drawing.Point(57, 129);
            this.lbl_search_criteria.Name = "lbl_search_criteria";
            this.lbl_search_criteria.Size = new System.Drawing.Size(826, 41);
            this.lbl_search_criteria.TabIndex = 27;
            this.lbl_search_criteria.Text = "Podaj  kryteria wyszukiwania: Imię, Nazwisko, E-mail";
            this.lbl_search_criteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_search_criteria.Click += new System.EventHandler(this.lbl_search_criteria_Click);
            // 
            // btn_return
            // 
            this.btn_return.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_return.BackColor = System.Drawing.Color.Salmon;
            this.btn_return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_return.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_return.Location = new System.Drawing.Point(25, 513);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(226, 47);
            this.btn_return.TabIndex = 26;
            this.btn_return.Text = "Wróć";
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // btn_delete_customer
            // 
            this.btn_delete_customer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_delete_customer.BackColor = System.Drawing.Color.Salmon;
            this.btn_delete_customer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_delete_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_delete_customer.Location = new System.Drawing.Point(355, 513);
            this.btn_delete_customer.Name = "btn_delete_customer";
            this.btn_delete_customer.Size = new System.Drawing.Size(231, 47);
            this.btn_delete_customer.TabIndex = 25;
            this.btn_delete_customer.Text = "Usuń klienta";
            this.btn_delete_customer.UseVisualStyleBackColor = false;
            this.btn_delete_customer.Click += new System.EventHandler(this.btn_delete_customer_Click);
            // 
            // btn_add_customer
            // 
            this.btn_add_customer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_add_customer.BackColor = System.Drawing.Color.Salmon;
            this.btn_add_customer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_add_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_add_customer.Location = new System.Drawing.Point(711, 513);
            this.btn_add_customer.Name = "btn_add_customer";
            this.btn_add_customer.Size = new System.Drawing.Size(216, 47);
            this.btn_add_customer.TabIndex = 24;
            this.btn_add_customer.Text = "Dodaj klienta";
            this.btn_add_customer.UseVisualStyleBackColor = false;
            this.btn_add_customer.Click += new System.EventHandler(this.btn_add_customer_Click);
            // 
            // dgv_customers
            // 
            this.dgv_customers.AllowUserToAddRows = false;
            this.dgv_customers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_customers.Location = new System.Drawing.Point(25, 226);
            this.dgv_customers.Name = "dgv_customers";
            this.dgv_customers.ReadOnly = true;
            this.dgv_customers.RowHeadersVisible = false;
            this.dgv_customers.RowHeadersWidth = 51;
            this.dgv_customers.RowTemplate.Height = 24;
            this.dgv_customers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_customers.Size = new System.Drawing.Size(902, 281);
            this.dgv_customers.TabIndex = 23;
            this.dgv_customers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_customers_CellDoubleClick);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_search.BackColor = System.Drawing.Color.Salmon;
            this.btn_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(726, 173);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(201, 47);
            this.btn_search.TabIndex = 22;
            this.btn_search.Text = "Szukaj";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search_user
            // 
            this.txt_search_user.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_search_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_search_user.Location = new System.Drawing.Point(25, 181);
            this.txt_search_user.Name = "txt_search_user";
            this.txt_search_user.Size = new System.Drawing.Size(695, 30);
            this.txt_search_user.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 22);
            this.textBox1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(956, 90);
            this.label1.TabIndex = 19;
            this.label1.Text = "ZARZĄDZANIE KLIENTAMI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 571);
            this.Controls.Add(this.bn_clients);
            this.Controls.Add(this.lbl_search_criteria);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_delete_customer);
            this.Controls.Add(this.btn_add_customer);
            this.Controls.Add(this.dgv_customers);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search_user);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormCustomers";
            this.Text = "FormClients";
            ((System.ComponentModel.ISupportInitialize)(this.bn_clients)).EndInit();
            this.bn_clients.ResumeLayout(false);
            this.bn_clients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bn_clients;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.Label lbl_search_criteria;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Button btn_delete_customer;
        private System.Windows.Forms.Button btn_add_customer;
        private System.Windows.Forms.DataGridView dgv_customers;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_search_user;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}