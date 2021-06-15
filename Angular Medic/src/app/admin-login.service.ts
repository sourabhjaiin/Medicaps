import { Injectable } from '@angular/core';  
import {HttpClient} from '@angular/common/http';  
import {HttpHeaders} from '@angular/common/http';  
import { from, Observable } from 'rxjs';  
import { Register } from "../app/register"; 
import { Login } from './loged';

@Injectable({
  providedIn: 'root'
})


export class AdminLoginService {

  url:string="http://localhost:59186/Api/Admin/UserLogin";

  url1:string="http://localhost:59186/Api/Customer/signup";

  
  constructor(private http: HttpClient) 
  {
   
  }

  login(login:Login){
    return this.http.post(this.url,login);
  }

  signup(register: Register){
    return this.http.post(this.url1,register);
  }

  

  
}
