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
    public partial class WarehouseManagement : Form
    {
        public class parts
        {
            public string partname { get; set; }
            public string batchnumber { get; set; }
            public decimal amount { get; set; }
            public long partid { get; set; }
        }
        public bool edit;
        public long? OID;

        public List<parts> listofparts = new List<parts>();

        public Dictionary<long, string> partorderitems = new Dictionary<long, string>();
        public WarehouseManagement(bool Edit, long? orderid)
        {
            InitializeComponent();
            edit = Edit;
            OID = orderid;
        }

        private void WarehouseManagement_Load(object sender, EventArgs e)
        {
            using (Session4Entities db = new Session4Entities())
            {
                var warehouselist = db.Warehouses.ToList();
                var partslist = db.Parts.ToList();

                sourcewarehousebox.DataSource = new BindingSource(warehouselist, null);
                sourcewarehousebox.DisplayMember = "Name";
                sourcewarehousebox.ValueMember = "ID";

                destinationwarehousebox.DataSource = new BindingSource(warehouselist, null);
                destinationwarehousebox.DisplayMember = "Name";
                destinationwarehousebox.ValueMember = "ID";

                partsbox.DataSource = new BindingSource(partslist, null);
                partsbox.DisplayMember = "Name";
                partsbox.ValueMember = "ID";

                //foreach(var item in partslist)
                //{
                //    partorderitems.Add(item.ID, item.Name);
                //}
                //partsbox.DataSource = new BindingSource(partorderitems, null);
                //partsbox.DisplayMember = "Value";
                //partsbox.ValueMember = "Key";
                

                if(edit == true)
                {
                    //get existing warehouse order details
                    var warehouseorder = db.Orders.Where(order => order.ID == OID).FirstOrDefault();
                    foreach(var item in sourcewarehousebox.Items)
                    {
                        var selecteditem = (Warehouse)item;
                        if(selecteditem.ID == warehouseorder.SourceWarehouseID)
                        {
                            sourcewarehousebox.SelectedItem = item;
                        }
                    }
                    foreach(var item in destinationwarehousebox.Items)
                    {
                        var selecteditem = (Warehouse)item;
                        if(selecteditem.ID == warehouseorder.DestinationWarehouseID)
                        {
                            destinationwarehousebox.SelectedItem = item;
                        }
                    }
                    dateTimePicker1.Value = warehouseorder.Date;
                    //Retrieving all  existing orderitems
                    var existingorderitems = db.OrderItems.Where(orderitem => orderitem.OrderID == OID).ToList();
                    foreach(var item in existingorderitems)
                    {
                        parts expts = new parts();
                        expts.partid = item.PartID;
                        expts.partname = item.Part.Name;
                        expts.amount = item.Amount;
                        expts.batchnumber = item.BatchNumber;
                        listofparts.Add(expts);
                    }
                    showParts();

                }

            }

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            switch (edit)
            {
                case true:
                    editWarehouseOrder();
                    break;
                case false:
                    newWarehouseOrder();
                    break;
                default:
                    newWarehouseOrder();
                    break;
            }
        }
        private void showParts()
        {
            partsTable.Rows.Clear();
            foreach(var item in listofparts)
            {
                object[] row = new object[5];
                row[0] = item.partname;
                row[1] = item.batchnumber;
                row[2] = item.amount;
                row[3] = "Remove";
                row[4] = item.partid;

                partsTable.Rows.Add(row);
            }
        }

        private void editWarehouseOrder()
        {
            using(Session4Entities db = new Session4Entities())
            {
                var swid = ((Warehouse)sourcewarehousebox.SelectedItem).ID;
                var dwid = ((Warehouse)destinationwarehousebox.SelectedItem).ID;
                var date = Convert.ToDateTime(dateTimePicker1.Value);

                //retrieving existing warehouse order
                var existingwarehouseorder = db.Orders.Where(a => a.ID == OID).FirstOrDefault();
                existingwarehouseorder.SourceWarehouseID = swid;
                existingwarehouseorder.DestinationWarehouseID = dwid;
                existingwarehouseorder.Date = date;

                //retrieving existing orderitems related to the order
                var existingwarehouseorderitems = db.OrderItems.Where(oit => oit.OrderID == OID).ToList();
                foreach(var item in existingwarehouseorderitems)
                {
                    db.OrderItems.Remove(item);
                }
                foreach(var item in listofparts)
                {
                    OrderItem newOrderitem = new OrderItem();
                    newOrderitem.OrderID = (long)OID;
                    newOrderitem.PartID = item.partid;
                    newOrderitem.BatchNumber = item.batchnumber;
                    newOrderitem.Amount = item.amount;
                    db.OrderItems.Add(newOrderitem);
                }
                try
                {
                    db.SaveChanges();
                    db.Dispose();
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Whoops, an error has occured. Error Message: " + error.ToString());
                }

            }
        }
        private void newWarehouseOrder()
        {
            using (Session4Entities db = new Session4Entities())
            {

                var swid = ((Warehouse)sourcewarehousebox.SelectedItem).ID;
                var dwid = ((Warehouse)destinationwarehousebox.SelectedItem).ID;
                var date = Convert.ToDateTime(dateTimePicker1.Value);

                Order newOrder = new Order();
                newOrder.SourceWarehouseID = swid;
                newOrder.DestinationWarehouseID = dwid;
                newOrder.TransactionTypeID = 2;
                newOrder.Supplier = null;
                newOrder.Date = date;
                db.Orders.Add(newOrder);
                foreach (var item in listofparts)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.OrderID = newOrder.ID;
                    orderItem.PartID = item.partid;
                    orderItem.BatchNumber = item.batchnumber;
                    orderItem.Amount = item.amount;
                    db.OrderItems.Add(orderItem);
                }
                try
                {
                    db.SaveChanges();
                    db.Dispose();
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Whoops, an Error has occured. Error Message: " + error.ToString());
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addpartbtn_Click(object sender, EventArgs e)
        {
            //getting selected part
            var selectedPart = (Part)partsbox.SelectedItem;
            if(amountbox.Value == 0)
            {
                MessageBox.Show("Please enter a valid amount");
            }
            else if(selectedPart.BatchNumberHasRequired == true && batchnumberbox.Text.Length == 0)
            {
                MessageBox.Show("Batch Number is required for this part");
            }
            else
            {
                var amount = amountbox.Value;
                var batchnumber = batchnumberbox.Text;
                parts addPart = new parts();
                addPart.partid = selectedPart.ID;
                addPart.partname = selectedPart.Name;
                addPart.amount = amount;
                addPart.batchnumber = batchnumber;
                listofparts.Add(addPart);
                showParts();
            }

        }

        private void partsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                var partIndex = e.RowIndex;
                listofparts.RemoveAt(partIndex);
                showParts();
            }
        }
    }
}
