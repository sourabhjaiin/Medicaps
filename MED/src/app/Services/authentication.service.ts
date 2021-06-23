import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppUser } from '../Entities/appuser';
import { GatewayUrls } from './GateWayUrls';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private urls = new GatewayUrls();

  private isLoggedInAdmin= new BehaviorSubject<boolean>(false);
  OnLoggedInAdmin= this.isLoggedInAdmin.asObservable();

  private isLoggedInUser= new BehaviorSubject<boolean>(false);
  OnLoggedInUser= this.isLoggedInAdmin.asObservable();

  constructor(private http: HttpClient) { }

  doLoginAdmin(status: boolean){
    this.isLoggedInUser.next(false);
    this.isLoggedInAdmin.next(status);
  }

  doLoginUser(status: boolean){
    this.isLoggedInAdmin.next(false);
    this.isLoggedInUser.next(status);
  }

  authenticate(username:string, password:string){
    var obj = {
      username:username,
      password:password
    }
    return this.http.post(this.urls.LoginEndpoint, obj);
  }
  
  register(user:AppUser){
    return this.http.post(this.urls.RegisterEndpoint, user)
  }
  
}