import { Injectable } from '@angular/core';
import { CasePayment } from '../../Models/CasePayment';
import { BackendCommunicationService } from '../BackendCommunication/backend-communication.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class CasePaymentService {

  casepayment: CasePayment

  serverUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  CasePay(): Observable<any> {
    return this.http.post<any>(this.serverUrl + 'api/CasePayment/AddNewCasePayment', this.casepayment)
  }

  getCasePay(): Observable<any> {
    return this.http.get<any>(this.serverUrl + 'api/CasePayment')
  }

  getCasePayID(id: any): Observable<any> {
    return this.http.get<any>(this.serverUrl + `api/CasePayment/(getCasePayment/${id}`)
  }

}
