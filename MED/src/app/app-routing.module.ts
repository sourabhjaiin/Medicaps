import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddMedicineComponent } from './add-medicine/add-medicine.component';
import { AddPharmacyComponent } from './add-pharmacy/add-pharmacy.component';
import { AdminLandingPageComponent } from './admin-landing-page/admin-landing-page.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { EditMedComponent } from './edit-med/edit-med.component';
import { LoginComponent } from './login/login.component';
import { MedicineComponent } from './medicine/medicine.component';
import { PharmacyComponent } from './pharmacy/pharmacy.component';
import { SignupComponent } from './signup/signup.component';

const routes: Routes = [
  {path:'', redirectTo: '/login', pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'signup',component:SignupComponent},
  {path: "admin-page", component: AdminLandingPageComponent },
  {path:"medicine",component:MedicineComponent},
  {path:"pharmacy",component:PharmacyComponent},
  {path:"add-med",component:AddMedicineComponent},
  {path:"add-phar",component:AddPharmacyComponent},
  {path:'contactus', component:ContactUsComponent},
  {path:'update-med/:id',component:EditMedComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
