namespace Session4V2
{
    partial class InventoryManagement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.IRlink = new System.Windows.Forms.LinkLabel();
            this.WMlink = new System.Windows.Forms.LinkLabel();
            this.POMlink = new System.Windows.Forms.LinkLabel();
            this.inventoryTable = new System.Windows.Forms.DataGridView();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actions = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.IRlink);
            this.panel1.Controls.Add(this.WMlink);
            this.panel1.Controls.Add(this.POMlink);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 33);
            this.panel1.TabIndex = 0;
            // 
            // IRlink
            // 
            this.IRlink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IRlink.AutoSize = true;
            this.IRlink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IRlink.Location = new System.Drawing.Point(500, 6);
            this.IRlink.Name = "IRlink";
            this.IRlink.Size = new System.Drawing.Size(116, 18);
            this.IRlink.TabIndex = 1;
            this.IRlink.TabStop = true;
            this.IRlink.Text = "Inventory Report";
            this.IRlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IRlink_LinkClicked);
            // 
            // WMlink
            // 
            this.WMlink.AutoSize = true;
            this.WMlink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WMlink.Location = new System.Drawing.Point(279, 6);
            this.WMlink.Name = "WMlink";
            this.WMlink.Size = new System.Drawing.Size(175, 18);
            this.WMlink.TabIndex = 1;
            this.WMlink.TabStop = true;
            this.WMlink.Text = "Warehouse Management";
            this.WMlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WMlink_LinkClicked);
            // 
            // POMlink
            // 
            this.POMlink.AutoSize = true;
            this.POMlink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POMlink.Location = new System.Drawing.Point(23, 6);
            this.POMlink.Name = "POMlink";
            this.POMlink.Size = new System.Drawing.Size(203, 18);
            this.POMlink.TabIndex = 0;
            this.POMlink.TabStop = true;
            this.POMlink.Text = "Purchase Order Management";
            this.POMlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.POMlink_LinkClicked);
            // 
            // inventoryTable
            // 
            this.inventoryTable.AllowUserToAddRows = false;
            this.inventoryTable.AllowUserToDeleteRows = false;
            this.inventoryTable.AllowUserToOrderColumns = true;
            this.inventoryTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartName,
            this.TransType,
            this.Date,
            this.Amount,
            this.Source,
            this.Destination,
            this.OrderID,
            this.Actions});
            this.inventoryTable.Location = new System.Drawing.Point(5, 44);
            this.inventoryTable.Margin = new System.Windows.Forms.Padding(4);
            this.inventoryTable.Name = "inventoryTable";
            this.inventoryTable.ReadOnly = true;
            this.inventoryTable.RowHeadersWidth = 51;
            this.inventoryTable.Size = new System.Drawing.Size(1057, 495);
            this.inventoryTable.TabIndex = 1;
            this.inventoryTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventoryTable_CellContentClick);
            // 
            // PartName
            // 
            this.PartName.HeaderText = "Part Name";
            this.PartName.MinimumWidth = 6;
            this.PartName.Name = "PartName";
            this.PartName.ReadOnly = true;
            // 
            // TransType
            // 
            this.TransType.HeaderText = "Transaction Type";
            this.TransType.MinimumWidth = 6;
            this.TransType.Name = "TransType";
            this.TransType.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Source
            // 
            this.Source.HeaderText = "Source";
            this.Source.MinimumWidth = 6;
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            // 
            // Destination
            // 
            this.Destination.HeaderText = "Destination";
            this.Destination.MinimumWidth = 6;
            this.Destination.Name = "Destination";
            this.Destination.ReadOnly = true;
            // 
            // OrderID
            // 
            this.OrderID.HeaderText = "OrderID";
            this.OrderID.MinimumWidth = 6;
            this.OrderID.Name = "OrderID";
            this.OrderID.ReadOnly = true;
            this.OrderID.Visible = false;
            // 
            // Actions
            // 
            this.Actions.HeaderText = "Actions";
            this.Actions.MinimumWidth = 6;
            this.Actions.Name = "Actions";
            this.Actions.ReadOnly = true;
            // 
            // InventoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.inventoryTable);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InventoryManagement";
            this.Text = "Inventory Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InventoryManagement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel WMlink;
        private System.Windows.Forms.LinkLabel POMlink;
        private System.Windows.Forms.LinkLabel IRlink;
        private System.Windows.Forms.DataGridView inventoryTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderID;
        private System.Windows.Forms.DataGridViewLinkColumn Actions;
    }
}

