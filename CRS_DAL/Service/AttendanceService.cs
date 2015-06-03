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

        public dm.Attendance CreateAttendance(dm.Course.CourseClass cls)
        {
            return null;
        }

        public bool SaveAttendance(dm.Attendance attendance)
        {
            return false;
        }

        public List<dm.ParticipantAttendance> GetUserAttendances(dm.Registration.Participant participant)
        {
            return null;
        }

        public List<dm.ParticipantAttendance> GetUserAttendances(dm.Registration.Participant participant, dm.Course.CourseClass cls)
        {
            return null;
        }
    }
}
