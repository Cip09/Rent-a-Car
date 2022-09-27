import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminRentCarListComponent } from './admin-rent-car-list.component';

describe('AdminRentCarListComponent', () => {
  let component: AdminRentCarListComponent;
  let fixture: ComponentFixture<AdminRentCarListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminRentCarListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminRentCarListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
