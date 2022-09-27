import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminDisabledCarComponent } from './admin-disabled-car.component';

describe('AdminDisabledCarComponent', () => {
  let component: AdminDisabledCarComponent;
  let fixture: ComponentFixture<AdminDisabledCarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminDisabledCarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminDisabledCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
