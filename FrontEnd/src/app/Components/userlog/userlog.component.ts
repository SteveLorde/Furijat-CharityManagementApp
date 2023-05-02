import { Component, OnInit } from '@angular/core';
import { CaseDTO } from 'src/app/Models/CaseDTO';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { DonatelogService } from 'src/app/Services/DonateLog/donatelog.service';
import { Charity } from '../../Models/CharityDTO';


@Component({
  selector: 'app-userlog',
  templateUrl: './userlog.component.html',
  styleUrls: ['./userlog.component.css']
})
export class UserlogComponent implements OnInit {

  DonatedCases: CaseDTO[] = []
  DonatedCharities: Charity[] = []
  UserType: any

  constructor(private donatelog: DonatelogService) { }

  ngOnInit(): void {
    this.UserType = localStorage.getItem("UTypeID")
    if (this.UserType == "1") {
      this.LogDonationCases()
    }
    else if (this.UserType == "2") {
      this.LogDonationCharities()
    }
    else if (this.UserType == "3") {
      console.log("no log for case user")
    }
  }

  LogDonationCharities() {
    this.DonatedCharities = this.donatelog.ReturnDonatedCharities()
  }

  LogDonationCases() {
    this.DonatedCases = this.donatelog.ReturnDonatedCases()
  }



}
