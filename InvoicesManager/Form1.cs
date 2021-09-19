using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoicesManager
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = expenses()
                .Select(x => x.Price + ";" + x.Date.ToString("yyyy/MM/dd") + ";" + x.Exptype);

            textBox2.Text = string.Join("\r\n", res);
        }

        public List<exp> expenses()
        {
            string path = textBox1.Text;

            if (System.IO.File.Exists(path) == false)
            {
                MessageBox.Show("not exist");
                return null;
            }

            var allfile = System.IO.File.ReadAllLines(path).Skip(1);

            List<exp> exps = new List<exp>();
            foreach (var l in allfile)
            {
                var split = l.Split(';');
                var price = Convert.ToDouble(split[0].Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                var date = DateTime.ParseExact(split[1], "yyyy-MM-dd", null);
                var type = split[2];



                exp expense = new exp(price, date, type);
                exps.Add(expense);
            }
            return exps;
        }


    }

   
}
