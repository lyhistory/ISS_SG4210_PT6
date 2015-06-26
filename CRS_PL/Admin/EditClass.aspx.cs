using nus.iss.crs.bl;
using nus.iss.crs.dm.Course;
using nus.iss.crs.pl.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nus.iss.crs.pl.Admin
{
    public partial class EditClass : CrsPageController
    {

        //private CourseCategory selectedCategory = null;
        //private CourseInstructor selectedInstructor = null;
        CourseManager manager = null;
        ClassManager classManager = null;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (this.IsPostBack)
                return;
            PopulateCategoryDetail();
        }

        private void PopulateCategoryDetail()
        {
            manager = BLSession.CreateCourseManager();
            classManager = BLSession.CreateClassManager();

            foreach (CourseCategory category in manager.GetCourseCategoryList())
            {
                ListItem item = new ListItem(category.Name, category.ID);
                categoryList.Items.Add(item);
            }

            CourseClass courseClass = classManager.GetCourseClassByCode(this.Request.QueryString.Get(CRSConstant.ParameterClassCode));
            categoryList.Text = courseClass.CourseObj.Category.Name;
            courseList.Text = courseClass.CourseObj.CourseTitle;
            classCode.Text = courseClass.ClassCode;
            sizeID.Text = courseClass.Size.ToString();
            startDateID.Text = courseClass.StartDate.ToString();
            endDateID.Text = courseClass.EndDate.ToString();
        }

        private void PopulateCourseDetail(CourseCategory courseCategory)
        {
            foreach (Course course in manager.GetCourseListByCategory(courseCategory))
            {
                ListItem item = new ListItem(course.CourseTitle, course.Code);
                courseList.Items.Add(item);
            }
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = categoryList.SelectedItem;
            if (item == null)
                return;

            CourseManager manager = BLSession.CreateCourseManager();
            List<CourseCategory> courseCategoryList = manager.GetCourseCategoryList();
            foreach (CourseCategory courseCategory in courseCategoryList)
            {
                if (courseCategory.ID == item.Value)
                {
                    PopulateCourseDetail(courseCategory);
                }
            }
        }

        public override void RegistraterAction()
        {
            RegistraterActionTarget((AdminAction)ClassAdminAction.Save, typeof(ListClassInCourse));
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            currentAction = (AdminAction)CourseAdminAction.Save;
            CourseManager courseManager = BLSession.CreateCourseManager();
            ListItem itemCategory = categoryList.SelectedItem;

            ListItem item = courseList.SelectedItem;
            Course selectedCourse = manager.GetCourseByCode(item.Value);

            CourseClass tempClass = new CourseClass(selectedCourse);
            tempClass.ClassCode = classCode.Text;
            tempClass.Size = int.Parse(sizeID.Text);
            tempClass.StartDate = DateTime.Parse(startDateID.Text);
            tempClass.EndDate = DateTime.Parse(endDateID.Text);
            classManager.CreateCourseClass(tempClass);
            NextPage(true);
        }

        protected void Back_Click(object sender, EventArgs e)
        {

        }
    }
}