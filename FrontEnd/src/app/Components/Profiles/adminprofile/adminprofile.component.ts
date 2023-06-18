import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Case } from '../../../Models/Case';
import { Charity } from '../../../Models/Charity';
import { Creditor } from '../../../Models/Creditor';
import { Donator } from '../../../Models/Donator';
import { User } from '../../../Models/User';
import { BackendCommunicationService } from '../../../Services/BackendCommunication/backend-communication.service';
import { DonatorService } from '../../../Services/DonatorService/donator.service';

@Component({
  selector: 'app-adminprofile',
  templateUrl: './adminprofile.component.html',
  styleUrls: ['./adminprofile.component.css']
})
export class AdminprofileComponent {


  cases: Case
  charities: Charity
  donators: Donator
  creditos: Creditor
  users: User
  p: number = 1

  pendingcharity: any = 'pending'
  approvedcharity: any = 'approved'

  constructor(private http: BackendCommunicationService, private donatorservice: DonatorService, private router: Router) { }

  ngOnInit(): void {
    this.GetCharities()
  }

  GetCharities() {

    this.http.getCharity().subscribe((res: Charity) => {
      this.charities = res
    })
  }

  EditCase(element: Charity) {
    this.router.navigate(['/edit'], { queryParams: { id: element.id, edittype: 'charity' } })
  }

  Approve(element: Charity) {
    element.status = 'approved'
    this.http.UpdateCharitybyID(element.id, element).subscribe((res: any) => {
    })
    this.router.navigateByUrl('/profile')
  }

  Reject(element: Charity) {
    element.status = 'rejected'
    this.http.UpdateCharitybyID(element.id,element).subscribe((res: any) => {
    this.router.navigateByUrl('/profile')
    })
  }
  /*
   * 
    this.http.GetDonator().subscribe((res: Donator) => {
      this.donators = res
    })

    this.http.getUsers().subscribe((res: User) => {
      this.users = res

   */
}
