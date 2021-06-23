import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Medicine } from '../Entities/Medicine';
import { MedicineService } from '../Services/medicine.service';

@Component({
  selector: 'app-edit-med',
  templateUrl: './edit-med.component.html',
  styleUrls: ['./edit-med.component.css']
})
export class EditMedComponent implements OnInit {

  medicines: any= { 
    MedicineId:0,
    MedicineName:'',
    MedicinePrice:0,
    IsDelivable:false,
    Composition:'',
    UserId:0 
  }
  mId:any;

  
  constructor(private actr: ActivatedRoute, private med: MedicineService, private router:Router ) { 
    
  }

  ngOnInit(): void {
   

    this.mId=Number(this.actr.snapshot.paramMap.get('id'));
    this.med.getMedicinebyId(+this.mId).subscribe(
      data=>{
        this.medicines=data;
      console.log(data);},
      err=>{
        console.log(err);
      if(err.status === 400)
        {
          alert("Wrong arguments");
        }
        else if(err.status == 200){
          alert("User obtained");
        }
        else{
          alert("Error getting user");
        }
      }
    );
  }

    EditMed(){
      console.log(this.medicines);
      this.med.UpdateMedicine(this.medicines).subscribe(
        res=>{
          console.log(res);
          alert("Medicine Update");
          this.router.navigateByUrl('/medicine');
        },
        err=>{
          console.log(err);
        if(err.status === 400)
        {
          alert("Wrong arguments");
        }
        else{
          alert("Error Updating Ipo");
        }
        }
      );

    }
  }





