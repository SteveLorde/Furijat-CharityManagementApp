import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpInterceptor } from '@angular/common/http';
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

  //test url link
  testurl = 'http://localhost:3000/Cases';

  //GET HTTP TEST
  getTEST(): Observable<Case> {
    return this.http.get<Case>(this.testurl);
  }

  //GET HTTP for Cases
  getCases(): Observable<Case[]> {
     return this.http.get<Case[]>(this.serverUrl + 'api/Cases');
  }

  //GET HTTP for Charities
  getCharity(): Observable<Charity[]> {
    return this.http.get<Charity[]>(this.serverUrl + 'api/Charity');
  }



  //POST HTTP
  public post(url: string, data: any, options?: any) {
    return this.http.post(url, data, options);
  }

  //PUT HTTP
  public put(url: string, data: any, options?: any) {
    return this.http.put(url, data, options);
  }

  //DELETE HTTP
  public delete(url: string, options?: any) {
    return this.http.delete(url, options);
  }

}
