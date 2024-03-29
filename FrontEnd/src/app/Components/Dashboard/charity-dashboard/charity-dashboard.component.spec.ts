import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharityDashboardComponent } from './charity-dashboard.component';

describe('CharityDashboardComponent', () => {
  let component: CharityDashboardComponent;
  let fixture: ComponentFixture<CharityDashboardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CharityDashboardComponent]
    });
    fixture = TestBed.createComponent(CharityDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
