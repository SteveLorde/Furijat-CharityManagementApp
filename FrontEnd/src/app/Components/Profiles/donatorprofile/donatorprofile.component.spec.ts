import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonatorprofileComponent } from './donatorprofile.component';

describe('DonatorprofileComponent', () => {
  let component: DonatorprofileComponent;
  let fixture: ComponentFixture<DonatorprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DonatorprofileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DonatorprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
