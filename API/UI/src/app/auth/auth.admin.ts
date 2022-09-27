import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AppComponent } from '../app.component';
import { JWTTokenService } from '../shared/JWTToken.services';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardAdmin implements CanActivate {


  constructor(private router: Router, private jwt: JWTTokenService) {
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (localStorage.getItem('token') != null){
       
        this.jwt.setToken(localStorage.getItem('token').toString());
        
        if(this.jwt.getRole() == "Admin")
        {
          return true;
        }
          else{
            this.router.navigate(['/user/login']);
            return false;
          }
    }
       
    else {
      this.router.navigate(['/user/login']);
      return false;
    }

  }

  
}
