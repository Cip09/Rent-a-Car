import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarDetalisComponent } from './car-detalis.component';

describe('CarDetalisComponent', () => {
  let component: CarDetalisComponent;
  let fixture: ComponentFixture<CarDetalisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarDetalisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarDetalisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
