import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreditorpanelComponent } from './creditorpanel.component';

describe('CreditorpanelComponent', () => {
  let component: CreditorpanelComponent;
  let fixture: ComponentFixture<CreditorpanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreditorpanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreditorpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
