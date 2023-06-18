import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharityprofileComponent } from './charityprofile.component';

describe('CharityprofileComponent', () => {
  let component: CharityprofileComponent;
  let fixture: ComponentFixture<CharityprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CharityprofileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharityprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
