import { Case } from "./Case"

export interface Creditor {
  id: number
  caseID: number
  phone: string
  description: string
  payment_Account: string
  address: string
  deserves_Amount: number
}
