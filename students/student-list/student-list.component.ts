// import { StudentRegComponent } from './../student-reg/student-reg.component';
import { Student } from './../shared/student.model';
import { StudentService } from './../shared/student.service';
import { Component, OnInit } from '@angular/core';
// import { StudentRegComponent } from '../student-reg/student-reg.component';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  constructor(private studentService : StudentService) { }

  //  saro = new StudentRegComponent(this.studentService);

  ngOnInit() {
    this.studentService.GetStudentList();
    //this.saro.selectedgender = 1;
    // studentRegComponent : StudentRegComponent;
  }

  showForEdit(std: Student) {
  
    // this.studentService.selectedgender = std.Gender;   
    this.studentService.selectedStudent = Object.assign({}, std);
    // this.saro.selectedgender = 1;
    // this.saro.selectedgender =  Object.assign({}, 1);
  }
 
 
  
  key: string = 'name'; //set default
  reverse: boolean = false;
  sort(key){
    console.log('sor');
    this.key = key;
    this.reverse = !this.reverse;
  }  
  // onDelete(id: number) {
  //   if (confirm('Are you sure to delete this record ?') == true) {
  //     this.employeeService.deleteEmployee(id)
  //     .subscribe(x => {
  //       this.employeeService.getEmployeeList();
  //       this.toastr.warning("Deleted Successfully","Employee Register");
  //     })
  //   }
  // }
}
