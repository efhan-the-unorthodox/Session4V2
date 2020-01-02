namespace Session4V2
{
    partial class InventoryReport
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
            this.warehouseselector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.outOfStockbutton = new System.Windows.Forms.RadioButton();
            this.receivedStockbutton = new System.Windows.Forms.RadioButton();
            this.currentStockButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inventoryReportTable = new System.Windows.Forms.DataGridView();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportTable)).BeginInit();
            this.SuspendLayout();
            // 
            // warehouseselector
            // 
            this.warehouseselector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warehouseselector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehouseselector.FormattingEnabled = true;
            this.warehouseselector.Location = new System.Drawing.Point(20, 44);
            this.warehouseselector.Margin = new System.Windows.Forms.Padding(4);
            this.warehouseselector.Name = "warehouseselector";
            this.warehouseselector.Size = new System.Drawing.Size(412, 26);
            this.warehouseselector.TabIndex = 14;
            this.warehouseselector.SelectedIndexChanged += new System.EventHandler(this.warehouseselector_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Warehouse:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.outOfStockbutton);
            this.panel1.Controls.Add(this.receivedStockbutton);
            this.panel1.Controls.Add(this.currentStockButton);
            this.panel1.Location = new System.Drawing.Point(475, 44);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 60);
            this.panel1.TabIndex = 15;
            // 
            // outOfStockbutton
            // 
            this.outOfStockbutton.AutoSize = true;
            this.outOfStockbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outOfStockbutton.Location = new System.Drawing.Point(379, 22);
            this.outOfStockbutton.Margin = new System.Windows.Forms.Padding(4);
            this.outOfStockbutton.Name = "outOfStockbutton";
            this.outOfStockbutton.Size = new System.Drawing.Size(113, 22);
            this.outOfStockbutton.TabIndex = 2;
            this.outOfStockbutton.TabStop = true;
            this.outOfStockbutton.Text = "Out of Stock";
            this.outOfStockbutton.UseVisualStyleBackColor = true;
            this.outOfStockbutton.CheckedChanged += new System.EventHandler(this.outOfStockbutton_CheckedChanged);
            // 
            // receivedStockbutton
            // 
            this.receivedStockbutton.AutoSize = true;
            this.receivedStockbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receivedStockbutton.Location = new System.Drawing.Point(187, 22);
            this.receivedStockbutton.Margin = new System.Windows.Forms.Padding(4);
            this.receivedStockbutton.Name = "receivedStockbutton";
            this.receivedStockbutton.Size = new System.Drawing.Size(133, 22);
            this.receivedStockbutton.TabIndex = 1;
            this.receivedStockbutton.TabStop = true;
            this.receivedStockbutton.Text = "Received Stock";
            this.receivedStockbutton.UseVisualStyleBackColor = true;
            this.receivedStockbutton.CheckedChanged += new System.EventHandler(this.receivedStockbutton_CheckedChanged);
            // 
            // currentStockButton
            // 
            this.currentStockButton.AutoSize = true;
            this.currentStockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStockButton.Location = new System.Drawing.Point(17, 22);
            this.currentStockButton.Margin = new System.Windows.Forms.Padding(4);
            this.currentStockButton.Name = "currentStockButton";
            this.currentStockButton.Size = new System.Drawing.Size(121, 22);
            this.currentStockButton.TabIndex = 0;
            this.currentStockButton.TabStop = true;
            this.currentStockButton.Text = "Current Stock";
            this.currentStockButton.UseVisualStyleBackColor = true;
            this.currentStockButton.CheckedChanged += new System.EventHandler(this.currentStockButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Inventory Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Result:";
            // 
            // inventoryReportTable
            // 
            this.inventoryReportTable.AllowUserToAddRows = false;
            this.inventoryReportTable.AllowUserToDeleteRows = false;
            this.inventoryReportTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryReportTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventoryReportTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryReportTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartName,
            this.CurrentStock,
            this.ReceivedStock,
            this.Action,
            this.PartID});
            this.inventoryReportTable.Location = new System.Drawing.Point(16, 155);
            this.inventoryReportTable.Margin = new System.Windows.Forms.Padding(4);
            this.inventoryReportTable.Name = "inventoryReportTable";
            this.inventoryReportTable.ReadOnly = true;
            this.inventoryReportTable.RowHeadersWidth = 51;
            this.inventoryReportTable.Size = new System.Drawing.Size(1035, 384);
            this.inventoryReportTable.TabIndex = 18;
            this.inventoryReportTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventoryReportTable_CellContentClick);
            // 
            // PartName
            // 
            this.PartName.HeaderText = "Part Name";
            this.PartName.MinimumWidth = 6;
            this.PartName.Name = "PartName";
            this.PartName.ReadOnly = true;
            // 
            // CurrentStock
            // 
            this.CurrentStock.HeaderText = "Current Stock";
            this.CurrentStock.MinimumWidth = 6;
            this.CurrentStock.Name = "CurrentStock";
            this.CurrentStock.ReadOnly = true;
            // 
            // ReceivedStock
            // 
            this.ReceivedStock.HeaderText = "Received Stock";
            this.ReceivedStock.MinimumWidth = 6;
            this.ReceivedStock.Name = "ReceivedStock";
            this.ReceivedStock.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // PartID
            // 
            this.PartID.HeaderText = "Part ID";
            this.PartID.MinimumWidth = 6;
            this.PartID.Name = "PartID";
            this.PartID.ReadOnly = true;
            this.PartID.Visible = false;
            // 
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.inventoryReportTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.warehouseselector);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InventoryReport";
            this.Text = "InventoryReport";
            this.Load += new System.EventHandler(this.InventoryReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReportTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox warehouseselector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton outOfStockbutton;
        private System.Windows.Forms.RadioButton receivedStockbutton;
        private System.Windows.Forms.RadioButton currentStockButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView inventoryReportTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedStock;
        private System.Windows.Forms.DataGridViewLinkColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartID;
    }
}