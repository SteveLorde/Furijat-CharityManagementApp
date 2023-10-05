import {User} from "./User";

export interface Donator extends User {
  name : string
  phonenumber : number
  email : string
}
