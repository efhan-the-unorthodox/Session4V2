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
    public partial class InventoryManagement : Form
    {
        public Session4Entities db = new Session4Entities();
        public InventoryManagement()
        {
            InitializeComponent();
        }

        private void InventoryManagement_Load(object sender, EventArgs e)
        {
            load_Inventory();
        }
        public void load_Inventory()
        {

            object[] row = new object[8];

            inventoryTable.Rows.Clear();

            var inventory = from o in db.Orders
                            join tt in db.TransactionTypes on o.TransactionTypeID equals tt.ID
                            join oi in db.OrderItems on o.ID equals oi.OrderID
                            join p in db.Parts on oi.PartID equals p.ID
                            orderby o.Date descending
                            orderby tt.ID ascending
                            select new
                            {
                                OrderID = o.ID,
                                PartName = p.Name,
                                TransType = tt.Name,
                                o.Date,
                                Amt = oi.Amount,
                                SourceID = o.SourceWarehouseID,
                                DestID = o.DestinationWarehouseID
                            };

            foreach(var item in inventory)
            {
                if(item.SourceID != null)
                {
                    var sID = item.SourceID;
                    var sw = (from s in db.Warehouses
                              where s.ID == sID
                              select new
                              {
                                  s.Name
                              }).FirstOrDefault();
                    row[4] = sw.Name;
                }
                else
                {
                    row[4] = "-";
                }

                if(item.DestID != null)
                {
                    var dID = item.DestID;
                    var dw = (from d in db.Warehouses
                              where d.ID == dID
                              select new
                              {
                                  d.Name
                              }).FirstOrDefault();
                    row[5] = dw.Name;
                }
                else
                {
                    row[5] = " ";
                }

                row[0] = item.PartName;
                row[1] = item.TransType;
                row[2] = item.Date;
                row[3] = item.Amt;
                row[6] = item.OrderID;
                row[7] = "Edit";
                inventoryTable.Rows.Add(row);
            }
        }

        private void POMlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool notEdit = false;
            PurchaseOrder purchaseOrder = new PurchaseOrder(notEdit, null);
            purchaseOrder.ShowDialog();
            load_Inventory();
        }

        //Method for clicking the link to edit order
        private void inventoryTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {
                long orderid =(long)inventoryTable.Rows[e.RowIndex].Cells[6].Value;
                var getTranstype = db.Orders.Where(order => order.ID == orderid).FirstOrDefault().TransactionTypeID;

                if(getTranstype == 1)
                {
                PurchaseOrder purchaseOrderedit = new PurchaseOrder(true, orderid);
                purchaseOrderedit.ShowDialog();
                }
                else if(getTranstype == 2)
                {
                    WarehouseManagement warehousemanagementedit = new WarehouseManagement(true, orderid);
                    warehousemanagementedit.ShowDialog();
                }
                load_Inventory();
            }
        }

        //Adding Warehouse Management Order
        private void WMlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WarehouseManagement nWM = new WarehouseManagement(false, null);
            nWM.ShowDialog();
        }

        private void IRlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InventoryReport inventoryReport = new InventoryReport();
            inventoryReport.ShowDialog();

        }
    }
}
