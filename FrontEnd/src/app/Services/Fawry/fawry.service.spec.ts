import { TestBed } from '@angular/core/testing';

import { FawryService } from './fawry.service';

describe('FawryService', () => {
  let service: FawryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FawryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
