import { UserType } from 'src/app/Models/UserType'


export interface User {

  id: number
  userName: string
  firstName: string
  lastName: string
  userType: string
  token: string
  charityId: number

}
