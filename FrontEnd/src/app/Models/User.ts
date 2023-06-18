import { UserType } from 'src/app/Models/UserType'


export interface User {

  userId: number
  userType: string
  password: string
  userName: string
  firstName: string
  lastNaame: string
  userTypeID: number
  token: string

}
