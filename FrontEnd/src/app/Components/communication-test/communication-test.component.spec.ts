import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunicationTestComponent } from './communication-test.component';

describe('CommunicationTestComponent', () => {
  let component: CommunicationTestComponent;
  let fixture: ComponentFixture<CommunicationTestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommunicationTestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CommunicationTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
