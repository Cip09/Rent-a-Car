import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSenzorComponent } from './admin-senzor.component';

describe('AdminSenzorComponent', () => {
  let component: AdminSenzorComponent;
  let fixture: ComponentFixture<AdminSenzorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminSenzorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSenzorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
