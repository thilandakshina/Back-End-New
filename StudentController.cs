using AutoMapper;
using JKCS.SM.BusinessServices.Contract;
using JKCS.SM.Domain;
using JKCS.SM.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace JKCS.SM.Web.Controllers
{
    public class StudentController : Controller
    {
        private IStudentManager _studentManager;

        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }


        public ActionResult GetList()
        {
            List<Student> student = new List<Student>();

            student = _studentManager.GetStudentList();

         //   List<StudentViewModel> studentViewModel = Mapper.Map<List<Student>, List<StudentViewModel>>(student);

            var jsonResult = JsonConvert.SerializeObject(student);
            return Content(jsonResult, "application/json");

        }

        public ActionResult Update(Student student)
        {
            if (student.FirstName != null)
            {
                student.Code = "DD";
                student.CreatedDateTime = DateTime.Now;
                student.LastModifiedDateTime = DateTime.Now;
                //  Student students = Mapper.Map<StudentViewModel, Student>(student);
                _studentManager.UpdateStudent(student);
                //  return RedirectToAction("Index", "Student");
            }

            var jsonResult = JsonConvert.SerializeObject("Sucess");
            return Content(jsonResult, "application/json");

        }

        public ActionResult Create(Student student)
        {
            if (student.FirstName != null)
            {
                student.Code = "DD";
                student.CreatedDateTime = DateTime.Now;
                student.LastModifiedDateTime = DateTime.Now;
                // Student students = Mapper.Map<StudentViewModel, Student>(student);
                _studentManager.AddStudent(student);
              //  return RedirectToAction("Index", "Student");
            }


            var jsonResult = JsonConvert.SerializeObject("Sucess");
            return Content(jsonResult, "application/json");
        }
    }
}