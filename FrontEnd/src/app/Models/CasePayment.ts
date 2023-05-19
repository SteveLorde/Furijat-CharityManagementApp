import { CaseDTO } from "./CaseDTO";

export interface CasePayment {

  id: number
  paymentMethod: string
  paymentAmount: number
  case: CaseDTO

}
