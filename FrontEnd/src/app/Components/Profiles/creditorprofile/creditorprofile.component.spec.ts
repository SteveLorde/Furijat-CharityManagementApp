import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreditorprofileComponent } from './creditorprofile.component';

describe('CreditorprofileComponent', () => {
  let component: CreditorprofileComponent;
  let fixture: ComponentFixture<CreditorprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreditorprofileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreditorprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
