import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowpharmComponent } from './showpharm.component';

describe('ShowpharmComponent', () => {
  let component: ShowpharmComponent;
  let fixture: ComponentFixture<ShowpharmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowpharmComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowpharmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
