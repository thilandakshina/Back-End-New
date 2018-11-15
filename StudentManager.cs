using JKCS.SM.BusinessServices.Contract;
using JKCS.SM.Domain;
using JKCS.SM.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKCS.SM.BusinessServices
{
    public class StudentManager : IStudentManager
    {
        private IStudentRepository _studentRepository;
        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool AddStudent(Student s)
        {

         //   if (DateTime.Today.Subtract(s.DOB).Days >= (365 * 18))
         //   {
                bool status = _studentRepository.Create(s);
                if (status == true)
                {
                    status = _studentRepository.Save();
                }
                return status;
       //     }
         //   else
        //    {
        //        return false;
       //     }


        }

        public List<Student> GetStudentList()
        {
            List<Student> studentList = _studentRepository.GetAll();

            return studentList;

        }

        public bool UpdateStudent(Student s)
        {

            bool status = _studentRepository.Update(s);
            if (status == true)
            {
                status = _studentRepository.Save();
            }
            return status;
        }
    }
}
