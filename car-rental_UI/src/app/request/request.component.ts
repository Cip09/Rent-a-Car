import { Component,  ElementRef,  OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { matMenuAnimations } from '@angular/material/menu';
import { CarModel } from '../models/carModel';
import { RequestService } from '../service/request.service';
import { ViewChild } from '@angular/core';
import { RequestModalComponent } from '../modal-dialog/request-modal/request-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { RequestAddedComponent } from '../modal-dialog/request-added/request-added.component';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {
  imageBlobUrl: string |ArrayBuffer | null = null;
  @ViewChild('myInput')
  myInputVariable: ElementRef | undefined;

  constructor(public requestService: RequestService, public dialog: MatDialog, private _formBuilder: FormBuilder, private toastr: ToastrService, private router: Router) { }

  loading: boolean = false; // Flag variable
  file: Blob | undefined = undefined// Variable to store file
  needPhoto: boolean = false;
  today = new Date()

  
  generalDataForm: FormGroup = new FormGroup({
    brandCarForm: new FormControl('', Validators.required),
    modelCarForm: new FormControl('', Validators.required),
    colorCarForm:new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]),
    fuelCarFrom: new FormControl('', Validators.required),
  })

  tehnicalDataForm: FormGroup = new FormGroup({
    yearForm: new FormControl('',  [ Validators.required, Validators.pattern("^[0-9]*$")]),
    powerEngineForm: new FormControl('', [ Validators.required, Validators.pattern("^[0-9]*$")]),
    engineCarForm: new FormControl('', Validators.required),
    fuelConsumtionForm: new FormControl('', Validators.required),
    tractionForm: new FormControl('', Validators.required),
    gearBoxForm: new FormControl('', Validators.required),
    lastServicesKmForm: new FormControl('', [ Validators.required, Validators.pattern("^[0-9]*$")]),
    lastServicesDataForm: new FormControl('', Validators.required),
    carKmForm:new FormControl('', [ Validators.required, Validators.pattern("^[0-9]*$")]),
    itpForm: new FormControl('', Validators.required),
  })

  confortDataForm: FormGroup = new FormGroup({
    seatNumbersForm:new FormControl('',  Validators.required),
    doorNumbersForm:new FormControl('',Validators.required),
    categoryCarForm: new FormControl('', Validators.required),
    navigationForm: new FormControl('', Validators.required),
    boardComputerForm: new FormControl('', Validators.required),
    climateForm: new FormControl('', Validators.required)
  })

  priceForm: FormGroup = new FormGroup({
    priceCarFrom: new FormControl('',  [ Validators.required, Validators.pattern("^[0-9]*$")]),
  })

  mentionGroup: FormGroup = new FormGroup({
    mentionForm: new FormControl('',Validators.required)
  })



  isLinear = false;
  firstFormGroup: FormGroup | undefined;
  secondFormGroup: FormGroup | undefined;



  BrandCar: string[] = ['Acura','Aixam','Alfa Romeo','Aro','Aston Martin','Audi','Bentley','BMW','Buick','Bugatti',
  'Cadillac','Chaika','Chevrolet','Citroen','Dacia','Daewoo','Daihatsu','Chrysler','Dodge','Eagle','Ferrari',
  'Fiat','Ford','GMC','Honda','Hummer','Hyundai','Infiniti','Isuzu','Jaguar','Jeep','Kia','Lada','Lamborghini','Lancia',
  'Land Rover','Lexus','Lincoln','Maserati','Mazda','Mercedes-Benz','Mitsubishi','Mini','Nissan','Oltcit','Opel','Peugeot',
  'Pontiac','Porsche','Range Rover','Renault',' Rolls-Royce','Saab','Seat','Skoda','Smart','SsangYoung','Subaru','Suzuki','Tesla',
  'Toyota','Volkswagen','Volvo']


  categoryCar: string[] = ['Sedan','Limuzina', 'Combi', 'Sport', 'SUV', 'Coupe', 'Decapotabila'];

 
  ngOnInit(): void {
    this.firstFormGroup = this._formBuilder.group({
      modelCarForm: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      lastServicesKmForm: ['', Validators.required],
    });
  
  }

  onChange(event : any) {
    this.file = event.target.files[0];
    this.onUpload();
   
  }

  onUpload() {
    this.loading = !this.loading;
    if(this.file != null){   
      this.createImageFromBlob(this.file)
      this.needPhoto = false;
    }
  }

  createImageFromBlob(image: Blob | null) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
      this.imageBlobUrl = reader.result;
    }, false);

    if (image) {
      reader.readAsDataURL(image);
    }
  }

  removeFile(){
    this.loading = false;
    this.needPhoto = true
    console.log(this.myInputVariable?.nativeElement.files);
      if(this.myInputVariable?.nativeElement.value)
          this.myInputVariable.nativeElement.value = "";
    console.log(this.myInputVariable?.nativeElement.files);
  
  }

  onSubmit(){
    let formData = new FormData();
    var data = new Date(this.tehnicalDataForm.value.lastServicesDataForm);
    var dataITP = new Date(this.tehnicalDataForm.value.itpForm)
    if(this.file) {
    
    
      formData.append("Message", this.mentionGroup.value.mentionForm);
      //general dataForm
      formData.append("CarDTO.carBrand", this.generalDataForm.value.brandCarForm);
      formData.append("CarDTO.modelCar", this.generalDataForm.value.modelCarForm);
      formData.append("CarDTO.colorCar", this.generalDataForm.value.colorCarForm);
      formData.append("CarDTO.fuel", this.generalDataForm.value.fuelCarFrom);
      //tehnical Data
      formData.append("CarDTO.year", this.tehnicalDataForm.value.yearForm)
      formData.append("CarDTO.enginePower", this.tehnicalDataForm.value.powerEngineForm)
      formData.append("CarDTO.engine", this.tehnicalDataForm.value.engineCarForm);
      formData.append("CarDTO.fuelConsumption", this.tehnicalDataForm.value.fuelConsumtionForm)
      formData.append("CarDTO.traction", this.tehnicalDataForm.value.tractionForm)
      formData.append("CarDTO.gearBox", this.tehnicalDataForm.value.gearBoxForm)
      formData.append("CarDTO.carKm", this.tehnicalDataForm.value.carKmForm);
      formData.append("CarDTO.lastServicesData", `${data.getFullYear()}-${data.getMonth() + 1}-${data.getDate()}`);
      formData.append("CarDTO.itp", `${dataITP.getFullYear()}-${dataITP.getMonth() + 1}-${dataITP.getDate()}`);
      formData.append("CarDTO.lastServicesKm", this.tehnicalDataForm.value.lastServicesKmForm);

      //confort Data
      formData.append("CarDTO.doorNumbers", this.confortDataForm.value.doorNumbersForm);
      if( this.confortDataForm.value.categoryCarForm?.length > 0){
        this.confortDataForm.value.categoryCarForm.forEach((_element:any, _index:number) =>{ 
          formData.append(`CarDTO.CategoryCar[${_index}].NameCategoryCar`, _element);
        })
      }
      formData.append("CarDTO.seatNumbers", this.confortDataForm.value.seatNumbersForm);
      formData.append("CarDTO.navigation", this.confortDataForm.value.navigationForm)
      formData.append("CarDTO.climate", this.confortDataForm.value.climateForm)
      formData.append("CarDTO.boardComputer", this.confortDataForm.value.boardComputerForm)
      
      //pice data
      formData.append("CarDTO.pricePerDay", this.priceForm.value.priceCarFrom);
      if(localStorage.getItem("Role") == "Admin"){
        formData.append("CarDTO.ActiveFlag", "true");
        formData.append("response", "true")
      }   
    

      formData.append("CarDTO.File", this.file);

    
      this.requestService.addRequest(formData).subscribe(x=>{
        this.generalDataForm.reset();
        this.mentionGroup.reset();
        this.tehnicalDataForm.reset();
        this.confortDataForm.reset();
        this.priceForm.reset();
        this.removeFile();
        this.needPhoto = false;
        this.toastr.success('Cerere trimisa', 'Cererea ta a fost inregistrata cu succes!');
        this.router.navigateByUrl('/rent-car-list');
        // this.dialog.open(RequestAddedComponent, {
        //   data: { 
        //   },
        //   closeOnNavigation: true
        // })
      });

    
    
    
      }
      else{
        this.needPhoto = true;
      }

  }


}





