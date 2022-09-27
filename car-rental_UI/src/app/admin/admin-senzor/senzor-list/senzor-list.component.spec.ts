import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SenzorListComponent } from './senzor-list.component';

describe('SenzorListComponent', () => {
  let component: SenzorListComponent;
  let fixture: ComponentFixture<SenzorListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SenzorListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SenzorListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
