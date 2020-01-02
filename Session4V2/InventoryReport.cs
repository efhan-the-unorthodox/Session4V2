using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session4V2
{
    public partial class InventoryReport : Form
    {
        public int stockType = new int();
        public long WHID = new long();
        public InventoryReport()
        {
            InitializeComponent();
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            using (Session4Entities db = new Session4Entities())
            {
                currentStockButton.Checked = true;
                //getting list of warehouses and placing them in the warehouse dropdownlist
                var warehouses = db.Warehouses.ToList();
                warehouseselector.DataSource = new BindingSource(warehouses, null);
                warehouseselector.DisplayMember = "Name";
                warehouseselector.ValueMember = "ID";
            }
            long whID = ((Warehouse)warehouseselector.SelectedItem).ID;
            loadresults(whID);
        }
        void loadresults(long warehouseID)
        {

            //loading current stock in the warehouse
            using (Session4Entities db = new Session4Entities())
            {
                if (currentStockButton.Checked)
                {
                    stockType = 1;
                    var getcurrentstock = db.OrderItems.Where(a => a.Order.SourceWarehouseID == warehouseID);
                    var warehouses = db.Warehouses;
                    inventoryReportTable.Rows.Clear();
                    foreach (var item in getcurrentstock.Select(a => a.Part.Name).Distinct())
                    {
                        object[] row = new object[5];
                        var pD = db.Parts.Where(p => p.Name == item).First();
                        var currentStock = db.OrderItems.Where(a => a.PartID == pD.ID && a.Order.SourceWarehouseID == warehouseID).Select(a => a.Amount).Sum();
                        row[0] = item;
                        row[1] = currentStock;
                        if (pD.BatchNumberHasRequired.Equals(true))
                        {
                            row[3] = "View Batch Numbers";
                        }
                        row[4] = pD.ID;
                        inventoryReportTable.Rows.Add(row);
                    }
                    inventoryReportTable.Columns[1].Visible = true;
                    inventoryReportTable.Columns[2].Visible = false;
                    inventoryReportTable.Columns[3].Visible = true;
                }
                else if (receivedStockbutton.Checked)
                {
                    stockType = 2;
                    var getcurrentstock = db.OrderItems.Where(a => a.Order.DestinationWarehouseID == warehouseID);
                    inventoryReportTable.Rows.Clear();
                    foreach (var item in getcurrentstock.Select(a => a.Part.Name).Distinct())
                    {
                        object[] row = new object[5];
                        var pD = db.Parts.Where(p => p.Name == item).First();
                        var currentStock = db.OrderItems.Where(a => a.PartID == pD.ID && a.Order.DestinationWarehouseID == warehouseID).Select(a => a.Amount).Sum();
                        row[0] = item;
                        row[2] = currentStock;
                        if (pD.BatchNumberHasRequired.Equals(true))
                        {
                            row[3] = "View Batch Numbers";
                        }
                        row[4] = pD.ID;
                        inventoryReportTable.Rows.Add(row);
                    }
                    inventoryReportTable.Columns[1].Visible = false;
                    inventoryReportTable.Columns[2].Visible = true;
                    inventoryReportTable.Columns[3].Visible = true;
                }
                else
                {
                    stockType = 3;
                    var getAllStock = db.OrderItems;
                    inventoryReportTable.Rows.Clear();
                    foreach(var item in getAllStock.Select(a => a.Part.Name).Distinct())
                    {
                        var pD = db.Parts.Where(p => p.Name == item).First();
                        if(db.OrderItems.Where(p=>p.PartID == pD.ID && p.Order.SourceWarehouseID == warehouseID).FirstOrDefault() != null)
                        {
                            var currentStockCount = db.OrderItems.Where(x => x.PartID ==pD.ID && x.Order.SourceWarehouseID == warehouseID).Select(x => x.Amount).Sum();
                            var receivingStockCount = db.OrderItems.Where(x => x.PartID == pD.ID && x.Order.DestinationWarehouseID == warehouseID).Select(x => x.Amount).Sum();

                            if((currentStockCount - receivingStockCount) <= 0)
                            {
                                inventoryReportTable.Rows.Add(item);
                            }
                            inventoryReportTable.Columns[1].Visible = false;
                            inventoryReportTable.Columns[2].Visible = false;
                            inventoryReportTable.Columns[3].Visible = false;
                        }
                    }
                }

            }
        }

        private void warehouseselector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var warehouseID = ((Warehouse)warehouseselector.SelectedItem).ID;
            WHID = warehouseID;
            loadresults(warehouseID);
        }

        private void inventoryReportTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var partID = inventoryReportTable.Rows[e.RowIndex].Cells[4].Value;
                BatchNumbers batchNumbers = new BatchNumbers(Convert.ToInt64(partID), WHID, stockType);
                batchNumbers.ShowDialog();
            }
        }

        private void currentStockButton_CheckedChanged(object sender, EventArgs e)
        {
            loadresults(WHID);
        }

        private void receivedStockbutton_CheckedChanged(object sender, EventArgs e)
        {
            loadresults(WHID);
        }

        private void outOfStockbutton_CheckedChanged(object sender, EventArgs e)
        {
            loadresults(WHID);
        }
    }
}
