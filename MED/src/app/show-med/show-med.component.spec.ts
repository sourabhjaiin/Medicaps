import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowMedComponent } from './show-med.component';

describe('ShowMedComponent', () => {
  let component: ShowMedComponent;
  let fixture: ComponentFixture<ShowMedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowMedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowMedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
