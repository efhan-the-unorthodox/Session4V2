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
    public partial class BatchNumbers : Form
    {
        public long PID;
        public long WHID;
        public int ST;
        public BatchNumbers(long partID, long warehouseID, int stocktype)
        {
            InitializeComponent();
            PID = partID;
            WHID = warehouseID;
            ST = stocktype;
        }

        private void BatchNumbers_Load(object sender, EventArgs e)
        {
            //retrieve all orderitems according to the part with a batch number
            using (Session4Entities db = new Session4Entities())
            {

                if (ST == 1)
                {
                    var partswithbatchnumbers = db.OrderItems.Where(p => p.PartID == PID && p.Order.SourceWarehouseID == WHID);

                    foreach (var item in partswithbatchnumbers)
                    {
                        object[] row = new object[2];
                        row[0] = item.BatchNumber;
                        row[1] = item.Amount;
                        batchNumberlist.Rows.Add(row);
                    }
                }
                if(ST == 2)
                {
                    var partswithbatchnumbers = db.OrderItems.Where(p => p.PartID == PID && p.Order.DestinationWarehouseID == WHID);

                    foreach (var item in partswithbatchnumbers)
                    {
                        object[] row = new object[2];
                        row[0] = item.BatchNumber;
                        row[1] = item.Amount;
                        batchNumberlist.Rows.Add(row);
                    }
                }
            }
        }
    }
}
