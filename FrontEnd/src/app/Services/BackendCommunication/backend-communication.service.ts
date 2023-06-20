import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable} from 'rxjs';
import { Case } from 'src/app/Models/Case'
import { Charity } from 'src/app/Models/Charity'
import { User } from '../../Models/User';
import { Creditor } from '../../Models/Creditor';
import { PaymentToCreditor } from '../../Models/PaymentToCreditor';
import { Donator } from '../../Models/Donator';

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

  getCasesById(id: number): Observable<Case> {
    return this.http.get<Case>(this.serverUrl + `api/Cases/(getCase/${id}`);
  }

  addCase(troubled: Case): Observable<Case> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.post<Case>(this.serverUrl + 'api/Cases/AddNewCase', troubled, httpOptions)
  }

  updateCase(id: number, troubled: Case): Observable<Case> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.put<Case>(this.serverUrl + `api/Cases/updateCase/${id}`, troubled, httpOptions)
  }

  DeleteCase(id: number): Observable<Case> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.delete<Case>(this.serverUrl + `api/Case/deleteCase/${id}`)
  }


  //Charity
  getCharity(): Observable<Charity> {
    return this.http.get<Charity>(this.serverUrl + 'api/Charity');
  }

  getCharitybyId(id: number): Observable<Charity> {
    return this.http.get<Charity>(this.serverUrl + `api/Charity/getCharity/${id}`);
  }

  addCharity(charity: Charity): Observable<Charity> {
    
    return this.http.post<Charity>(this.serverUrl + 'api/Charity/AddNewCharity', charity, httpOptions);
  }

  UpdateCharitybyID(id: number, charity: Charity): Observable<Charity> {
    
    return this.http.put<Charity>(this.serverUrl + `api/Charity/updateCharity/${id}`, charity, httpOptions);
  }

  DeleteCharity(id: number): Observable<Charity> {
    
    return this.http.delete<Charity>(this.serverUrl + `api/Charity/deleteCharity/${id}`);
  }

  //User
  getUsers(): Observable<User> {
    return this.http.get<User>(this.serverUrl + 'api/User');
  }

  getUserbyId(id: number): Observable<User> {
    return this.http.get<User>(this.serverUrl + `api/User/(getUser/${id}`)
  }

  addUser(user: number): Observable<User> {
    
    return this.http.post<any>(this.serverUrl + '/api/User/AddNewUser', user, httpOptions)
  }

  UpdateUser(id: number,user: User): Observable<User> {
    
    return this.http.put<User>(this.serverUrl + `/api/User/updateUser/${id}`, user, httpOptions)
  }

  DeleteUser(id: number): Observable<User> {
    
    return this.http.delete<User>(this.serverUrl + `/api/User/deleteUser/${id}`)
  }

  //Creditor
  GetCreditor(): Observable<Creditor> {
    return this.http.get<Creditor>(this.serverUrl + '/api/Creditor')
  }
  GetCreditorByID(id: number): Observable<Creditor> {
    return this.http.get<Creditor>(this.serverUrl + `/api/Creditor/getCreditor/${id}`)
  }

  addCreditor(creditor: Creditor): Observable<Creditor> {

    return this.http.post<Creditor>(this.serverUrl + '/api/Creditor/AddNewCreditor', creditor, httpOptions)
  }

  UpdateCreditorByID(id: number, creditor: Creditor): Observable<Creditor> {
    return this.http.put<Creditor>(this.serverUrl + `/api/Creditor/updateCreditor/${id}`, creditor)
  }

  DeleteCreditor(id: number): Observable<Creditor> {
    return this.http.delete<Creditor>(this.serverUrl + `/api/Creditor/deleteCreditor/${id}`)
  }

  //Donator
  GetDonator(): Observable<Donator> {
    return this.http.get<Donator>(this.serverUrl + '/api/Donator')
  }

  GetDonatorByID(id: number): Observable<Donator> {
    return this.http.get<any>(this.serverUrl + `/api/Donator/getDonator/${id}`)
  }

  addDonator(donator: Donator): Observable<Donator> {
    return this.http.post<Donator>(this.serverUrl + '/api/Donator/AddNewDonator', donator, httpOptions)
  }

  UpdateDonatorByID(id: number, donator: Donator): Observable<Donator> {
    return this.http.put<Donator>(this.serverUrl + `/api/Donator/updateDonator/${id}`, donator)
  }

  DeleteDonator(id: number): Observable<Donator> {
    return this.http.delete<Donator>(this.serverUrl + `/api/Donator/deleteDonator/${id}`)
  }

  //PaymentToCreditor
  GetPToC(): Observable<PaymentToCreditor>
  {
    return this.http.get<PaymentToCreditor>(this.serverUrl + '/api/PaymentToCreditor')
  }

  GetPToCByID(id: number): Observable<PaymentToCreditor> {
    return this.http.get<PaymentToCreditor>(this.serverUrl + `/api/PaymentToCreditor/getPaymentforCreditor/${id}`)
  }

  AddPToC(paymentcreditor: PaymentToCreditor): Observable<PaymentToCreditor> {
    return this.http.post<PaymentToCreditor>(this.serverUrl + `/api/PaymentToCreditor/AddPaymentToCreditor`, paymentcreditor)
  }

}
