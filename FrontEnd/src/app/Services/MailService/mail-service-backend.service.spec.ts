import { TestBed } from '@angular/core/testing';

import { MailServiceBackendService } from './mail-service-backend.service';

describe('MailServiceBackendService', () => {
  let service: MailServiceBackendService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MailServiceBackendService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
