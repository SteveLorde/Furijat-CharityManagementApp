import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactformbackendComponent } from './contactformbackend.component';

describe('ContactformbackendComponent', () => {
  let component: ContactformbackendComponent;
  let fixture: ComponentFixture<ContactformbackendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactformbackendComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactformbackendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
