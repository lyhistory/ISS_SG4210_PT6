using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRSClient.LibraryService.ServiceClient client = new CRSClient.LibraryService.ServiceClient();
            int id = int.Parse(bookId.Text);
            CRSClient.LibraryService.Customer customer;
            string aa = client.Borrow(ref id, out customer);
            status.Text = customer.Name;
            message.Text = customer.ID;
            
        }
    }
}
