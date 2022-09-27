import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuardAdmin } from './auth/auth.admin';
import { MyCarComponent } from './my-car/my-car.component';
import { AuthGuardUser } from './auth/auth.user';
import { RequestListComponent } from './request-list/request-list.component';
import { RequestComponent } from './request/request.component';
import { AllCarForRentComponent } from './all-car-for-rent/all-car-for-rent.component';
import { RentCarListComponent } from './rent-car-list/rent-car-list.component';
import { CarDetalisComponent } from './car-detalis/car-detalis.component';
import { SchedulingRequestComponent } from './scheduling-request/scheduling-request.component';
import { RequestRetreatCarComponent } from './request-retreat-car/request-retreat-car.component';
import { AdminContainerComponent } from './admin/admin-container/admin-container.component';
import { AdminRentCarListComponent } from './admin-rent-car-list/admin-rent-car-list.component';
import { AdminDisabledCarComponent } from './admin-disabled-car/admin-disabled-car.component';
import { ContactPageComponent } from './contact-page/contact-page.component';
import { ConditionsPageComponent } from './conditions-page/conditions-page.component';

const routes: Routes = [
  {path:'',redirectTo:'/login',pathMatch:'full'},
  {
    path: 'login', component: LoginComponent, 
   
  },
  {
    path: 'contact', component: ContactPageComponent, 
   
  },
  {
    path: 'register', component: RegistrationComponent, 
    
  },
  {
    path: 'conditions', component: ConditionsPageComponent, 
    
  },
  {
    path: 'rent-car-list', component: RentCarListComponent, 
      children: [
        {path:'car-details', component: CarDetalisComponent },
      ]
  },
  {
    path:'car-details/:id', component: CarDetalisComponent, 
   
  },
  {
    path: 'rentCar', component: AllCarForRentComponent
  },
  {
    
    path: 'user', component: UserComponent,  canActivate: [AuthGuardUser],
    children: [
     
      {path:'request', component:RequestComponent, canActivate: [AuthGuardUser], },
      {path:'myCar', component:MyCarComponent, canActivate: [AuthGuardUser], }
     
    ]
  },
  { 
    path: 'admin', component: AdminContainerComponent, canActivate:[AuthGuardAdmin],
    children: [
      { path: 'request/list', component: RequestListComponent,  canActivate:[AuthGuardAdmin] },
      { path: 'scheduling/list', component: SchedulingRequestComponent,  canActivate:[AuthGuardAdmin] },
      { path: 'request/retreat-car', component: RequestRetreatCarComponent,  canActivate:[AuthGuardAdmin] },
      { path: 'car-for-rent', component: AdminRentCarListComponent,  canActivate:[AuthGuardAdmin]},
      { path: 'disabled-car', component: AdminDisabledCarComponent,  canActivate:[AuthGuardAdmin]}
      

     
    ]
  },
  {path:'home',component:HomeComponent},

 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
