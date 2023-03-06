import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CasestableComponent } from './casestable.component';

describe('CasestableComponent', () => {
  let component: CasestableComponent;
  let fixture: ComponentFixture<CasestableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CasestableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CasestableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
