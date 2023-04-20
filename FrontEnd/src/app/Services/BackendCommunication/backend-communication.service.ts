import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { CaseDTO } from 'src/app/Models/CaseDTO'
import { Charity } from 'src/app/Models/CharityDTO'
import { UserDTO } from '../../Models/UserDTO';

@Injectable({
  providedIn: 'root'
})
export class BackendCommunicationService {

  constructor(private http: HttpClient) { }

  //general url link
  serverUrl = environment.baseUrl;

  //PROJECT Endpoints
  //---------------------------------


  //GET
  //----------------------------------------
  //GET HTTP for Cases
  getCases(): Observable<CaseDTO[]> {
    return this.http.get<CaseDTO[]>(this.serverUrl + 'api/Cases');
  }

  //GET HTTP For Case by ID
  getCasesById(id: any): Observable<CaseDTO[]> {
    return this.http.get<CaseDTO[]>(this.serverUrl + `api/Cases/(getCase/${id}`);
  }


  //GET HTTP for Charities
  getCharity(): Observable<Charity[]> {
    return this.http.get<Charity[]>(this.serverUrl + 'api/Charity');
  }

  //GET HTTP for Users by ID
  getCharitybyId(id: any): Observable<Charity[]> {
    return this.http.get<Charity[]>(this.serverUrl + `api/Charity/getCharity/${id}`);
  }


  //GET HTTP for Users
  getUsers(): Observable<UserDTO[]> {
    return this.http.get<UserDTO[]>(this.serverUrl + 'api/User');
  }

  //GET HTTP for Users by ID
  getUserbyId(id: any): Observable<UserDTO> {
    return this.http.get<UserDTO>(this.serverUrl + `api/User/(getUser/${id}`);
  }

  //----------------------------------

  //-POST
  //-----------------------------
  //POST HTTP for Adding Case
  addCase(troubled: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.serverUrl + 'api/Cases/AddNewCase', troubled, httpOptions);
  }

  //POST HTTP for Adding Charity
  addCharity(charity: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.serverUrl + 'api/Charity/AddNewCharity', charity, httpOptions);
  }

  //-----------------------------------------------


  //PATCH HTTP for Updating a Case
  updateCase(troubled: any, id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.serverUrl + `api/Cases/updateCase/${id}`, troubled, httpOptions);
  }

  //-----------------------------------------


  //DELETE HTTP
  public delete(url: string, options?: any) {
    return this.http.delete(this.serverUrl, options);
  }

  DeleteCharity(id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<any>(this.serverUrl + `api/Charity/deleteCharity/${id}`);
  }

}
