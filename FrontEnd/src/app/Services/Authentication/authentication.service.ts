import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

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

}
