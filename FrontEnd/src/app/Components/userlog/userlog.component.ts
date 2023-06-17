import { Component, OnInit } from '@angular/core';
import { Case } from 'src/app/Models/Case';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { DonatelogService } from 'src/app/Services/DonateLog/donatelog.service';
import { Charity } from '../../Models/Charity';

@Component({
  selector: 'app-userlog',
  templateUrl: './userlog.component.html',
  styleUrls: ['./userlog.component.css'],
})
export class UserlogComponent implements OnInit {
  DonatedCases: CaseDTO[] = [];
  DonatedCharities: Charity[] = [];

  constructor(private donatelog: DonatelogService) {}

  ngOnInit(): void {
    this.LogDonationCharities();
    console.log(
      'showing results in donatedcharitieslog' + this.DonatedCharities
    );
  }

  LogDonationCharities() {
    this.DonatedCharities = this.donatelog.ReturnDonatedCharities();
  }
  dateTime: Date;
  ngoninit() {
    this.dateTime = new Date();
  }
}
