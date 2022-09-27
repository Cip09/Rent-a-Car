import { Component, OnInit } from '@angular/core';
import { mergeMap } from 'rxjs/operators';
import { Device, DeviceServices } from 'src/app/shared/device.service';

@Component({
  selector: 'app-devices-list',
  templateUrl: './devices-list.component.html',
  styleUrls: ['./devices-list.component.css']
})
export class DevicesListComponent implements OnInit {

  devices: Device[] = []; 
  currentRow: any;
  constructor(private deviceServices: DeviceServices) { }

   
  displayedColumns: string[] = [ 'description', 'location', 'maxEnergyConsumtion','baselineEnergyConsumtion'];
  

  ngOnInit(): void {
  
      this.deviceServices.getDevices().subscribe(devices=>{
        this.devices = devices;

      })

  
      this.deviceServices.updateDeviceOnSubmit.pipe(mergeMap(x=> this.deviceServices.getDevices())).subscribe((devices:any)=>{
        this.devices=devices;
        
      });
  }
   clickeRows(row:any){
    this.currentRow = row;
 
    this.deviceServices.editDeviceOnEdit.emit(row);
  }

}
