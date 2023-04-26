import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MyserviceService } from '../myservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddComponent implements OnInit {

  department:any;


  
  constructor(private http : HttpClient, private service : MyserviceService,private router:Router){}


  depart=''
  gender=''
  address_=''
  mobileNumber=''
  lastName=''
  firstname=''
  email=''

  ngOnInit() {

    this.getDepartment()
    
  }

 

  submitForm(){

    console.log(this.firstname, this.lastName,this.email,this.mobileNumber,this.address_,this.gender,this.depart)


    let body= {
      firstName:this.firstname,
      lastName:this.lastName,
      mobileNumber:this.mobileNumber,
      address_:this.address_,
      sex:this.gender,
      email:this.email,
      deptID:this.depart,

    }

    this.service.postEmployee(body).subscribe((res)=>{
      console.log(body);
      this.router.navigate(['/']);
      }
    )}



  getDepartment(){
    this.service.fetchDepartment().subscribe((d)=>{
      this.department=d
      console.log(this.department)
    })
  }

}
