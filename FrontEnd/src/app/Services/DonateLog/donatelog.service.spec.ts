import { TestBed } from '@angular/core/testing';

import { DonatelogService } from './donatelog.service';

describe('DonatelogService', () => {
  let service: DonatelogService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DonatelogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
