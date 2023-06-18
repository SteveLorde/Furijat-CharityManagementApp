import { Component, OnInit } from '@angular/core';
import { User } from '../../Models/User';
import { UserType } from 'src/app/Models/UserType'
import { AuthService } from 'src/app/Services/Authorization/auth.service'
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Case } from '../../Models/Case';
import { Charity } from '../../Models/Charity';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  //create object "user" of User model
  user = {} as User
  Cases = { charity: {} as Charity } as Case
  id: any
  utid: any
  usertype: any
  p: number = 1

  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.id = localStorage.getItem('userid')
    this.usertype = localStorage.getItem('UserType')
    //this.usertype = localStorage.getItem('UserType')
    this.GetProfile()
  }

  GetProfile() {
    this._servercom.getUserbyId(this.id).subscribe((res: User) => {
      console.log(res)
      this.user.userName = res.userName
      this.user.userType = res.userType
    })
  }
}
