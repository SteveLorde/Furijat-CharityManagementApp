import { UserDTO } from './User - Copy'

export interface Charity{

  id: number
  name: string
  description: string
  location: string
  phone: string
  email: string
  testproperty: number
  user: UserDTO

}
