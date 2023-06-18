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
    this.UserTypeCharity()
  }

  user = {} as User
  Cases = { charity: {} as Charity } as Case
  charity = { cases: {} as Case } as Charity
  Donations = {} as Donation

  filtercharityid: any = this.charity.id

  statusfilter: any 

  id: any
  utid: any
  usertype: any
  p: number = 1

  GenerateReport() {

  }

  UserTypeCharity() {
    const usertype = localStorage.getItem('UserType')
    const CharityLogID = localStorage.getItem('UserType')
    if (usertype == 'Charity') {
      this.http.getCharitybyId(this.charity).subscribe((res: Charity) => {
        this.charity = res
      })
    }
  }

  GetDonations() {
    this.donationservice.getDonations().subscribe((res: Donation) => {
      this.Donations = res
    })
  }

  Message() {
    this.router.navigateByUrl('/contactform');
  }
  
  GetCases() {
    this.http.getCases().subscribe((res) => {
      this.Cases = res
    })
  }
  

  EditCase(element: Case) {
    this.router.navigate(['/edit'], { queryParams: { id: element.id, edittype: 'case' } })
  }

  approve(element: any, id:any ) {
    element.id = id
    element.status = "In Need"
    element.charity.id =
    this.http.updateCase(id, element).subscribe()
  }

  reject(element: Case, id: any) {
    element.id = id
    element.status = "waiting"
    element.charity.id = 0
    this.http.updateCase(id,element).subscribe()
  }

  ProvideAssistance() {
    this.router.navigateByUrl('/provideassistancebycharity')
  }

  DeleteCase(id: any) {
    this.http.DeleteCase(id).subscribe((res: any) => {
      Swal.fire('Case Deleted')
      this.router.navigateByUrl('/profile')
    },
      error => {
        Swal.fire('Error, Case not deleted')
      }
    )
  }

}
