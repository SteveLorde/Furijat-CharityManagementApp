import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonatecharityComponent } from './donatecharity.component';

describe('DonatecharityComponent', () => {
  let component: DonatecharityComponent;
  let fixture: ComponentFixture<DonatecharityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DonatecharityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DonatecharityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
