import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetreaCarModalComponent } from './retrea-car-modal.component';

describe('RetreaCarModalComponent', () => {
  let component: RetreaCarModalComponent;
  let fixture: ComponentFixture<RetreaCarModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RetreaCarModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RetreaCarModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
