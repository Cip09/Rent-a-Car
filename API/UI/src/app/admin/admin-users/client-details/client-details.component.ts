import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ClientService } from 'src/app/shared/client.service';


@Component({
  selector: 'app-client-details',
  templateUrl: './client-details.component.html',
  styleUrls: ['./client-details.component.css']
})


export class ClientDetailsComponent implements OnInit {
  
  clientForm: FormGroup = new FormGroup ({
    Id: new FormControl('',[Validators.required]),
    UserName: new FormControl('',[Validators.required]),
    Email: new FormControl('', [Validators.required]),
    Password: new FormControl('',[Validators.required]),
    FullName: new FormControl('',[Validators.required]),
  
  })
  hide = true;
  actionType: string = "submit";
  constructor(private clientServices: ClientService) { 
    
  }
 
  

  ngOnInit(): void {
  this.clientForm.patchValue({
    firstName: '',
        
  })
  this.clientServices.editClient.subscribe((row:any)=>{
    this.clientForm.controls["Email"].setValue(row.email);
    this.clientForm.controls["Id"].setValue(row.id);
    this.clientForm.controls["UserName"].setValue(row.userName);
    this.clientForm.controls["FullName"].setValue(row.fullName);

    this.actionType = "edit";
  });
 }

  onSubmit(): void{
    console.log(this.clientForm);
    var newClient1 = {
      UserName: this.clientForm.value.UserName,
      Email: this.clientForm.value.Email,
      Password: this.clientForm.value.Password,
      Fullname: this.clientForm.value.FullName

    };

    this.clientServices.addClient(newClient1).subscribe((x:any)=>{
      this.clientServices.updateClient.emit("update table");
      
    })
  }
  onEdit():void{
    console.log(this.clientForm);
    var client = {
      UserName: this.clientForm.value.UserName,
      Email: this.clientForm.value.Email,
      Password: this.clientForm.value.Password,
      Fullname: this.clientForm.value.FullName
    };
    this.clientServices.editClientRequest(client, this.clientForm.controls["Id"].value).subscribe((x:any)=>{
      this.clientServices.updateClient.emit("update");
    });

    this.clientForm.reset();
    this.actionType = "submit";
  }

  onDelete(){
    this.clientServices.deteleClient( this.clientForm.controls["Id"].value).subscribe((x:any)=>{
      this.clientServices.updateClient.emit("update");
    });
    this.clientForm.reset();
    this.actionType = "submit";
  }

}
