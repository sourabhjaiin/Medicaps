import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validator, NgForm} from '@angular/forms';
import { Router } from '@angular/router';
import { Medicine } from '../Entities/Medicine';
import { MedicineService } from '../Services/medicine.service';

@Component({
  selector: 'app-add-medicine',
  templateUrl: './add-medicine.component.html',
  styleUrls: ['./add-medicine.component.css']
})
export class AddMedicineComponent implements OnInit {

  medicines!: Medicine;

  constructor(private med: MedicineService,private router:Router ) { }

  ngOnInit(): void {
    this.medicines= 
    {
      MedicineId:0,
      MedicineName:'',
      MedicinePrice:0,
      IsDelivable:false,
      Composition:'',
      UserId:0
    }
  }

  AddMed(){
    this.medicines.UserId= Number(window.localStorage.getItem("id"));
    console.log(this.medicines);
    this.med.addMedicine(this.medicines).subscribe(
      res=>{
        console.log(res);
        console.log(typeof(res));
        alert("Medicine Added");
        this.router.navigateByUrl("/medicine");

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
