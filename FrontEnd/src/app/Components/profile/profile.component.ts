import { Component, OnInit } from '@angular/core';
import { User } from '../../Models/User';
import { AuthService } from 'src/app/Services/Authorization/auth.service'
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';



@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user: User = {
      userId: 0,
      uType: '',
      password: '',
      userName: '',
      firstName: '',
      lastNaame: '',
      email: '',
      phoneNumber: '',
      userTypeID: 0,
      token: ''
  }
  id: any

  idtest: any = 6

  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.id = localStorage.getItem('UID')
   //this.GetProfile()
    this.GetProfile2()
  }

  GetProfile() {
    this._servercom.getUserbyId(this.id).subscribe((res: any) => {
      this.user = res
    })
  }

  GetProfile2() {
    this._servercom.getUserbyId(this.idtest).subscribe((res: any) => {
      this.user = res
    })
  }

}
