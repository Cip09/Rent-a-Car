import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JWTTokenService } from './shared/JWTToken.services';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Energy Consumption';
  constructor(private router: Router){}

  isLogin = 'true';
  user='';
  
  ngOnInit() {
    this.onLogout();
    
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
    this.isLogin = 'false';
    this.user = ''
  }

  
}


