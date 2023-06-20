import { Component } from '@angular/core';
import { Case } from '../../../Models/Case';
import { Charity } from '../../../Models/Charity';
import { User } from '../../../Models/User';
import { BackendCommunicationService } from '../../../Services/BackendCommunication/backend-communication.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Donation } from '../../../Models/Donation';
import { DonatorService } from '../../../Services/DonatorService/donator.service';


@Component({
  selector: 'app-charityprofile',
  templateUrl: './charityprofile.component.html',
  styleUrls: ['./charityprofile.component.css']
})
export class CharityprofileComponent {

  constructor(private http: BackendCommunicationService, private router: Router, private donationservice: DonatorService) { }

  ngOnInit(): void {
    this.GetProfileCharity()
  }

  user = {} as User
  Cases = { charities: {} as Charity } as Case
  charity = { cases: {} as Case } as Charity
  Donations = {} as Donation

  CharityID: any

  filtercharityid: any = this.charity.id

  statusfilter: any = "pending"
 approvedstatusfilter: any = "approved"

  id: any
  utid: any
  usertype: any
  p: number = 1

  GenerateReport() {

  }

  GetProfileCharity() {
    this.http.getCharitybyId(this.CharityID).subscribe((res: Charity) => {
        this.charity = res
      })
      this.GetCases()
  }

  GetDonations() {
    this.donationservice.getDonations().subscribe((res: Donation) => {
      this.Donations = res
    })
  }

  Message(element: Case) {
    this.router.navigate(['/contactform'], { queryParams: { selectedemail: element.userName + '@gmail.com' } })
  }
  
  GetCases() {
    this.http.getCases().subscribe((res) => {
      this.Cases = res
    })
  }
  

  ProvideAssistance() {
    this.router.navigateByUrl('/provideassistancebycharity')
  }

  approve(element: any, id:any ) {
    element.id = id
    element.status = "approved"
    element.charity.id = this.charity.id
    this.http.updateCase(id, element).subscribe()
  }

  reject(element: Case, id: any) {
    element.id = id
    element.status = "pending"
    element.charities.id = 0
    this.http.updateCase(id,element).subscribe()
  }

  ManageCaseDonations(element: Case) {
    this.router.navigate(['/managecasedonations'], { queryParams: { id: element.id} })
  }

  DeleteCase(element: Case) {
    this.http.DeleteCase(element.id).subscribe((res: any) => {
      Swal.fire({
        title: 'Case Deleted',
        showCancelButton: false,
        confirmButtonText: 'Ok',
        cancelButtonText: 'No'
      }).then((result) => {
        if (result.isConfirmed) {
          location.reload()
        }
      })
    },
      error => {
        Swal.fire('Error, Case not deleted')
      }
    )
  }

}
