import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginRequest } from './login-request';
import { LoginResult } from './login-result';

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  constructor(protected http: HttpClient) {
  }

  public tokenKey: string = "token";

  //authorization endpoint url
  authUrl = environment.baseUrl + 'api/auth';

  //modify header of requests
  httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  login(username: string, password: string): Observable<any> {
    return this.http.post(this.authUrl, {
      username,
      password
    }, this.httpOptions);
  }

  register(username: string, email: string, password: string): Observable<any> {
    return this.http.post(this.authUrl, {
      username,
      email,
      password
    }, this.httpOptions);
  }


  /*
  login(item: LoginRequest): Observable<LoginResult> {
    var url = environment.baseUrl + "api/Account/Login";
    return this.http.post<LoginResult>(url, item);
  }
  */


}
