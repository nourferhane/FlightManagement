import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightFullDetailsComponent } from './flight-full-details.component';

describe('FlightFullDetailsComponent', () => {
  let component: FlightFullDetailsComponent;
  let fixture: ComponentFixture<FlightFullDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FlightFullDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightFullDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
