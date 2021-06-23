import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Pharmacy } from '../Entities/Pharmacy';
import { PharmacyService } from '../Services/pharmacy.service';

@Component({
  selector: 'app-add-pharmacy',
  templateUrl: './add-pharmacy.component.html',
  styleUrls: ['./add-pharmacy.component.css']
})
export class AddPharmacyComponent implements OnInit {

  pharmacies!: Pharmacy;

  constructor(private phar:PharmacyService, private router:Router) { }

  ngOnInit(): void {
    this.pharmacies={
      PsID:0,
      PsName:'',
      Location:'',
      Pincode:0,
      UserId:0
    }
  }

  AddPhar(){
    this.pharmacies.UserId= Number(window.localStorage.getItem("id"));
    console.log(this.pharmacies)
    this.phar.addpharmacy(this.pharmacies).subscribe(
      res=>{
        console.log(res);
        console.log(typeof(res));
        alert('Pharmacies Added');
        this.router.navigateByUrl("/pharmacy");
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
