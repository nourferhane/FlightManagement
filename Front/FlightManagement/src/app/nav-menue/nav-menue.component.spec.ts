import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavMenueComponent } from './nav-menue.component';

describe('NavMenueComponent', () => {
  let component: NavMenueComponent;
  let fixture: ComponentFixture<NavMenueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavMenueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavMenueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
