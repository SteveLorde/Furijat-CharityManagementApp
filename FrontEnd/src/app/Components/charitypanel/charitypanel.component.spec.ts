import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharitypanelComponent } from './charitypanel.component';

describe('CharitypanelComponent', () => {
  let component: CharitypanelComponent;
  let fixture: ComponentFixture<CharitypanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CharitypanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharitypanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
