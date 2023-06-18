import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvideassistanceComponent } from './provideassistance.component';

describe('ProvideassistanceComponent', () => {
  let component: ProvideassistanceComponent;
  let fixture: ComponentFixture<ProvideassistanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProvideassistanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProvideassistanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
