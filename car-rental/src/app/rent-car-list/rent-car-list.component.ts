import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CarModel } from '../models/carModel';
import { FilterModel } from '../models/filterModel';
import { CarService } from '../service/car.service';

@Component({
  selector: 'app-rent-car-list',
  templateUrl: './rent-car-list.component.html',
  styleUrls: ['./rent-car-list.component.css']
})
export class RentCarListComponent implements OnInit {
  
  BrandCar: string[] = ['Acura','Aixam','Alfa Romeo','Aro','Aston Martin','Audi','Bentley','BMW','Buick','Bugatti',
  'Cadillac','Chaika','Chevrolet','Citroen','Dacia','Daewoo','Daihatsu','Chrysler','Dodge','Eagle','Ferrari',
  'Fiat','Ford','GMC','Honda','Hummer','Hyundai','Infiniti','Isuzu','Jaguar','Jeep','Kia','Lada','Lamborghini','Lancia',
  'Land Rover','Lexus','Lincoln','Maserati','Mazda','Mercedes-Benz','Mitsubishi','Mini','Nissan','Oltcit','Opel','Peugeot',
  'Pontiac','Porsche','Range Rover','Renault',' Rolls-Royce','Saab','Seat','Skoda','Smart','SsangYoung','Subaru','Suzuki','Tesla',
  'Toyota','Volkswagen','Volvo']
;

  gearBox: string[] = ['Automata', 'Manuala']

  traction: string[] = ['Fata','Spate','Integrala(4x4)']

  fuel: string[] = ['Benzina','Motorina']

  BrandListFilter: string[] = []
  GearBoxListFilter: string[] = []
  TractionListFilter: string[] = []
  FuelListFilter: string[] = []



  dataPickerForm : FormGroup = new FormGroup({
    takeDataForm: new FormControl(''),
    returnDataForm: new FormControl(''),
  
  })

  filterFormGroup: FormGroup = new FormGroup({
    brandCarFilterForm: new FormControl(''),
    gearBoxFilterForm: new FormControl(''),
    tractionFilterForm: new FormControl(''),
    fuelFilterForm: new FormControl('')
  })

  minDate:Date | undefined;
  maxDate: Date | undefined
  maxDateTake: Date | undefined
  today = new Date()
  userLogin : string = "" 


  constructor(private carService: CarService, private router: Router) { }

  rentCarList:CarModel[] = []
  recommendedCars: CarModel[] = []

  ngOnInit(): void {
    this.getAllCar();
    this.getRecommendedCar();
    // localStorage.getItem("Role") 

    this.userLogin =  localStorage.getItem("Role")!
    console.log(this.userLogin) 
    this.minDate = this.today
    this.dataPickerForm.valueChanges.subscribe(res=>{
      this.minDate = new Date(res.takeDataForm);
      this.maxDate = new Date(res.takeDataForm)
      this.maxDate.setDate(this.maxDate.getDate() + 5)
      this.maxDateTake = new Date(res.returnDataForm)
   });
  }

  getAllCar(){
    this.carService.getAllCar().subscribe(x => {
      x.forEach((element: any) => {
        if(new Date(element.itp) > this.today ){
          this.rentCarList!.push(element)
        }
      });
    
      //this.rentCarList = x
    })
  }

  AddFilter(){
    let dataStart = new Date(0)
    let dataEnd = new Date(0)
    if(this.dataPickerForm.value.takeDataForm != "")
      dataStart = new Date(this.dataPickerForm.value.takeDataForm)

      if(this.dataPickerForm.value.returnDataForm != "")
      dataEnd = new Date(this.dataPickerForm.value.returnDataForm)    

      debugger
    let filter : FilterModel = {
      brandFilterList:  this.filterFormGroup.value.brandCarFilterForm != '' ? this.filterFormGroup.value.brandCarFilterForm : new Array<string>(),
      gearBoxFilterList: this.filterFormGroup.value.gearBoxFilterForm != '' ? this.filterFormGroup.value.gearBoxFilterForm : new Array<string>(),
      fuelFilterList: this.filterFormGroup.value.fuelFilterForm != '' ? this.filterFormGroup.value.fuelFilterForm : new Array<string>(),
      tractionFilterList: this.filterFormGroup.value.tractionFilterForm != '' ? this.filterFormGroup.value.tractionFilterForm : new Array<string>(),
      startDate: dataStart,
      endDate: dataEnd
    }

    debugger

    this.carService.postFilter(filter).subscribe(x=>{
       // this.rentCarList = x;
       this.rentCarList = []
       x.forEach((element: any) => {
        if(new Date(element.itp) > this.today ){
          this.rentCarList!.push(element)
        }
      });
    })
  }

  removeFilter(){
    this.rentCarList = []
    this.getAllCar()
   
    this.dataPickerForm.patchValue({takeDataForm : ""})
    this.dataPickerForm.patchValue({returnDataForm : ""})

    this.filterFormGroup.reset();
    debugger
    this.filterFormGroup.patchValue({brandCarFilterForm : ''}) 
    this.filterFormGroup.patchValue({gearBoxFilterForm : ''}) 
    this.filterFormGroup.patchValue({fuelFilterForm : ''}) 
    this.filterFormGroup.patchValue({tractionFilterForm : ''}) 

  }

  getRecommendedCar(){
    this.carService.getRecommendedCar().subscribe(x => {
      this.recommendedCars = x
    })
  }

}
