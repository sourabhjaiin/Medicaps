import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { AppUser } from '../Entities/appuser';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  user!: AppUser;
  constructor(private auth:AuthenticationService, private router:Router) {}

   ngOnInit(): void {
    this.user={
      UserId:0,
      UserName:"",
      Password:"",
      Email:"",
      UserType:"",
      Phone:"",
      Confirmed:true
    };
  }

  doRegister(){
    console.log(this.user);
    this.auth.register(this.user).subscribe(
      res=>{
        console.log(res);
        console.log(typeof(res));
        this.router.navigateByUrl("/login");
        alert("Registered");
      },
      err=>{
        console.log(err);
        if(err.status === 400)
        {
          alert("Wrong arguments");
        }
        else{
          alert("Error logging in");
        }
      }
    );
      

  }

}
