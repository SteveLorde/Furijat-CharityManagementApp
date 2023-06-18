import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewpaymentplanComponent } from './viewpaymentplan.component';

describe('ViewpaymentplanComponent', () => {
  let component: ViewpaymentplanComponent;
  let fixture: ComponentFixture<ViewpaymentplanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewpaymentplanComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewpaymentplanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
