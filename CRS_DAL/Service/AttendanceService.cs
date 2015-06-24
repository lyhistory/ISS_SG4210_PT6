using CRS_DAL.EF;
using CRS_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dm = nus.iss.crs.dm;

namespace CRS_DAL.Service
{
    public class AttendanceService
    {
        IUnitOfWork unitOfWork;

        IRepository<CourseClass> CourseClassRepository;
        IRepository<Course> CourseRepository;
        IRepository<CourseCategory> CourseCategoryRepository;
        IRepository<Participant> ParticipantRepository;
        IRepository<Attendance> AttendanceRepository;
        IRepository<Instructor> InstructorRepository;
        IRepository<Registration> RegistrationRepository;

        public AttendanceService(IUnitOfWork unitOfWork, IRepository<CourseClass> courseClassRepository,
            IRepository<Course> courseRepository,IRepository<CourseCategory> courseCategoryRepository,
            IRepository<Participant> participantRepository,IRepository<Attendance> attendanceRepository,
            IRepository<Instructor> instructorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.CourseClassRepository = courseClassRepository;
            this.CourseRepository = courseRepository;
            this.CourseCategoryRepository = courseCategoryRepository;
            this.ParticipantRepository = participantRepository;
            this.AttendanceRepository = attendanceRepository;
            this.InstructorRepository = instructorRepository;
        }

        public bool SaveParticipantAttendance(string participantID,string courseCode,DateTime classDate,int status,string remark)
        {
            try
            {
                if (string.IsNullOrEmpty(courseCode) || classDate==null||string.IsNullOrEmpty(participantID))
                    return false;
                List<CourseClass> _courseClasslist = CourseClassRepository.GetWhere(x => x.CourseCode.Equals(courseCode)&&x.StartDate<=classDate&&x.EndDate>=classDate).ToList();
                if (_courseClasslist == null || _courseClasslist.Count>1)
                    return false;
                CourseClass _courseClass = _courseClasslist.FirstOrDefault();
                Participant _participant = ParticipantRepository.GetFirstOrDefault(x => x.ParticipantID.Equals(participantID));
                Attendance _attendance = new Attendance();
                _attendance.AttendanceID = Guid.NewGuid().ToString();
                _attendance.ClassID = _courseClass.ClassID;
                _attendance.Status = status;
                _attendance.AttendanceDate = classDate;
                _attendance.Remark = remark;
                AttendanceRepository.Add(_attendance);
                unitOfWork.Commit();

                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        //public List<dm.ParticipantAttendance> GetUserAttendances(string participantID)
        //{
        //    Participant participant=this.ParticipantRepository.GetFirstOrDefault(x=>x.ParticipantID.Equals(participantID));
        //    if(participant==null)
        //        return null;
        //    List<Attendance> attendancelist = this.AttendanceRepository.GetWhere(x => x.ParticipantID.Equals(participantID)).ToList();
        //    IQueryable<CourseClass> courseClasslist=this.CourseClassRepository.GetAll();
        //    IQueryable<Course> courselist=this.CourseRepository.GetAll();
            
        //    return (from attendance in attendancelist
        //                join courseClass in courseClasslist on attendance.ClassID equals courseClass.ClassID
        //                join course in courselist on courseClass.ClassCode equals course.CourseCode
        //                select new dm.ParticipantAttendance(){
        //                Attendant=participant,
        //                ClassDate=attendance.AttendanceDate,
        //                Status=(nus.iss.crs.dm.AttendanceStatus)attendance.Status,


        //}

        public List<dm.ParticipantAttendance> GetUserAttendances(dm.Registration.Participant participant, dm.Course.CourseClass cls)
        {
            return null;
        }
    }
}
