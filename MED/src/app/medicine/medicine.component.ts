import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Medicine  } from '../Entities/Medicine';
import { AuthenticationService } from '../Services/authentication.service';
import { MedicineService } from '../Services/medicine.service';

@Component({
  selector: 'app-medicine',
  templateUrl: './medicine.component.html',
  styleUrls: ['./medicine.component.css']
})
export class MedicineComponent implements OnInit, OnDestroy {

  medicines: Medicine[]=[];
  medi: string='';
  id:number=0;
  subs1: Subscription = new Subscription;
  sub2: Subscription = new Subscription;

  adminLoggedIn: boolean = false;
  userLoggedIn: boolean = false;
  
  constructor(private med:MedicineService,private auth: AuthenticationService,private router:Router) { }

  ngOnInit(): void {
    this.subs1=this.auth.OnLoggedInAdmin.subscribe(result1=>{this.adminLoggedIn=result1;
    console.log(result1) });
    this.sub2=this.auth.OnLoggedInUser.subscribe(result2=>{this.userLoggedIn=result2;
    console.log(result2)});
  
    this.med.getMedicine().subscribe(
      res=>{this.medicines=res as Medicine[]},
      err=>{alert('Error Fetching data');}
    );
  }

  ngOnDestroy():void{
    this.subs1.unsubscribe();
    this.sub2.unsubscribe();
  }

  Search(){
    this.router.navigateByUrl("/show-med/"+this.medi); 
  }

  Delete(id:number){
    this.med.DeleteMedicine(id).subscribe(data=>
      {
        console.log(data);
        alert("Medicine deleted");
        this.router.navigateByUrl("/pharmacy");
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
          this.router.navigateByUrl("/medicine");
        }
      });
  }

  Update(mid:number){
    this.router.navigateByUrl("/update-med/"+ mid);
  }

}
