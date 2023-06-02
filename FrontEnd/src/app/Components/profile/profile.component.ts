import { Component, OnInit } from '@angular/core';
import { User } from '../../Models/User';
import { UserType } from 'src/app/Models/UserType'
import { AuthService } from 'src/app/Services/Authorization/auth.service'
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  //create object "user" of User model
  user = {} as User
  id: any
  utid: any
  usertype: any

  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.id = localStorage.getItem('UID')
    this.utid = localStorage.getItem('UTypeID')
    console.log(this.utid)
    this.GetProfile()
  }

  GetProfile() {
    this._servercom.getUserbyId(this.id).subscribe((res: any) => {
      this.user = res
    })
    switch (this.utid) {
      case '1':
        this.usertype = "User"
        break
      case '2':
        this.usertype = "Charity"
        break
      case '3':
        this.usertype = "Case"
        break
    }
  }
}
