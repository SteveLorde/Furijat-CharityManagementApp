import { Injectable } from '@angular/core';
import { User } from '../../Models/User';
import { UserType } from '../../Models/UserType';

@Injectable({
  providedIn: 'root'
})
export class UserStorageService {

  user: User = {
      id: 0,
      userName: '',
      firstName: '',
      lastName: '',
      userType: '',
      token: '',
      charityId: 0
  }

  constructor() { }

  RetrieveLoginData(id: number, name: string) {
    if (this.user.id == 0) {
      const errormessage = "Error, Not Valid User"
    }
    else
    {
      this.user.id = id
      this.user.userName = name
    }
  }

}
