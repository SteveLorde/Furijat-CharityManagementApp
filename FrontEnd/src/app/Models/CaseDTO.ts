import { Charity } from "./CharityDTO"

export interface CaseDTO {

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
