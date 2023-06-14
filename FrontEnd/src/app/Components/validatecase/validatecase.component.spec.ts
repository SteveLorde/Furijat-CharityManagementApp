import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidatecaseComponent } from './validatecase.component';

describe('ValidatecaseComponent', () => {
  let component: ValidatecaseComponent;
  let fixture: ComponentFixture<ValidatecaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValidatecaseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidatecaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
