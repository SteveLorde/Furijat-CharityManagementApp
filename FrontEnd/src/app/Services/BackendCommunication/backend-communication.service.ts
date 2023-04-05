import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Case } from 'src/app/Models/Case'
import { Charity } from 'src/app/Models/Charity'

@Injectable({
  providedIn: 'root'
})
export class BackendCommunicationService {

  constructor(private http: HttpClient) { }

  //general url link
  serverUrl = environment.baseUrl;

  //-----------------------------------------------------
  //test url link
  testurl = 'https://jsonplaceholder.typicode.com/users';

  //GET HTTP TEST
  getTEST(): Observable<any> {
    return this.http.get<any>(this.testurl);
  }

  //POST HTTP TEST
  PostTest(_case: Case): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(_case);
    console.log(body)
    return this.http.post<any>(this.testurl, body, { 'headers': headers });
  }

  //PUT/UPDATE HTTP TEST

  //DELETE HTTP TEST

  //GET TEST FOR PAGINATION


  //----------------------------------

  case: Case;


  //PROJECT Endpoints
  
  //GET HTTP for Cases
  getCases(): Observable<Case[]> {
    return this.http.get<Case[]>(this.serverUrl + 'api/Cases');
  }

  //GET HTTP For Case by ID
  getCasesById(id: any): Observable<Case[]> {
    return this.http.get<Case[]>(this.serverUrl + `api/Cases/(getCase/${id}`);
  }


  //GET HTTP for Charities
  getCharity(): Observable<Charity[]> {
    return this.http.get<Charity[]>(this.serverUrl + 'api/Charity');
  }

  //GET HTTP for Users
  getUsers(): Observable<Charity[]> {
    return this.http.get<Charity[]>(this.serverUrl + 'api/User');
  }


  //POST HTTP
  public post(url: string, data: any, options?: any) {
    return this.http.post(url, data, options);
  }

  //POST HTTP for Adding Case
  addCase(troubled: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.serverUrl + 'api/Cases/AddNewCase', troubled, httpOptions);
  }

  //PATCH HTTP for Updating a Case
  updateCase(troubled: any, id: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.serverUrl + `api/Cases/updateCase/${id}`, troubled, httpOptions);
  }

  //DELETE HTTP
  public delete(url: string, options?: any) {
    return this.http.delete(this.serverUrl, options);
  }

}
