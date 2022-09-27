import { Component, OnInit } from '@angular/core';
import { mergeMap } from 'rxjs/operators';
import { Client, ClientService } from 'src/app/shared/client.service';


@Component({
  selector: 'app-clients-list',
  templateUrl: './clients-list.component.html',
  styleUrls: ['./clients-list.component.css']
})
export class ClientsListComponent implements OnInit {

  clients: Client[] = []; 
  currentRow: any;
  constructor(private clientServices: ClientService) { }

   
  displayedColumns: string[] = [ 'userName', 'email', 'fullName'];
  

  ngOnInit(): void {
    this.clientServices.getClients().subscribe(clients=>{
      this.clients = clients;
    })

    this.clientServices.updateClient.pipe(mergeMap(x=> this.clientServices.getClients())).subscribe( (clients:any)=>{
      this.clients = clients;

    });
  }
  clickeRows(row:any){
    this.currentRow = row;

   this.clientServices.editClient.emit(row);
  }
}


