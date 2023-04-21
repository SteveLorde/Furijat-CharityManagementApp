import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharitydonationComponent } from './charitydonation.component';

describe('CharitydonationComponent', () => {
  let component: CharitydonationComponent;
  let fixture: ComponentFixture<CharitydonationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CharitydonationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CharitydonationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
