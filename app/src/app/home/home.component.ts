import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MyserviceService } from '../myservice.service';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent  implements OnInit {
  employee:any;


  constructor(private http : HttpClient, private service : MyserviceService,private router:Router){}

  ngOnInit() {
    this.getEmployees()
  }

  getEmployees(){
    this.service.fetchEmployee().subscribe((data)=>{
      this.employee=data;
      console.log(this.employee)
    });
  }
  deleteEmployees(id:number){

    this.service.deleteEmployee(id).subscribe(
      (res)=>{
        this.getEmployees()
    
       
    });
  }

  editEmployee(id:number,body:any){

    this.service.id = id
    this.service.firstname = body.firstName
    this.service.lastname  = body.lastName
    this.service.mobilenumber=body.mobileNumber
    this.service.email = body.email
    this.service.address=body.address_
    this.service.gender = body.sex 
    this.service.dept = body.deptID
    this.router.navigate(['/edit']);

  }


}
