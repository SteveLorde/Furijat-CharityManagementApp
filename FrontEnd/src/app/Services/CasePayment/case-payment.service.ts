import { Injectable } from '@angular/core';
import { CasePayment } from '../../Models/CasePayment';
import { BackendCommunicationService } from '../BackendCommunication/backend-communication.service';


@Injectable({
  providedIn: 'root'
})
export class CasePaymentService {

  casepayment: CasePayment

  constructor(private _servercom: BackendCommunicationService) { }

  CasePay() {
    //._servercom.
  }
}
