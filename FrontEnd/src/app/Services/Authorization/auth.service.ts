import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import {AuthGuard } from 'src/app/Services/AuthGuard/authguard'
import { User } from '../../Models/User';

//modify header of requests constantly
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  constructor(protected http: HttpClient, private router: Router) {
  }

  ngOnInit(): void { }

  authregisterUrl = environment.baseUrl + 'api2/Auth/register';
  authloginUrl = environment.baseUrl + 'api2/Auth/login';

  register(user: User): Observable<any> {

    return this.http.post<any>(this.authregisterUrl, user);
  }

  login(user: User): Observable<string> {

    return this.http.post(this.authloginUrl, user, { responseType: 'text' });
  }
}



/*
login(email: string, password: string) {
return this.http.post<User>('/api/login', { email, password })
  .shareReplay();
}

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
