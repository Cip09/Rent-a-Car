import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestSchedulingComponent } from './request-scheduling.component';

describe('RequestSchedulingComponent', () => {
  let component: RequestSchedulingComponent;
  let fixture: ComponentFixture<RequestSchedulingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestSchedulingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestSchedulingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
