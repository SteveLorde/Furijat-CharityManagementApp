import { Injectable } from '@angular/core';
import { User } from '../../Models/User';
import { UserType } from '../../Models/UserType';

@Injectable({
  providedIn: 'root'
})
export class UserStorageService {

  user = {} as User
  loggedin: any

  constructor() { }

  RetrieveLogin(id: number, name: string, usertype: string) {
      this.user.id = id
      this.user.userName = name
      this.user.userType = usertype
      this.loggedin = 1
  }

  DeleteStorage() {
    this.user.id = null
    this.user.userName = null
    this.user.userType = null
    this.loggedin = 0
  }



  }

