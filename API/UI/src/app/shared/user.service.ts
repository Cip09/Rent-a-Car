import { Inject, Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})
export class UserService {
  BaseURI:string;
  constructor(private fb: FormBuilder, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
   this.BaseURI = baseUrl;
  }
  //readonly BaseURI = 'https://localhost:44314';

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    //passwordMismatch
    //confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

  register() {
    var body = {
      userName: this.formModel.value.UserName,
      email: this.formModel.value.Email,
      fullName: this.formModel.value.FullName,
      password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + 'ApplicationUser/Register', body);
  }

  login(formData:any) {
    debugger
    return this.http.post(this.BaseURI + 'ApplicationUser/Login', formData);
  }

  getUserProfile() {
    return this.http.get(this.BaseURI + 'UserProfile');
  }
}
