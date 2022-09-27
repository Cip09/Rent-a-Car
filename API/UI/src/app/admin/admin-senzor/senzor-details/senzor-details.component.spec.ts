import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SenzorDetailsComponent } from './senzor-details.component';

describe('SenzorDetailsComponent', () => {
  let component: SenzorDetailsComponent;
  let fixture: ComponentFixture<SenzorDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SenzorDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SenzorDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
