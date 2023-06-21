import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddcreditorComponent } from './addcreditor.component';

describe('AddcreditorComponent', () => {
  let component: AddcreditorComponent;
  let fixture: ComponentFixture<AddcreditorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddcreditorComponent]
    });
    fixture = TestBed.createComponent(AddcreditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
