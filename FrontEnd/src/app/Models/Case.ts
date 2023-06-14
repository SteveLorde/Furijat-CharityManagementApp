import { Charity } from "./Charity"

export interface Case {

  id: number
  firstName: string
  lastName: string
  description: string
  address: string
  currentAmount: number
  totalAmount: number
  status: string
  charity: Charity

}
