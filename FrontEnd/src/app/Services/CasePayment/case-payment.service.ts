import { Injectable } from '@angular/core';
import { CasePayment } from '../../Models/CasePayment';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Case } from '../../Models/Case';


@Injectable({
  providedIn: 'root'
})
export class CasePaymentService {

  casepayment = { } as CasePayment

  serverUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  Setcasepayment(id, amount, Case: Case) {
    this.casepayment.id = id
    this.casepayment.paymentAmount = amount
    this.casepayment.case = Case
  }

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
