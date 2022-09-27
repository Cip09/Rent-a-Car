import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AlertModel } from './models/alertModel';
import { UserService } from './service/user.service';
import { JWTTokenService } from './shared/JWTToken.services';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'Rent a car App';
  constructor(private router: Router, private _jwt: JWTTokenService, private service: UserService){}

  isLogin !: boolean
  user?:string
  notificationList!: AlertModel []

  
  ngOnInit() {
    this.getAlet()
    if(localStorage.getItem("token")){
      this.isLogin = true;
      this._jwt.setToken(localStorage.getItem('token')!.toString());
      if(this._jwt.getRole()){
        this.user = this._jwt.getRole()!
      }
    }else{
      this.isLogin = false
    }
    console.log(this.isLogin)
    console.log(this.user)
  }

  onLogout() {
    localStorage.removeItem('token');
     this.router.navigate(['/login']);
     localStorage.clear()
    this.isLogin = false;
    this.user = ''
  }
  redirectToProfile(){
    
    this.router.navigate(['/home']);
  }

  redirectToNotificatin(element: any){
 
    if(element == "Adaugare cerere de inchiriere masina"){
      this.router.navigate(['/admin/scheduling/list']);
    }

    if(element == "Adaugare masina pentru inchiriere"){
      this.router.navigate(['/admin/request/list']);
    }

  
  }

  clickButtonNotification(){
    console.log("show notification")
  }

  getAlet(){
    this.service.getAlet().subscribe(x=>{
      this.notificationList = x
      console.log(x)
    })
  }



  
}


