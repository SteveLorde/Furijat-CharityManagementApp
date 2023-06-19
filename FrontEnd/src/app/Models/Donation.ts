import { Case } from "./Case"
import { Charity } from "./Charity"
import { Donator } from "./Donator"

export interface Donation {
  
  caseId: number
  case: Case
  charityId: number
  charity: Charity
  donatorId: number
  donator: Donator
  amount: number
  time: string
}
