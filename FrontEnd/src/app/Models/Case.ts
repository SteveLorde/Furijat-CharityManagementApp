import { Charity } from './Charity';
import { Donation } from './Donation';

export interface Case {
  id: number;
  userName: string;
  firstName: string;
  lastName: string;
  userType: string;
  token: string;
  charityId: number;
  phone: string;
  description: string;
  address: string;
  totalAmount: number;
  marriageStatus: string;
  status: string;
  charity: Charity;
  donation: Donation;
}
