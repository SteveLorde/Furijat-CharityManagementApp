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
  constructor(private http: HttpClient, private router: Router) {
  }

  ngOnInit(): void { }

  authregisterUrl = 'http://localhost:3000/register';
  authloginUrl = 'http://localhost:3000/login';
  authgetmeUrl = 'http://localhost:3000/users';

  registerUrl = environment.baseUrl + 'api/Account/register'
  loginUrl = environment.baseUrl + 'api/Account/login'
  getmeUrl = environment.baseUrl + 'api/user'

  currentUser = {};

  public register(user: User): Observable<any> {
    return this.http.post<any>(this.registerUrl, user);
  }

  public login(user: Login): Observable<string> {
    return this.http.post(this.loginUrl, user, { responseType: 'text' });
  }

  public getMe(): Observable<any> {
    return this.http.get(this.authgetmeUrl, {
      responseType: 'text',
      });
  }


  public accesserror() {
    console.log('you have to login')
  }


  /*
  // Sign-in
  signIn(user: User) {
    return this.http
      .post<any>(this.authloginUrl, user)
      .subscribe((res: any) => {
        localStorage.setItem('access_token', res.token);
        this.getUserProfile(res._id).subscribe((res) => {
          this.currentUser = res;
        });
      });
  }


  // Sign-up
  signUp(user: User): Observable<any> {
    let api = this.authregisterUrl;
    return this.http.post(api, user).pipe(catchError(this.handleError));
  }

  //RETRIEVE TOKEN
  getToken() {
    return localStorage.getItem('access_token');
  }

  //IS USER LOGGED IN?
  getisLoggedIn(): boolean {
    let authToken = localStorage.getItem('access_token');
    return authToken !== null ? true : false;
  }

  Logout() {
    let removeToken = localStorage.removeItem('access_token');
    if (removeToken == null) {
      this.router.navigate(['log-in']);
    }
  }

  //GET User Profile by ID
  getUserProfile(id: any): Observable<any> {
    //let api = `${this.endpoint}/user-profile/${id}`;
    let api = environment.baseUrl + 'Login' + id;
    return this.http.get(api, { headers: this.headers }).pipe(
      map((res) => {
        return res || {};
      }),
      catchError(this.handleError)
    );
  }

  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      msg = error.error.message;
    } else {
      // server-side error
      msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(msg);
  }
  */
}
