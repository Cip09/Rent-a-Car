import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestRetreatCarComponent } from './request-retreat-car.component';

describe('RequestRetreatCarComponent', () => {
  let component: RequestRetreatCarComponent;
  let fixture: ComponentFixture<RequestRetreatCarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestRetreatCarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestRetreatCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
