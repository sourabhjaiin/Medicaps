import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { PharmacyService } from './Services/pharmacy.service';
import { MedicineService } from './Services/medicine.service';
import { AuthenticationService } from './Services/authentication.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

import { AdminLandingPageComponent } from './admin-landing-page/admin-landing-page.component';
import { AddMedicineComponent } from './add-medicine/add-medicine.component';
import { AddPharmacyComponent } from './add-pharmacy/add-pharmacy.component';
import { MedicineComponent } from './medicine/medicine.component';
import { PharmacyComponent } from './pharmacy/pharmacy.component';
import { HomeComponent } from './home/home.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { EditMedComponent } from './edit-med/edit-med.component';
import { EditPharmComponent } from './edit-pharm/edit-pharm.component';
import { CartComponent } from './cart/cart.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    AdminLandingPageComponent,
    AddMedicineComponent,
    AddPharmacyComponent,
    MedicineComponent,
    PharmacyComponent,
    HomeComponent,
    
    ContactUsComponent,
         EditMedComponent,
         EditPharmComponent,
         CartComponent
   
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule,
    Ng2SearchPipeModule
  ],
  
  providers: [PharmacyService,MedicineService,AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
