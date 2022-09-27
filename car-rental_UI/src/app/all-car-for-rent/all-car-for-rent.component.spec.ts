import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllCarForRentComponent } from './all-car-for-rent.component';

describe('AllCarForRentComponent', () => {
  let component: AllCarForRentComponent;
  let fixture: ComponentFixture<AllCarForRentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllCarForRentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllCarForRentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
