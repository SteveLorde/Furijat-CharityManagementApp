import { Component, OnInit } from '@angular/core';
import { Case } from 'src/app/Models/Case';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { DonatelogService } from 'src/app/Services/DonateLog/donatelog.service';
import { Charity } from '../../Models/Charity';
import { Donation } from '../../Models/Donation';
import { DonatorService } from '../../Services/DonatorService/donator.service';

@Component({
  selector: 'app-userlog',
  templateUrl: './userlog.component.html',
  styleUrls: ['./userlog.component.css'],
})
export class UserlogComponent implements OnInit {
  //DonatedCases: Case[] = [];
  //DonatedCharities: Charity[] = [];
  Donations: Donation
  donatorid: any

  constructor(private http: BackendCommunicationService, private donatorservice: DonatorService) {}

  ngOnInit(): void {
    this.GetDonations()
  }

  GetDonations() {
    this.donatorservice.getDonations().subscribe((res: Donation) => {
      this.Donations = res
    })
  }

  dateTime: Date;
  ngoninit() {
    this.dateTime = new Date();
  }
}
