import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, FormBuilder, Validators, NgForm} from '@angular/forms';
import { AdminLoginService } from '../admin-login.service';
import { Register } from '../register';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  frmSign: FormGroup;
  constructor(private al:AdminLoginService, private formbuilder:FormBuilder) {
    this.frmSign=this.formbuilder.group({
      username: new FormControl('', Validators.required),
      password: new FormControl('',Validators.required),
      email: new FormControl('',Validators.required),
      phoneNo: new FormControl('',Validators.required)
    }
    );
   }



  ngOnInit(): void {
  }

  signupp(frmSign:any){
    console.log(frmSign);
    if(frmSign.valid){
      
      let r:Register= frmSign.value as Register;
      console.log(r);
      this.al.signup(r).subscribe(
        response=>{alert('Product Saved');},
        error=>{alert("Invalid Data Entry");}
      );
    
    alert('Form Saved');
      console.log(frmSign.value);
    }
    else{
      alert('Invalid Form Data');
    }
  }
    
  }
  


