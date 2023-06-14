import { Injectable } from '@angular/core';
import { User } from '../../Models/User';
import { UserType } from '../../Models/UserType';

@Injectable({
  providedIn: 'root'
})
export class UserStorageService {

  user: User = {
      userId: 0,
      uType: '',
      password: '',
      userName: '',
      firstName: '',
      lastNaame: '',
      userTypeID: 0,
      token: ''
  }

  constructor() { }

  RetrieveLoginData(id: number, name: string) {
    if (this.user.userId == 0) {
      const errormessage = "Error, Not Valid User"
    }
    else
    {
      this.user.userId = id
      this.user.userName = name
    }
  }

}
