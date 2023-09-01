import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharitiesPageComponent } from './charities-page.component';

describe('CharitiesPageComponent', () => {
  let component: CharitiesPageComponent;
  let fixture: ComponentFixture<CharitiesPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CharitiesPageComponent]
    });
    fixture = TestBed.createComponent(CharitiesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
