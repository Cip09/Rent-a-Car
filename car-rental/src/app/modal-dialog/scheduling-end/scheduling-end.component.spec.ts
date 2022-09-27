import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchedulingEndComponent } from './scheduling-end.component';

describe('SchedulingEndComponent', () => {
  let component: SchedulingEndComponent;
  let fixture: ComponentFixture<SchedulingEndComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchedulingEndComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchedulingEndComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
