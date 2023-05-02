import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable} from 'rxjs';
import { CaseDTO } from 'src/app/Models/CaseDTO'
import { Charity } from 'src/app/Models/CharityDTO'
import { UserDTO } from '../../Models/UserDTO';
import { CasePayment } from '../../Models/CasePayment';

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
  getCases(): Observable<CaseDTO> {
    return this.http.get<CaseDTO>(this.serverUrl + 'api/Cases');
  }

  getCasesById(id: any): Observable<CaseDTO> {
    return this.http.get<CaseDTO>(this.serverUrl + `api/Cases/(getCase/${id}`);
  }

  addCase(troubled: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.serverUrl + 'api/Cases/AddNewCase', troubled, httpOptions);
  }

  updateCase(troubled: any, id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.serverUrl + `api/Cases/updateCase/${id}`, troubled, httpOptions);
  }

  DeleteCase(id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<any>(this.serverUrl + `api/Case/deleteCase/${id}`);
  }


  //Charity
  getCharity(): Observable<Charity> {
    return this.http.get<Charity>(this.serverUrl + 'api/Charity');
  }

  getCharitybyId(id: any): Observable<Charity> {
    return this.http.get<Charity>(this.serverUrl + `api/Charity/getCharity/${id}`);
  }

  addCharity(charity: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.serverUrl + 'api/Charity/AddNewCharity', charity, httpOptions);
  }

  UpdateCharityby(id: any): Observable<Charity> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.put<Charity>(this.serverUrl + `api/Charity/updateCharity/${id}`, httpOptions);
  }

  DeleteCharity(id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<any>(this.serverUrl + `api/Charity/deleteCharity/${id}`);
  }

  //User
  getUsers(): Observable<UserDTO> {
    return this.http.get<UserDTO>(this.serverUrl + 'api/User');
  }

  getUserbyId(id: any): Observable<UserDTO> {
    return this.http.get<UserDTO>(this.serverUrl + `api/User/(getUser/${id}`)
  }

  addUser(user: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.serverUrl + '/api/User/AddNewUser', user, httpOptions);
  }

  UpdateUser(user: any, id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.serverUrl + `/api/User/updateUser/${id}`, user, httpOptions);
  }

  DeleteUser(id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<any>(this.serverUrl + `/api/User/deleteUser/${id}`);
  }

  //CasePayment
  getCasePayment(): Observable<CasePayment> {
    return this.http.get<CasePayment>(this.serverUrl + 'api/CasePayment');
  }

  getCasePaymentByID(id: any): Observable<CasePayment> {
    return this.http.get<CasePayment>(this.serverUrl + `/api/CasePayment/(getCasePayment/${id}`);
  }

  AddCasePayment(): Observable<CasePayment> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.post<CasePayment>(this.serverUrl + 'api/CasePayment/AddNewCasePayment', httpOptions)
  }

  UpdateCasePaymentBy(id: any): Observable<CasePayment> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.put<CasePayment>(this.serverUrl + `/api/CasePayment/updateCasePayment/${id}`, httpOptions)
  }

  DeleteCasePayment(): Observable<CasePayment> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.delete<CasePayment>(this.serverUrl + 'api/CasePayment/AddNewCasePayment', httpOptions)
  }

}
