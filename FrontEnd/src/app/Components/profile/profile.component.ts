import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from '../../Models/User';
import { UserType } from 'src/app/Models/UserType'
import { AuthService } from 'src/app/Services/Authorization/auth.service'
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Case } from '../../Models/Case';
import { Charity } from '../../Models/Charity';
import { Router } from '@angular/router';
import { DonatorprofileComponent } from 'src/app/Components/Profiles/donatorprofile/donatorprofile.component'
import { CreditorprofileComponent } from 'src/app/Components/Profiles/creditorprofile/creditorprofile.component'
import { DebtorprofileComponent } from 'src/app/Components/Profiles/debtorprofile/debtorprofile.component'
import { CharityprofileComponent } from 'src/app/Components/Profiles/charityprofile/charityprofile.component'

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
  username: any
  p: number = 1



  constructor(private _servercom: BackendCommunicationService, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    
    this.GetProfile()
  }

  @ViewChild('childComponent', { static: true }) charityprofilechild: CharityprofileComponent
  @ViewChild('childComponent', { static: true }) caseprofilechild: DebtorprofileComponent
  @ViewChild('childComponent', { static: true }) donatorprofilechild: DonatorprofileComponent
  @ViewChild('childComponent', { static: true }) creditorprofilechild: CreditorprofileComponent

  GetProfile() {
    this.usertype = localStorage.getItem('usertype')
    switch (this.usertype) {
      case "user":
        this.username = localStorage.getItem('username')
        this.usertype = "user"
        break
      case "charity":
        this.username = localStorage.getItem('username')
        this.usertype = "charity"
        this.charityprofilechild.CharityID = this.user.charityId
        this.charityprofilechild.GetProfileCharity()
        break
      case "case":
        break
      case "donator":
        break
      case "creditor":
        break
    }
  }

  GetCharityProfile() {
    //this.get
  }

  RegisterAsCharity() {
    this.router.navigate(['/addcharity'], { queryParams: { id: this.user.id } })
  }

  RegisterAsCase() {
    this.router.navigate(['/addcase'], { queryParams: { id: this.user.id } })
  }

  RegisterAsDonator() {
    //this.router.navigate(['/addcase'], { queryParams: { id: this.user.id } })
  }

}
