import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonatorDashboardComponent } from './donator-dashboard.component';

describe('DonatorDashboardComponent', () => {
  let component: DonatorDashboardComponent;
  let fixture: ComponentFixture<DonatorDashboardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DonatorDashboardComponent]
    });
    fixture = TestBed.createComponent(DonatorDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
