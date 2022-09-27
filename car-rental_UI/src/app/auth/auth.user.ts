import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { JWTTokenService } from '../shared/JWTToken.services';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardUser implements CanActivate {


  constructor(private router: Router, private jwt: JWTTokenService) {
  }
  
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    const token = localStorage.getItem('token')
    if (token !!= null){

        this.jwt.setToken(token.toString());
        
        if((this.jwt.getRole() == "Admin") ||(this.jwt.getRole() == "User"))
        {
          return true;
        }
          else{
            this.router.navigate(['/login']);
            return false;
          }
    }
     
    else {
      this.router.navigate(['/login']);
      return false;
    }

  }

  
}
