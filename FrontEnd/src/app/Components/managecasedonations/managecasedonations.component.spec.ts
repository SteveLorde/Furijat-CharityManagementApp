import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagecasedonationsComponent } from './managecasedonations.component';

describe('ManagecasedonationsComponent', () => {
  let component: ManagecasedonationsComponent;
  let fixture: ComponentFixture<ManagecasedonationsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ManagecasedonationsComponent]
    });
    fixture = TestBed.createComponent(ManagecasedonationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
