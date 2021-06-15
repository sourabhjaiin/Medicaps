import { Component, OnInit } from '@angular/core';
import { AdminLoginService } from '../admin-login.service';
import { Login } from '../loged'
import { Injectable } from '@angular/core';
import { stringify } from '@angular/compiler/src/util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

 
  logine!: Login;
  

  constructor(private al:AdminLoginService ) {
    this.logine= new Login('','');
   }

  ngOnInit(): void {
    
  }

  loginn(){
    this.al.login(this.logine).subscribe(
      res=>{console.log(res);
      },
      
    );
  }

}
