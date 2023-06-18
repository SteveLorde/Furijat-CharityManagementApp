import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DebtorprofileComponent } from './debtorprofile.component';

describe('DebtorprofileComponent', () => {
  let component: DebtorprofileComponent;
  let fixture: ComponentFixture<DebtorprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DebtorprofileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DebtorprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
