import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {User} from "../../Data/Models/User";
import {LoginModel} from "./Models/LoginModel";
import {RegisterModel} from "./Models/RegisterModel";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  serverUrl = environment.baseUrl;

  currentUser : User

  userrole: any

  public register(registeruser : RegisterModel): Observable<any> {
    return this.http.post<any>(this.serverUrl + 'api/Account/register', user);
  }

  public login(user: LoginModel): Observable<any> {
     return this.http.post(this.serverUrl + 'api/Account/login', user)
  }

  SetUserRole(loginmodel : LoginModel) {
    this.currentUser.username = loginmodel.username
    this.currentUser.password = loginmodel.password
    this.currentUser.usertype = loginmodel.usertype
  }

  ResetUser() {
    this.currentUser = null
  }

}
