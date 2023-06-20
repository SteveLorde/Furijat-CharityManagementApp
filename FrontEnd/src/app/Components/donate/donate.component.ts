import { Component, OnInit } from '@angular/core';
import { Case } from 'src/app/Models/Case';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { DonatorService } from '../../Services/DonatorService/donator.service';
import { Charity } from '../../Models/Charity';
import { Donation } from '../../Models/Donation';
import { MailServiceBackendService } from '../../Services/MailServiceBackend/mail-service-backend.service';
import { ContactMessage } from '../../Models/ContactMessage';

@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.css']
})
export class DonateComponent implements OnInit {

  case = {} as Case
  charity = {} as Charity
  donation = {} as Donation
  id: any
  donateamount: number = 0
  paymentmethod: any


  constructor(private donate: DonatorService, private router: Router, private _Activatedroute: ActivatedRoute, private http: BackendCommunicationService, private mailservice: MailServiceBackendService) { }

  ngOnInit(): void {
    //Retrieve Case from Database by ID
    this.id = this._Activatedroute.snapshot.paramMap.get("id")
    this.http.getCasesById(this.id).subscribe((res: Case) => {
      this.case = res
      this.charity = res.charity
    })
    //this.case.currentAmount = this.case.currentAmount + this.donateamount
  }

  Donate() {
    //this.case.currentAmount = this.case.currentAmount + this.donateamount
    //console.log("current amount is ", this.case.currentAmount)
    this.CreateDonationPayment()
    this.http.updateCase(this.case, this.id).subscribe()
    this.Close()
  }

  CreateDonationPayment() {
    this.donation.caseId = this.case.id
    this.donation.charityId = this.charity.id
    this.donation.amount = this.donateamount
    this.donation.time = "6-6-2023"
    this.donate.createDonation(this.donation).subscribe()
  }

  NotifyDonator() {
    const mail = {} as ContactMessage
    mail.ToEmail = "mostafa.maher98@gmail.com"
    mail.Subject = "Donation Notification for Charity" + this.charity.name + "for Case" + this.case.id + this.case.firstName + this.case.lastName
    mail.Body = "You have Donated on" + this.donation.time + "To Charity" + this.charity.name + "for case" + this.case.firstName + this.case.lastName
  }

  Close() {
    this.router.navigateByUrl('/Profile')
  }


}
