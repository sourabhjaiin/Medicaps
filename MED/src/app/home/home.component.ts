import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../Services/authentication.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {

  subs1: Subscription = new Subscription;
  sub2: Subscription = new Subscription;

  adminLoggedIn: boolean = false;
  userLoggedIn: boolean = false;

  constructor(private router: Router, private auth: AuthenticationService) { }

  ngOnInit(): void {
    this.subs1=this.auth.OnLoggedInAdmin.subscribe(result1=>{this.adminLoggedIn=result1});
    this.sub2=this.auth.OnLoggedInUser.subscribe(result2=>{this.userLoggedIn=result2});
  }

  ngOnDestroy():void{
    this.subs1.unsubscribe();
    this.sub2.unsubscribe();
  }

  logout(){
    this.router.navigateByUrl('/login');
    this.auth.doLoginAdmin(false);
    this.auth.doLoginUser(false);
  }

}
