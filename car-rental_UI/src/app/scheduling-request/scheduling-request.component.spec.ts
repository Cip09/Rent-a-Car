import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchedulingRequestComponent } from './scheduling-request.component';

describe('SchedulingRequestComponent', () => {
  let component: SchedulingRequestComponent;
  let fixture: ComponentFixture<SchedulingRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchedulingRequestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchedulingRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
