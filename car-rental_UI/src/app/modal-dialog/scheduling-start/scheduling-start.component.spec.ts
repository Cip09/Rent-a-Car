import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchedulingStartComponent } from './scheduling-start.component';

describe('SchedulingStartComponent', () => {
  let component: SchedulingStartComponent;
  let fixture: ComponentFixture<SchedulingStartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchedulingStartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchedulingStartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
