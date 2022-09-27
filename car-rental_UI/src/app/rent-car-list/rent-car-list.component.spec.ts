import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentCarListComponent } from './rent-car-list.component';

describe('RentCarListComponent', () => {
  let component: RentCarListComponent;
  let fixture: ComponentFixture<RentCarListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RentCarListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RentCarListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
