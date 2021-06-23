import { Injectable } from '@angular/core';
import { GatewayUrls } from './GateWayUrls';
import { HttpClient } from '@angular/common/http';
import { Medicine } from '../Entities/Medicine';


@Injectable({
  providedIn: 'root'
})
export class MedicineService {

  private urls = new GatewayUrls();

  constructor(private http:HttpClient) { }

  getMedicine(){
    return this.http.get(this.urls.MedEndPoint);
  }

  addMedicine(medicine:Medicine){
    return this.http.post(this.urls.AddMed,medicine); 
  }

  getMedicinebyName(medname:string){
    return this.http.get(this.urls.MedsearchbyName+ '/'+ medname);
  }

  getMedidinebyComp(medcomp:string){
    return this.http.get(this.urls.MedsearchbyComp+ '/' + medcomp );
  }

  getMedicinebyId(id:number){
    return this.http.get(this.urls.MedEndPoint + '/' + id.toString());
  }

  DeleteMedicine(id:number){
    return this.http.delete(this.urls.MedEndPoint + '/' + id.toString());
  }
 
   
  UpdateMedicine(medicine:Medicine){
    return this.http.put(this.urls.MedEndPoint, medicine);
  }


  
}
