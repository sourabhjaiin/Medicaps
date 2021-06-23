import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Pharmacy } from '../Entities/Pharmacy';
import { AuthenticationService } from '../Services/authentication.service';
import { PharmacyService } from '../Services/pharmacy.service';

@Component({
  selector: 'app-pharmacy',
  templateUrl: './pharmacy.component.html',
  styleUrls: ['./pharmacy.component.css']
})
export class PharmacyComponent implements OnInit , OnDestroy{

  pharmacies: Pharmacy[]=[];
  pharm:string='';
  
  subs1: Subscription = new Subscription;
  sub2: Subscription = new Subscription;

  adminLoggedIn: boolean = false;
  userLoggedIn: boolean = false;

  constructor(private phar:PharmacyService,private auth: AuthenticationService,private router:Router) { }

  ngOnInit(): void {

    this.subs1=this.auth.OnLoggedInAdmin.subscribe(result1=>this.adminLoggedIn=result1);
    this.sub2=this.auth.OnLoggedInUser.subscribe(result2=>this.userLoggedIn=result2);

    console.log(this.adminLoggedIn);
    console.log(this.userLoggedIn);
    this.phar.getpharmacy().subscribe(
      
      res=>{this.pharmacies=res as Pharmacy[];},
      err=>{alert('error fetching data');}
    );
  }

  ngOnDestroy():void{
    this.subs1.unsubscribe();
    this.sub2.unsubscribe();
  }

  DeletePhar(id:number){
    this.phar.DeletePharmacy(id).subscribe(data=>
      {
        console.log(data);
        alert("Successful");
        this.router.navigateByUrl("/medicine");
      },
      err =>{
        console.log(err);
        if(err.status === 400)
        {
          
          alert("Wrong arguments");
          
        }
        else if(err.status === 200){
          
          alert("Company deleted");
          
        }
        else{
          alert("Error in Deleting");
          
        }
      });
  }

  Search(){
    this.router.navigateByUrl("/show-med/"+this.pharm); 
  }

  

}
