import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DebtorpanelComponent } from './debtorpanel.component';

describe('DebtorpanelComponent', () => {
  let component: DebtorpanelComponent;
  let fixture: ComponentFixture<DebtorpanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DebtorpanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DebtorpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
