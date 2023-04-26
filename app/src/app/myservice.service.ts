import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MyserviceService {

 
  constructor(private http : HttpClient) { 


  }

  id=0
  firstname:''|undefined
  lastname:''|undefined
  mobilenumber:''|undefined
  email :''|undefined
  gender:''|undefined
  dept:''|undefined
  address:''|undefined
  

  url = 'https://localhost:7207/api/Employee/'

  fetchEmployee(){

    return this.http.get(this.url+'GetAllEmployees')

  }

  durl ='https://localhost:7207/api/Department/GetAllDepartments'

  fetchDepartment(){
    return this.http.get(this.durl)
  }

  deleteEmployee(id:number){
    return this.http.delete(this.url+''+id);
  }

  postEmployee(body:any){

    return this.http.post(this.url+'AddEmployee',body)

  }
  putEmployee(id:number,body:any){

    return this.http.put(this.url+''+id, body);

  }
}
