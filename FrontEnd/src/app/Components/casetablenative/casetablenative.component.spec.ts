import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CasetablenativeComponent } from './casetablenative.component';

describe('CasetablenativeComponent', () => {
  let component: CasetablenativeComponent;
  let fixture: ComponentFixture<CasetablenativeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CasetablenativeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CasetablenativeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
