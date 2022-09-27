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
      const token = localStorage.getItem('token')
   
    if ( !!token ){
       
        this.jwt.setToken(token.toString());
        
        if(this.jwt.getRole() == "Admin")
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
