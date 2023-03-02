import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginRequest } from 'src/app/Interfaces/login-request';
import { LoginResult } from 'src/app/Interfaces/login-result';

//modify header of requests constantly
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  constructor(protected http: HttpClient) {
  }

  public tokenKey: string = "token";

  //authorization endpoint url
  authUrl = environment.baseUrl + 'api/auth/';



  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  login(username: string, password: string): Observable<any> {
    return this.http.post(this.authUrl + 'signin', {
      username,
      password
    }, httpOptions);
  }

  register(username: string, email: string, password: string): Observable<any> {
    return this.http.post(this.authUrl + 'register', {
      username,
      email,
      password
    }, httpOptions);
  }


  /*
  login(item: LoginRequest): Observable<LoginResult> {
    var url = environment.baseUrl + "api/Account/Login";
    return this.http.post<LoginResult>(url, item);
  }
  */


}
