import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaseDashboardComponent } from './case-dashboard.component';

describe('CaseDashboardComponent', () => {
  let component: CaseDashboardComponent;
  let fixture: ComponentFixture<CaseDashboardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CaseDashboardComponent]
    });
    fixture = TestBed.createComponent(CaseDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
