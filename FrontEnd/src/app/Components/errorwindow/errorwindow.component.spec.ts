import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ErrorwindowComponent } from './errorwindow.component';

describe('ErrorwindowComponent', () => {
  let component: ErrorwindowComponent;
  let fixture: ComponentFixture<ErrorwindowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ErrorwindowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ErrorwindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
