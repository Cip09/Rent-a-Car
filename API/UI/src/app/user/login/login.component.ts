
import { UserService } from './../../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
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
  constructor(private service: UserService, private router: Router,  private fb: FormBuilder, private login: AppComponent, private jwt: JWTTokenService) { }
 
  ngOnInit() {
    if (localStorage.getItem('token') != null){
      this.router.navigateByUrl('/home');
      
    }
  }

  onSubmit() {
    this.service.login(this.formModel.value).subscribe(
      (res: any) => {
        
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');       
        this.login.isLogin = 'true';
      
        if(localStorage.getItem('token')){
          this.jwt.setToken(localStorage.getItem('token').toString());
        }else{
          this.jwt.setToken('');
        }

        this.login.user = '';
        if(this.jwt.getRole()){
          this.login.user = this.jwt.getRole();
        }
   
      },
      err => {
        // if (err.status == 400)
        //   //this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        // else
        //   console.log(err);
      }
    );
  }
}
