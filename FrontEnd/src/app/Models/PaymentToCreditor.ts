import { Case } from "./Case"
import { Charity } from "./Charity"
import { Creditor } from "./Creditor"

export interface PaymentToCreditor {
  caseId: number
  case: Case
  charityId: number
  charity: Charity
  creditorId: number
  creditor: Creditor
  paid_Amount: number
  time: string
}
