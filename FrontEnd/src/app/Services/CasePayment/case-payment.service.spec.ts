import { TestBed } from '@angular/core/testing';

import { CasePaymentService } from './case-payment.service';

describe('CasePaymentService', () => {
  let service: CasePaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CasePaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
