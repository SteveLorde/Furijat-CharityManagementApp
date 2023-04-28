import { UserDTO } from './UserDTO'

export interface Charity {

  id: number
  name: string
  description: string
  location: string
  phone: string
  email: string
  fund: number
  testproperty: number
  user: UserDTO

}
