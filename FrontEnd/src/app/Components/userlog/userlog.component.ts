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

  constructor(private donatelog: DonatelogService) { }

  ngOnInit(): void {
    this.LogDonationCharities()
    console.log("showing results in donatedcharitieslog" + this.DonatedCharities)
  }

  LogDonationCharities() {
    this.DonatedCharities = this.donatelog.ReturnDonatedCharities()
  }



}
