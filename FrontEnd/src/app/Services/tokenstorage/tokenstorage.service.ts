import { Injectable } from '@angular/core';

const tokenk = 'auth-token';
const userk = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenstorageService {

  constructor() { }

  //clear token after sign out
  signOut(): void {
    window.sessionStorage.clear();
  }

  //save token for session
  public saveToken(token: string): void {
    window.sessionStorage.removeItem(tokenk);
    window.sessionStorage.setItem(tokenk, token);
  }

  //retrieve token
  public getToken(): string | null {
    return window.sessionStorage.getItem(tokenk);
  }

 public saveUser(user: any): void {
    window.sessionStorage.removeItem(userk);
    window.sessionStorage.setItem(userk, JSON.stringify(user));
 }

  public getUser(): any {
    const user = window.sessionStorage.getItem(userk);
    if (user) {
      return JSON.parse(user);
    }

    return {};
  }
}
