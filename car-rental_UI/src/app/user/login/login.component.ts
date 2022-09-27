

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppComponent } from 'src/app/app.component';
import { UserService } from 'src/app/service/user.service';
import { JWTTokenService } from 'src/app/shared/JWTToken.services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
  
})
export class LoginComponent implements OnInit {
  
  formModel: FormGroup = this.fb.group({
    UserName: (''),
    Password: ('')
  });


  constructor(private service: UserService, private router: Router,  private fb: FormBuilder, private login: AppComponent, private jwt: JWTTokenService, private appComponent: AppComponent,
    private toastr: ToastrService) { }
 
  ngOnInit() {
    if (localStorage.getItem('token') != null){
      this.router.navigateByUrl('/rent-car-list');
      
    }
  }

  onSubmit() {
    this.service.login(this.formModel.value).subscribe(
      (res: any) => {
        
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/rent-car-list');       
        this.login.isLogin = true;
      
        if(localStorage.getItem('token')){
          this.jwt.setToken(localStorage.getItem('token')!.toString());
        }else{
          this.jwt.setToken('');
        }

        this.login.user = '';
        if(this.jwt.getRole()){
          this.login.user = this.jwt.getRole()!;
        }
        this.appComponent.getAlet();
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Nume sau parola gresita!.', 'Autentificare esuata.');
        else
          console.log(err);
      }
    );
  }

 

  
}
