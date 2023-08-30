import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable} from 'rxjs';
import { Case } from 'src/app/Models/Case'
import { Charity } from 'src/app/Models/Charity'
import { User } from '../../Models/User';
import { Creditor } from '../../Models/Creditor';
import { PaymentToCreditor } from '../../Models/PaymentToCreditor';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }

@Injectable({
  providedIn: 'root'
})
export class BackendCommunicationService {

  constructor(private http: HttpClient) { }

  //general url link
  serverUrl = environment.baseUrl;

  //PROJECT Endpoints
  //---------------------------------

  //Case
  getCases(): Observable<Case> {
    return this.http.get<Case>(this.serverUrl + 'api/Cases');
  }

  getCasesById(id: any): Observable<Case> {
    return this.http.get<Case>(this.serverUrl + `api/Cases/(getCase/${id}`);
  }

  addCase(troubled: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.post<any>(this.serverUrl + 'api/Cases/AddNewCase', troubled, httpOptions)
  }

  updateCase(troubled: any, id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.put<any>(this.serverUrl + `api/Cases/updateCase/${id}`, troubled, httpOptions)
  }

  DeleteCase(id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.delete<any>(this.serverUrl + `api/Case/deleteCase/${id}`)
  }


  //Charity
  getCharity(): Observable<Charity> {
    return this.http.get<Charity>(this.serverUrl + 'api/Charity');
  }

  getCharitybyId(id: any): Observable<Charity> {
    return this.http.get<Charity>(this.serverUrl + `api/Charity/getCharity/${id}`);
  }

  addCharity(charity: any): Observable<any> {
    
    return this.http.post<any>(this.serverUrl + 'api/Charity/AddNewCharity', charity, httpOptions);
  }

  UpdateCharitybyID(id: any, charity:any): Observable<Charity> {
    
    return this.http.put<Charity>(this.serverUrl + `api/Charity/updateCharity/${id}`, charity, httpOptions);
  }

  DeleteCharity(id: any): Observable<any> {
    
    return this.http.delete<any>(this.serverUrl + `api/Charity/deleteCharity/${id}`);
  }

  //User
  getUsers(): Observable<User> {
    return this.http.get<User>(this.serverUrl + 'api/User');
  }

  getUserbyId(id: any): Observable<User> {
    return this.http.get<User>(this.serverUrl + `api/User/(getUser/${id}`)
  }

  addUser(user: any): Observable<any> {
    
    return this.http.post<any>(this.serverUrl + '/api/User/AddNewUser', user, httpOptions)
  }

  UpdateUser(user: any, id: any): Observable<any> {
    
    return this.http.put<any>(this.serverUrl + `/api/User/updateUser/${id}`, user, httpOptions)
  }

  DeleteUser(id: any): Observable<any> {
    
    return this.http.delete<any>(this.serverUrl + `/api/User/deleteUser/${id}`)
  }

  //Creditor
  GetCreditor(): Observable<any> {
    return this.http.get<any>(this.serverUrl + '/api/Creditor')
  }
  GetCreditorByID(id: any): Observable<any> {
    return this.http.get<any>(this.serverUrl + `/api/Creditor/getCreditor/${id}`)
  }

  addCreditor(creditor: any): Observable<any> {

    return this.http.post<any>(this.serverUrl + '/api/Creditor/AddNewCreditor', creditor, httpOptions)
  }

  UpdateCreditorByID(id: any, creditor: any): Observable<any> {
    return this.http.put<any>(this.serverUrl + `/api/Creditor/updateCreditor/${id}`, creditor)
  }

  DeleteCreditor(id: any): Observable<any> {
    return this.http.delete<any>(this.serverUrl + `/api/Creditor/deleteCreditor/${id}`)
  }

  //Donator
  GetDonator(): Observable<any> {
    return this.http.get<any>(this.serverUrl + '/api/Donator')
  }

  GetDonatorByID(id: any): Observable<any> {
    return this.http.get<any>(this.serverUrl + `/api/Donator/getDonator/${id}`)
  }

  addDonator(donator: any): Observable<any> {
    return this.http.post<any>(this.serverUrl + '/api/Donator/AddNewDonator', donator, httpOptions)
  }

  UpdateDonatorByID(id: any, donator: any): Observable<any> {
    return this.http.put<any>(this.serverUrl + `/api/Donator/updateDonator/${id}`, donator)
  }

  DeleteDonator(id: any): Observable<any> {
    return this.http.delete<any>(this.serverUrl + `/api/Donator/deleteDonator/${id}`)
  }

  //PaymentToCreditor
  GetPToC(): Observable<PaymentToCreditor>
  {
    return this.http.get<PaymentToCreditor>(this.serverUrl + '/api/PaymentToCreditor')
  }

  GetPToCByID(id: any): Observable<PaymentToCreditor> {
    return this.http.get<PaymentToCreditor>(this.serverUrl + `/api/PaymentToCreditor/getPaymentforCreditor/${id}`)
  }

  AddPToC(paymentcreditor: PaymentToCreditor): Observable<PaymentToCreditor> {
    return this.http.post<PaymentToCreditor>(this.serverUrl + `/api/PaymentToCreditor/AddPaymentToCreditor`, paymentcreditor)
  }

}
