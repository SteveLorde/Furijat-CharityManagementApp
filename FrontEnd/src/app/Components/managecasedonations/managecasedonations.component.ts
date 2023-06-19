import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Donation } from '../../Models/Donation';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { DonatorService } from '../../Services/DonatorService/donator.service';

@Component({
  selector: 'app-managecasedonations',
  templateUrl: './managecasedonations.component.html',
  styleUrls: ['./managecasedonations.component.css']
})
export class ManagecasedonationsComponent {

  caseid: any
  donationstatus: any = 'pending'
  Donations: any
  p: number = 1



  constructor(private http: BackendCommunicationService, private donatorservice: DonatorService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.caseid = params['id'];
    })
  }


  GetPendingDonations() {

    this.donatorservice.getDonations().subscribe((res: any) => {
      this.Donations = res
    })
  }

  ApproveDonation(element: Donation) {
    
  }

  RejectDonation(element: Donation) {

  }


}
