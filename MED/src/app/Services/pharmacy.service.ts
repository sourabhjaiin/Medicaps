import { Injectable } from '@angular/core';
import { GatewayUrls } from './GateWayUrls';
import { HttpClient } from '@angular/common/http';
import { Pharmacy } from '../Entities/Pharmacy';

@Injectable({
  providedIn: 'root'
})
export class PharmacyService {
  private urls = new GatewayUrls();

  constructor(private http:HttpClient) { }

  getpharmacy(){
    return this.http.get(this.urls.PharEndPoint);
  }

  addpharmacy(pharmacy:Pharmacy){
    return this.http.post(this.urls.PharEndPoint,pharmacy);
  }

  getPharmbyPin(pin:number){
    return this.http.get(this.urls.PharmsearchbyPincode + '/'+pin);
  }

  DeletePharmacy(id:number){
    return this.http.delete(this.urls.PharEndPoint + '/' + id.toString());
  }

  UpdatePharmacy(pharmacy:Pharmacy){
    return this.http.put(this.urls.PharEndPoint, pharmacy);
  }
}
