import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import {AuthGuard } from 'src/app/Services/AuthGuard/authguard'

//modify header of requests constantly
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  constructor(protected http: HttpClient, private router: Router, private jwtHelper: JwtHelperService) {
  }

  ngOnInit(): void { }

  authUrl = environment.baseUrl + 'api/auth';

  //check user authentication jwt token
  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }


  public logOut = () => {
    localStorage.removeItem("jwt");
  }


}

/*
public tokenKey: string = "token";

//authorization endpoint url




isAuthenticated(): boolean {
  return this.getToken() !== null;
}

getToken(): string | null {
  return localStorage.getItem(this.tokenKey);
}

login(username: string, password: string): Observable<any> {
  return this.http.post(this.authUrl + 'login', {
    username,
    password
  })
    .pipe(map(user => {
      // login successful if there's a jwt token in the response
      if (user) {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('TokenInfo', JSON.stringify(user));
      }
      return user;
    }));
}

/*
login(username: string, password: string): Observable<any> {
  return this.http.post(this.authUrl + 'login', {
    username,
    password
  }, httpOptions);
}


logout() {
  // remove user from local storage to log user out
  localStorage.removeItem('TokenInfo');
}

register(username: string, email: string, password: string): Observable<any> {
  return this.http.post(this.authUrl + 'register', {
    username,
    email,
    password
  }, httpOptions);
}
*/
