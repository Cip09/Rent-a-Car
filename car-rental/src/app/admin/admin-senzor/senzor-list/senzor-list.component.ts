import { Component, OnInit } from '@angular/core';
import { mergeMap } from 'rxjs/operators';
import { Senzor, SenzorServices } from 'src/app/shared/senzor.service';

@Component({
  selector: 'app-senzor-list',
  templateUrl: './senzor-list.component.html',
  styleUrls: ['./senzor-list.component.css']
})
export class SenzorListComponent implements OnInit {
  senzors: Senzor[] = []
  currentRow: any
  
  displayedColumns =['senzorDescription', 'maximumValue'];
  constructor(private senzorServices: SenzorServices) { }

  ngOnInit(): void {
    this.senzorServices.getSenzor().subscribe((senzor:any)=>{
      this.senzors = senzor;
    })
    this.senzorServices.updateTable.pipe(mergeMap(x=> this.senzorServices.getSenzor())).subscribe((senzor:any)=>{
      this.senzors=senzor;
      
    });
  }

  clickeRows(row:any){
    this.currentRow = row;
    
    this.senzorServices.editTable.emit(row);
  }
  

}
