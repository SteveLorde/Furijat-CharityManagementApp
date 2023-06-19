import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Case } from '../../Models/Case';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }


@Injectable({
  providedIn: 'root'
})
export class CasePaymentService {
  /*
  casepayment = { } as CasePayment

  serverUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  Setcasepayment(id, amount, Case: Case) {
    this.casepayment.id = id
    this.casepayment.paymentAmount = amount
    this.casepayment.case = Case
  }

  getCasePayment(): Observable<CasePayment> {
    return this.http.get<CasePayment>(this.serverUrl + 'api/CasePayment')
  }

  getCasePaymentByID(id: any): Observable<CasePayment> {
    return this.http.get<CasePayment>(this.serverUrl + `/api/CasePayment/(getCasePayment/${id}`)
  }

  AddCasePayment(): Observable<CasePayment> {

    return this.http.post<CasePayment>(this.serverUrl + 'api/CasePayment/AddNewCasePayment', httpOptions)
  }

  UpdateCasePaymentBy(id: any): Observable<CasePayment> {

    return this.http.put<CasePayment>(this.serverUrl + `/api/CasePayment/updateCasePayment/${id}`, httpOptions)
  }

  DeleteCasePayment(): Observable<CasePayment> {
    return this.http.delete<CasePayment>(this.serverUrl + 'api/CasePayment/AddNewCasePayment', httpOptions)
  }

*/
}
