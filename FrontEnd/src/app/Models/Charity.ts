import { Case } from './Case'
import { Donation } from './Donation'
import { User } from './User'

export interface Charity {

  id: number
  name: string
  description: string
  location: string
  bank_Account: string
  phone: string
  email: string
  website: string
  status: string
  users: User
  cases: Case
  donation: Donation


}
