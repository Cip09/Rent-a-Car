import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Senzor, SenzorServices } from 'src/app/shared/senzor.service';

@Component({
  selector: 'app-senzor-details',
  templateUrl: './senzor-details.component.html',
  styleUrls: ['./senzor-details.component.css']
})
export class SenzorDetailsComponent implements OnInit {


  actionType = 'submit';
  constructor(private senzorServices : SenzorServices) { }
  senzorForm: FormGroup = new FormGroup({
    Id: new FormControl(''),
    SenzorDescription: new FormControl('',Validators.required),
    MaximumValue: new FormControl('',Validators.required)
  })

  

  

  ngOnInit(): void {
    this.senzorServices.editTable.subscribe((row:Senzor)=>{
      this.senzorForm.controls["Id"].setValue(row.id);
      this.senzorForm.controls["SenzorDescription"].setValue(row.senzorDescription);
      this.senzorForm.controls["MaximumValue"].setValue(row.maximumValue);
      this.actionType = "edit";

      

    })
  }

  onSubmit(){
    var newSenzor ={
      senzorDescription: this.senzorForm.value.SenzorDescription,
      maximumValue: Number(this.senzorForm.value.MaximumValue)
    }
    this.senzorServices.addSenzor(newSenzor).subscribe(()=>{
      this.senzorServices.updateTable.emit("update Talbe");

    })
    console.log(newSenzor)
    
    
  }

  onEdit(){
    var updateSenzor = {
      senzorDescription: this.senzorForm.value.SenzorDescription,
      maximumValue: Number(this.senzorForm.value.MaximumValue)
    }
    this.senzorServices.updateSenzor(updateSenzor, this.senzorForm.controls["Id"].value).subscribe((x:any)=>{
      this.senzorServices.updateTable.emit("update table");

    })
    this.senzorForm.reset();
    this.actionType = 'submit';
  }

  onDelete(){
    this.senzorServices.deleteSenzor(this.senzorForm.controls["Id"].value).subscribe((x:any)=>{
      this.senzorServices.updateTable.emit("table update after delete");
    }); 
    this.actionType = 'submit';
    this.senzorForm.reset();
  }



 
}
