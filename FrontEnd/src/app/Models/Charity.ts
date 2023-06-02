import { User } from './User'

export interface Charity {

  id: number
  name: string
  description: string
  location: string
  phone: string
  email: string
  fund: number
  testproperty: number
  user: User

}
