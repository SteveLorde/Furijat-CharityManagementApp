import { UserType } from 'src/app/Models/UserType'


export interface User {

  userId: number;
  uType: string;
  password: string;
  userName: string;
  firstName: string;
  lastNaame: string;
  email: string;
  phoneNumber: string;
  userTypeID: number;
  token: string;
  usertype: UserType

}
