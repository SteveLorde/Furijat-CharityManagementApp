import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import {AuthGuard } from 'src/app/Services/AuthGuard/authguard'
import { User } from '../../Models/User';
import { Login } from '../../Models/Login';

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  constructor(private http: HttpClient) {
  }

  ngOnInit(): void { }

  serverUrl = environment.baseUrl;

  currentUser = {};

  userrole: any

  public register(user: User): Observable<any> {
    return this.http.post<any>(this.serverUrl + 'api/Account/register', user);
  }

  public login(user: Login): Observable<any> {
    return this.http.post(this.serverUrl + 'api/Account/login', user)
  }

  SetUserRole(role) {
    this.userrole = role
  }

  showLoggedInUserRole() {
    return this.userrole
  }

  /*
  private setSession(authResult) {
    localStorage.setItem('authToken', authResult.token);
  }
  */

  public accesserror() {
    console.log('you have to login')
  }
}
