import { User } from 'src/app/Models/User'

export interface Charity{

  id: number;
  name: string | undefined;
  description: string | undefined;
  location: string | undefined;
  phone: string | undefined;
  email: string | undefined;
  userdonation: number | undefined;
  user: User;
}
