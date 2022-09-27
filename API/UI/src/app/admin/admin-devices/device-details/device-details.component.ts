import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {  DeviceServices } from 'src/app/shared/device.service';

@Component({
  selector: 'app-device-details',
  templateUrl: './device-details.component.html',
  styleUrls: ['./device-details.component.css']
})
export class DeviceDetailsComponent implements OnInit {

  deviceForm: FormGroup = new FormGroup ({
    Id: new FormControl('',[Validators.required]),
    Description: new FormControl('',[Validators.required]),
    Location: new FormControl('',[Validators.required]),
    MaxEnergyConsumtion: new FormControl('', [Validators.required]),
    BaselineEnergyConsumtion: new FormControl('',[Validators.required]),
    SmartSenzor: new FormControl(''),
    Client: new FormControl('') 

  })

  constructor(private deviceServices: DeviceServices) { }

  actionType = "submit";

  ngOnInit(): void {
    
      this.deviceServices.editDeviceOnEdit.subscribe((row:any) =>{
        this.deviceForm.controls["Id"].setValue(row.id);
        this.deviceForm.controls["Description"].setValue(row.description);
        this.deviceForm.controls["Location"].setValue(row.location);
        this.deviceForm.controls["MaxEnergyConsumtion"].setValue(row.maxEnergyConsumtion);
        this.deviceForm.controls["BaselineEnergyConsumtion"].setValue(row.baselineEnergyConsumtion);

        this.actionType = "edit";
      });


  }

  onSubmit(){
    var newDevice = {
      description: this.deviceForm.value.Description,
      location: this.deviceForm.value.Location,
      maxEnergyConsumtion: Number(this.deviceForm.value.MaxEnergyConsumtion),
      baselineEnergyConsumtion: Number(this.deviceForm.value.BaselineEnergyConsumtion),
      

    };
    this.deviceServices.addDevice(newDevice).subscribe((x:any)=>{
     
      this.deviceServices.updateDeviceOnSubmit.emit("update table");
      
    });
    
    this.deviceForm.reset();
    
  }

  onEdit(){
    var editDevice = {
      description: this.deviceForm.value.Description,
      location: this.deviceForm.value.Location,
      maxEnergyConsumtion: Number(this.deviceForm.value.MaxEnergyConsumtion),
      baselineEnergyConsumtion: Number(this.deviceForm.value.BaselineEnergyConsumtion)
            
    };
    
    this.deviceServices.editDevice(editDevice,this.deviceForm.controls["Id"].value).subscribe((x:any)=>{
      this.deviceServices.updateDeviceOnSubmit.emit("update table");
    })

    this.actionType = "submit";
    this.deviceForm.reset();

  }

  onDelete(){
    this.deviceServices.deleteDevice(this.deviceForm.controls["Id"].value).subscribe((x:any)=>{
      this.deviceServices.updateDeviceOnSubmit.emit("update table");
    })
    this.actionType = "submit";
    this.deviceForm.reset();
  }

  

}
