import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsRetreatCarComponent } from './details-retreat-car.component';

describe('DetailsRetreatCarComponent', () => {
  let component: DetailsRetreatCarComponent;
  let fixture: ComponentFixture<DetailsRetreatCarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsRetreatCarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsRetreatCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
