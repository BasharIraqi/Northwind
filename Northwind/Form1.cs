using Northwind.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db=new NorthwindContext())
            {
                var save=db.Products.Select(s=> "ProductName: "+s.ProductName+",QuantityPerUnit: " + s.QuantityPerUnit).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new NorthwindContext())
            {
                var save = db.Products.Where(d => d.Discontinued==false).Select(s=> "ProductId: "+s.ProductId+ ",ProductName: " + s.ProductName).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new NorthwindContext())
            {
                var save = db.Products.Where(s=>s.Discontinued==true).Select(d=> "ProductId: "+d.ProductId+ ",ProductName: " + d.ProductName).ToList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new NorthwindContext())
            {
                var save = db.Products.OrderByDescending(order=>order.UnitPrice).Select(d => "ProductName: "+d.ProductName + ",UnitPrice: " + d.UnitPrice).ToList();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var db = new NorthwindContext())
            {
                var save = db.Products.Where(s => s.Discontinued == true && s.UnitPrice<20).Select(d=> "ProductId: "+d.ProductId+ ",ProductName: " + d.ProductName + ",UnitPrice: " + d.UnitPrice).ToList();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using(var db = new NorthwindContext())
            {
                var save = db.Products.Where(value => value.UnitPrice > 15 && value.UnitPrice < 20).Select(s => "ProductId: "+s.ProductId + ",ProductName: " + s.ProductName +",UnitPrice: " + s.UnitPrice).ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var db=new NorthwindContext())
            {
                var save = db.Products.Where(above => above.UnitPrice >db.Products.Average(avg=>avg.UnitPrice)).Select(s => "ProductName: "+s.ProductName + ",UnitPrice: " + s.UnitPrice).ToList();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var db=new NorthwindContext())
            {
                var save = db.Products.Take(10).OrderByDescending(or=>or.UnitPrice).Select(s=> "ProductName: " + s.ProductName+ ",UnitPrice: " + s.UnitPrice).ToList();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var db=new NorthwindContext())
            {
                var save =db.Products.GroupBy(g=>g.Discontinued).Select(s=>s.Count()).ToList();
                        
                        
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (var db=new NorthwindContext())
            {
                var save = db.Products.Where(w => w.UnitsInStock < w.UnitsOnOrder).Select(s => "ProductName: " + s.ProductName + ",UnitsInStock: " + s.UnitsInStock + ",UnitsOnOrder: " + s.UnitsOnOrder).ToList();
            }
        }
    }
}
