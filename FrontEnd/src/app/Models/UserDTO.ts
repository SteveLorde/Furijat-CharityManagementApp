import { UserType } from 'src/app/Models/UserType'


export interface UserDTO {

  userId: number
  uType: string
  password: string
  userName: string
  firstName: string
  lastNaame: string
  userTypeID: number
  token: string

}
