import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarDetailsAdminModalComponent } from './car-details-admin-modal.component';

describe('CarDetailsAdminModalComponent', () => {
  let component: CarDetailsAdminModalComponent;
  let fixture: ComponentFixture<CarDetailsAdminModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarDetailsAdminModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarDetailsAdminModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
