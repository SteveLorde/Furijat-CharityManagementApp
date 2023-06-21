import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdddonatorComponent } from './adddonator.component';

describe('AdddonatorComponent', () => {
  let component: AdddonatorComponent;
  let fixture: ComponentFixture<AdddonatorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdddonatorComponent]
    });
    fixture = TestBed.createComponent(AdddonatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
