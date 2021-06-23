import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Medicine } from '../Entities/Medicine';
import { MedicineService } from '../Services/medicine.service';
@Component({
  selector: 'app-show-med',
  templateUrl: './show-med.component.html',
  styleUrls: ['./show-med.component.css']
})
export class ShowMedComponent implements OnInit {

  mName:string;
  mComp: string;

  medicine!: Medicine;
  
  constructor(private actr:ActivatedRoute,private med:MedicineService) {
    this.mName=String(this.actr.snapshot.paramMap.get('medname'));
    this.mComp=String(this.actr.snapshot.paramMap.get('medcomp'));
   }

  ngOnInit(): void {

    this.med.getMedicinebyName(this.mName).subscribe(

      obj=>{ 
        console.log(obj);
        this.medicine = obj as Medicine
      },
      err=>{
        console.log(err);
        if(err.status === 400)
        {
          alert("Medicine not In the database");
        }
        else{
          alert("Error");
        }
      }
    );

    this.med.getMedidinebyComp(this.mComp).subscribe(

      obj=>{
        console.log(obj);
        this.medicine= obj as Medicine;
      },

      err=>{
        console.log(err);
        if(err.status === 400)
        {
          alert("Medicine not In the database");
        }
        else{
          alert("Error");
        }
      }
    );


  }

}
