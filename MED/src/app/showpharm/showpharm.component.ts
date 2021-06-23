import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pharmacy } from '../Entities/Pharmacy';
import { MedicineService } from '../Services/medicine.service';
import { PharmacyService } from '../Services/pharmacy.service';

@Component({
  selector: 'app-showpharm',
  templateUrl: './showpharm.component.html',
  styleUrls: ['./showpharm.component.css']
})
export class ShowpharmComponent implements OnInit {

  pin:number=0;
  pharmacy!: Pharmacy;
  constructor(private actr:ActivatedRoute,private phar:PharmacyService) {
    this.pin=Number(this.actr.snapshot.paramMap.get('pharmname'));
   }

  ngOnInit(): void {
    this.phar.getPharmbyPin(this.pin).subscribe(

      obj=>{ 
        console.log(obj);
        this.pharmacy = obj as Pharmacy
      },
      err=>{
        console.log(err);
        if(err.status === 400)
        {
          alert("Pharmacy not In the database");
        }
        else{
          alert("Error");
        }
      }

    );
  }

}
