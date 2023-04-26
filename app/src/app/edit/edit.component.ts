import { Component, OnInit } from '@angular/core';
import { MyserviceService } from '../myservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent  implements OnInit {

  department:any;

  ngOnInit() {

    this.getDepartment()
    
  }

  constructor(private service:MyserviceService, private router :Router ){}

  id = this.service.id
  firstname= this.service.firstname
  lastname = this.service.lastname
  mobilenumber=this.service.mobilenumber
  email =this.service.email
  gender = this.service.gender
  dept = this.service.dept
  address= this.service.address

  getDepartment(){
    this.service.fetchDepartment().subscribe((d)=>{
      this.department=d
      console.log(this.department)
    })
  }

  submitForm(){

    let body= {
      firstName:this.firstname,
      lastName:this.lastname,
      mobileNumber:this.mobilenumber,
      address_:this.address,
      sex:this.gender,
      email:this.email,
      deptID:this.dept,

    }

    this.service.putEmployee(this.id,body).subscribe((res)=>{
      console.log(body);
      this.router.navigate(['/']);
      }
    )}



  }


