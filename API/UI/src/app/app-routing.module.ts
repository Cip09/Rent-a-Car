import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AdminContainerComponent } from './admin/admin-container/admin-container.component';
import { AdminUsersComponent } from './admin/admin-users/admin-users.component';
import { AdminDevicesComponent } from './admin/admin-devices/admin-devices.component';
import { AdminSenzorComponent } from './admin/admin-senzor/admin-senzor.component';
import { AuthGuardAdmin } from './auth/auth.admin';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  { 
    path: 'admin', component: AdminContainerComponent, canActivate:[AuthGuardAdmin],
    children: [
      { path: 'client', component: AdminUsersComponent,  canActivate:[AuthGuardAdmin] },
      { path: 'device', component: AdminDevicesComponent, canActivate:[AuthGuardAdmin] },
      { path: 'senzor', component: AdminSenzorComponent, canActivate:[AuthGuardAdmin] }
    ]
  },
  {path:'home',component:HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
