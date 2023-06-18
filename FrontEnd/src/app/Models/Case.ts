import { Charity } from "./Charity"

export interface Case {

  id: 0,
  userName: string
  firstName: string
  lastName: string
  userType: string
  token: string
  charityId: number
  phone: string
  description: string
  address: string
  currentAmount: number
  totalAmount: number
  marriageStatus: string
  status: string
  charity: Charity
}
