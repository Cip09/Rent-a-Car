import { UserService } from '../../service/user.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(private router: Router,public service: UserService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          this.router.navigate(['/login']);
          this.toastr.success('Contul a fost creat!', 'Inregistrare reusita');
        } else {
          res.errors.forEach((element: { code: any; description: string | undefined; }) => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Numele contului deja exista','Inregistrare esuata.');
                break;

              default:
              this.toastr.error(element.description,'Inregistrare esuata.');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
 

    

  }

}
