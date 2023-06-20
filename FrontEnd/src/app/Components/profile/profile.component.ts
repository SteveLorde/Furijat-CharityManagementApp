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
import { DonatorService } from '../../Services/DonatorService/donator.service';
import { UserStorageService } from '../../Services/UserStorageService/user-storage.service';

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



  constructor(private _servercom: BackendCommunicationService, private authService: AuthService, private router: Router, private donatorservice: DonatorService, private userstorage: UserStorageService) { }

  ngOnInit(): void {
    
    this.GetProfile()
  }

  @ViewChild('childComponent', { static: true }) charityprofilechild: CharityprofileComponent
  @ViewChild('childComponent', { static: true }) caseprofilechild: DebtorprofileComponent
  @ViewChild('childComponent', { static: true }) donatorprofilechild: DonatorprofileComponent
  @ViewChild('childComponent', { static: true }) creditorprofilechild: CreditorprofileComponent

  GetProfile() {
    this.usertype = this.userstorage.user.userType
    this.username = this.userstorage.user.userName
    /*
    this.usertype = localStorage.getItem('usertype')
    switch (this.usertype) {
      case "User":
        this.username = localStorage.getItem('username')
        this.usertype = "user"
        break
      case "Admin":
        this.username = localStorage.getItem('username')
        this.usertype = "Admin"
        break
      case "Charity":
        this.username = localStorage.getItem('username')
        this.usertype = "charity"
        this.charityprofilechild.CharityID = this.user.charityId
        this.charityprofilechild.GetProfileCharity()
        break
      case "Case":
        break
      case "Donator":
        this.username = localStorage.getItem('username')
        this.usertype = "Donator"
        //this.donatorprofilechild.donationlog.donatorid = 
        break
      case "Creditor":
        break
    }
    */
  }

  GetCharityProfile() {
    //this.get
  }

  RegisterAsCharity() {
    this.router.navigateByUrl('/addcharity')
  }

  RegisterAsCase() {
    this.router.navigateByUrl('/addcase')
  }

  RegisterAsDonator() {
    this.router.navigateByUrl('/adddonator')
  }

  RegisterAsCreditor() {
    this.router.navigateByUrl('/addcreditor')
  }

}
