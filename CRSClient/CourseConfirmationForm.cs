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
    public partial class CourseConfirmation : Form
    {
        //CourseConfirmService.CourseClass dataCls = new CourseConfirmService.CourseClass();


        public CourseConfirmation()
        {
            InitializeComponent();

            InitFormData();
        }

        private void InitFormData()
        {
            InitData();

            //foreach (ClassStatus status in Enum.GetValues(typeof(CRSClient.CourseConfirmService.ClassStatus)))
            //{
            //    cboStatus.Items.Add(new CboItem(status.ToString(), status));
            //}

            //txtClassId.Text = dataCls.ClassCode;
            //txtSize.Text = dataCls.Size + "";
            //txtStartDate.Text = dataCls.StartDate.ToString("yyyy-MM-dd");
            //txtEndDate.Text = dataCls.EndDate.ToString("yyyy-MM-dd");
            //cboStatus.Text = dataCls.Status.ToString(); 
        }
        private void InitData()
        {
            //dataCls.ClassCode = "abc";
            //dataCls.StartDate = new DateTime(2015, 7, 2);
            //dataCls.EndDate = new DateTime(2015, 7, 2);
            //dataCls.Size = 5;
            //dataCls.Status = CourseConfirmService.ClassStatus.Open;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            //CourseConfirmService. cls = new CourseConfirmService.RequestConfirmation();

            ////CourseConfirmService.ServiceClient client = new CourseConfirmService.ServiceClient();

            ////dataCls.ClassCode = txtClassId.Text;
            ////dataCls.StartDate = new DateTime(2015, 7, 2);
            ////dataCls.EndDate = new DateTime(2015, 7, 2);
            ////dataCls.Size = 5;
            
            ////cls.courseClass = dataCls;

            //string msg;
            //string status = client.RequestConfirmation(dataCls, out msg);

            //lblStatus.Text  = status;
            //txtMessage.Text = msg;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //CourseConfirmService.ServiceClient client = new CourseConfirmService.ServiceClient();
            //string msg;
            //string status = client.CancelCourseClass(dataCls,out msg);

            //lblStatus.Text = status;
            //txtMessage.Text = msg;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //CourseConfirmService.ServiceClient client = new CourseConfirmService.ServiceClient();

            //string msg;
            //string status = client.ConfirmCourseClass(dataCls, out msg);

            //lblStatus.Text = status;
            //txtMessage.Text = msg;
        }

    

        private void btnPay_Click(object sender, EventArgs e)
        {
            //CourseConfirmService.ServiceClient client = new CourseConfirmService.ServiceClient();

            //string msg;
            //string status = client.MakePayment(dataCls, out msg);

            //lblStatus.Text = status;
            //txtMessage.Text = msg;
        }
    }

    internal class CboItem
    {
        string _Value;
        object _Obj;
        public CboItem(string value) : this(value, null) { }

        public CboItem(string value, object tag)
        {
            _Value = value;
            _Obj = tag;
        }

        public object Tag
        {
            get { return _Obj; }
            set { _Obj = value; }
        }

        public override string ToString()
        {
            return _Value;
        }

    }
}
