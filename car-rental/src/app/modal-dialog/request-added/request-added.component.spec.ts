import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestAddedComponent } from './request-added.component';

describe('RequestAddedComponent', () => {
  let component: RequestAddedComponent;
  let fixture: ComponentFixture<RequestAddedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestAddedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestAddedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
