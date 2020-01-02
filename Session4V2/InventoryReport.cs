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

            }
        }

        private void warehouseselector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var warehouseID = ((Warehouse)warehouseselector.SelectedItem).ID;
            loadresults(warehouseID);
        }
    }
}
