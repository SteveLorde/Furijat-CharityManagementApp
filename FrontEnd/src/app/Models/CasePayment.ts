import { CaseDTO } from "./Case";

export interface CasePayment {

  id: number
  paymentMethod: string
  paymentAmount: number
  case: CaseDTO

}
