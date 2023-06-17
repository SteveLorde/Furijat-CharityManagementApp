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
  totalAmount: number
  marriageStatus: string
  charities: Charity
}
