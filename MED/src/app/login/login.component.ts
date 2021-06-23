import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../Services/authentication.service';
import { LoginResponse  } from '../Entities/loginresponse'


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

 
  username:string='';
  password:string='';

  
  

  constructor(private auth:AuthenticationService ,private router:Router ) {
   
   }

  ngOnInit(): void {
    
  }

  doLogin(){
    this.auth.authenticate(this.username, this.password).subscribe(
      res=>{
        let UserResponse= res as LoginResponse;
        console.log(res);
        console.log(typeof(res));
        console.log(UserResponse);
        if(UserResponse.UserType === "Admin" || UserResponse.UserType === "admin")
        {
          window.localStorage.setItem("id", UserResponse.UserId.toString()); 
        console.log("isexecuted");
         this.auth.doLoginAdmin(true);
         this.router.navigateByUrl("/admin-page"); 
        }
        
        else if (UserResponse.UserType === "User" || UserResponse.UserType === "user")
        {
          console.log("isexecuted");
          window.localStorage.setItem("id", UserResponse.UserId.toString()); 
          this.auth.doLoginUser(true);
          this.router.navigateByUrl("/admin-page");
        }
        
      },
      err=>{
        console.log(err);
        if(err.status === 400)
        {
          alert("Invalid username/password");
        }
        else{
          alert("Error logging in");
        }
      }
    );
  }

}
