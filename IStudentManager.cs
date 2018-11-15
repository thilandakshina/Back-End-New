using JKCS.SM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKCS.SM.BusinessServices.Contract
{
   public interface IStudentManager
    {
        bool AddStudent(Student student);
        List<Student> GetStudentList();

        bool UpdateStudent(Student student);

    }
}
