import { User } from 'src/app/Models/User'

export interface Charity{

  id: number
  name: string
  description: string
  location: string
  phone: string
  email: string
  userdonation: number
  user: User
}
