import { Charity } from "./Charity"

export interface CaseDTO {

  id: number
  firstName: string
  lastName: string
  description: string
  address: string
  currentAmount: number
  totalAmount: number
  status: string
  charity: {
    id: number
    name: string
    description: string
    location: string
    phone: string
    email: string
    userdonation: number
    }

}
