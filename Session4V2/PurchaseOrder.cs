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
    public partial class PurchaseOrder : Form
    {
        public Session4Entities db = new Session4Entities();

        public EventHandler refreshForm;

        public bool edit;
        public bool BatchNumberRequired;
        public List<parts> listofparts = new List<parts>();

        public long newOrderID;

        public long? OID;

        public class parts
        {
            public string partname { get; set; }
            public string batchnumber { get; set; }
            public decimal amount { get; set; }
            public long partid { get; set; }
        }


        public PurchaseOrder(bool isEdit, long? orderid)
        {
            InitializeComponent();
            edit = isEdit;
            OID = orderid;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            //get list of suppliers
            var supplierlist = db.Suppliers;
            var warehouselist = db.Warehouses;
            var partslist = db.Parts;


            Dictionary<long, string> supplier = new Dictionary<long, string>();
            Dictionary<long, string> warehouses = new Dictionary<long, string>();
            Dictionary<long, string> parts = new Dictionary<long, string>();
            foreach (var s in supplierlist)
            {
                supplier.Add(s.ID, s.Name);
            }
            foreach (var w in warehouselist)
            {
                warehouses.Add(w.ID, w.Name);
            }

            foreach (var p in partslist)
            {
                parts.Add(p.ID, p.Name);
            }

            supplierbox.DataSource = new BindingSource(supplier, null);
            supplierbox.DisplayMember = "Value";
            supplierbox.ValueMember = "Key";

            warehousebox.DataSource = new BindingSource(warehouses, null);
            warehousebox.DisplayMember = "Value";
            warehousebox.ValueMember = "Key";

            partsBox.DataSource = new BindingSource(parts, null);
            partsBox.DisplayMember = "Value";
            partsBox.ValueMember = "Key";

            if (edit == true)
            {
                //retrieve existing orderitems that are associated with the purchase order
                using (Session4Entities db = new Session4Entities())
                {
                    var getOrderDetails = db.Orders.Where(po => po.ID == OID).FirstOrDefault();
                    var getexistingOrderitems = db.OrderItems.Where(order => order.OrderID == OID);
                    var supplierId = getOrderDetails.SupplierID;
                    var destinationwarehouseid = getOrderDetails.DestinationWarehouseID;
                    foreach (var item in supplierbox.Items)
                    {
                        var s = ((KeyValuePair<long, string>)item).Key;
                        if (s == supplierId)
                        {
                            supplierbox.SelectedItem = item;
                        }
                    }
                    foreach (var item in warehousebox.Items)
                    {
                        var wh = ((KeyValuePair<long, string>)item).Key;
                        if (wh == destinationwarehouseid)
                        {
                            warehousebox.SelectedItem = item;
                        }
                    }
                    foreach (var item in getexistingOrderitems)
                    {
                        parts expts = new parts();
                        expts.partid = item.PartID;
                        expts.amount = item.Amount;
                        expts.batchnumber = item.BatchNumber;
                        expts.partname = item.Part.Name;
                        listofparts.Add(expts);
                    }
                    dateTimePicker1.Value = getOrderDetails.Date;
                    showParts(sender, e);

                }
            }



        }
        private void EditPurchaseOrder(object sender, EventArgs e)
        {
            //get supplierID
            long supplierid = ((KeyValuePair<long, string>)supplierbox.SelectedItem).Key;
            //get destinationwarehouseid
            long destwarehouseid = ((KeyValuePair<long, string>)warehousebox.SelectedItem).Key;
            //getting date
            DateTime date = dateTimePicker1.Value;
            var existingpurchaseorder = db.Orders.Where(o => o.ID == OID).FirstOrDefault();
            existingpurchaseorder.SupplierID = supplierid;
            existingpurchaseorder.DestinationWarehouseID = destwarehouseid;
            existingpurchaseorder.Date = date;

            //Delete all orderitems associated with this order being edited
            var existingorderitems = db.OrderItems.Where(oit => oit.OrderID == OID).ToList();
            foreach(var item in existingorderitems)
            {
                db.OrderItems.Remove(item);
            }
            foreach(var item in listofparts)
            {
                OrderItem neworderitems = new OrderItem();
                neworderitems.OrderID = (long)OID;
                neworderitems.PartID = item.partid;
                neworderitems.BatchNumber = item.batchnumber;
                neworderitems.Amount = item.amount;
                db.OrderItems.Add(neworderitems);
            }
            try
            {
                db.SaveChanges();
                MessageBox.Show("Your changes have been saved");
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Unable to save changes. Report this error to technician: " + error.ToString());
            }
        }

        private void partsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPart = (KeyValuePair<long, string>)partsBox.SelectedItem;
            var partDetails = db.Parts.Where(p => p.ID == selectedPart.Key).FirstOrDefault();
            if (partDetails.BatchNumberHasRequired == true)
            {
                BatchNumberRequired = true;
                batchrequired.Text = "Batch number is required";
                batchrequired.Visible = true;
            }
            else
            {
                BatchNumberRequired = false;
                batchrequired.Visible = false;
            }

        }

        private void addpartbtn_Click(object sender, EventArgs e)
        {
            if (BatchNumberRequired == true && batchnumberbox.Text.Length == 0)
            {
                MessageBox.Show("Batch number is required");
            }
            else if (amountbox.Value == 0)
            {
                MessageBox.Show("Please enter a valid amount");
            }
            else
            {
                var selectedItem = (KeyValuePair<long, string>)partsBox.SelectedItem;
                parts newPart = new parts();
                newPart.partname = selectedItem.Value;
                newPart.batchnumber = batchnumberbox.Text;
                newPart.amount = amountbox.Value;
                newPart.partid = selectedItem.Key;
                Console.WriteLine("Hello");
                listofparts.Add(newPart);

                showParts(sender, e);
            }
        }
        private void showParts(object sender, EventArgs e)
        {
            partsTable.ColumnCount = 4;
            partsTable.Columns[0].Name = "Part Name";
            partsTable.Columns[1].Name = "Batch Number";
            partsTable.Columns[2].Name = "Amount";
            partsTable.Columns[3].Name = "Part ID";
            partsTable.Columns[3].Visible = false;
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            partsTable.Columns.Add(lnk);
            lnk.HeaderText = "Actions";
            lnk.Name = "Remove";
            lnk.Text = "Remove";
            lnk.UseColumnTextForLinkValue = true;

            partsTable.Rows.Clear();

            foreach (var part in listofparts)
            {
                object[] row = new object[] { part.partname, part.batchnumber, part.amount, part.partid };

                partsTable.Rows.Add(row);
            }

        }

        private void partsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var partIndex = e.RowIndex;

                listofparts.RemoveAt(partIndex);
                this.showParts(sender, e);
            }
        }

        private void createNewOrder(object sender, EventArgs e)
        {
            //Getting Order details from the view
            var destination_warehouse = ((KeyValuePair<long, string>)warehousebox.SelectedItem).Key;
            var supplier_id = ((KeyValuePair<long, string>)supplierbox.SelectedItem).Key;

            Order newOrder = new Order();
            newOrder.TransactionTypeID = 1;
            newOrder.SupplierID = Convert.ToInt64(supplier_id);
            newOrder.SourceWarehouseID = null;
            newOrder.DestinationWarehouseID = Convert.ToInt64(destination_warehouse);
            newOrder.Date = Convert.ToDateTime(dateTimePicker1.Value).Date;

            db.Orders.Add(newOrder);
            long ordernum = newOrder.ID;
            foreach (var part in listofparts)
            {
                OrderItem orderitem = new OrderItem();
                orderitem.OrderID = ordernum;
                orderitem.PartID = part.partid;
                orderitem.BatchNumber = part.batchnumber;
                orderitem.Amount = part.amount;
                db.OrderItems.Add(orderitem);
            }
            try
            {
                db.SaveChanges();
                db.Dispose();
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("An Error has occured. Details: " + error.Message);
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            switch (edit)
            {
                case false:
                    createNewOrder(sender, e);
                    break;
                case true:
                    EditPurchaseOrder(sender, e);
                    break;
                default:
                    createNewOrder(sender, e);
                    break;
            }
        }
    }
}
