import { Case } from "./Case"
import { Charity } from "./Charity"
import { Donator } from "./Donator"

export interface Donation {
  id: number
  caseId: Case
  CharityId: Charity
  DonatorId: Donator
  Amount: number
  Time: string
}
