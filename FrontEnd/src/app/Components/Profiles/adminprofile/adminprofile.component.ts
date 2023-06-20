import { Component } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
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


  cases = {} as Case
  charities = {} as Charity
  donators = {} as Donator
  creditor = {} as Creditor
  users = {} as User
  p: number = 1

  pendingcharity: string = 'pending'
  approvedcharity: string = 'approved'

  constructor(private http: BackendCommunicationService, private donatorservice: DonatorService, private router: Router) { }

  ngOnInit(): void {
    this.GetCharities()
  }

  GetCharities() {

    this.http.getCharity().subscribe((res: Charity) => {
      this.charities = res
    })
  }

  EditCharity(element: Charity) {
    console.log('id of charity to edit is ' + element.id)
    this.router.navigate(['/edit'], { queryParams: { id: element.id, edittype: 'charity' } })
  }

  DeleteCharity(element: Charity) {
    console.log("deleting charity" + element.name)
    this.http.DeleteCharity(element.id).subscribe((res: any) => {
      Swal.fire('Deleting Charity' + element.name)
      location.reload()
    })
  }

  Approve(element: Charity) {
    element.status = 'approved'
    this.http.UpdateCharitybyID(element.id, element).subscribe((res: any) => {
    })
    location.reload()
  }

  Reject(element: Charity) {
    element.status = 'rejected'
    this.http.DeleteCharity(element.id).subscribe((res: any) => {
      Swal.fire('Rejecting Charity' + element.name)
    location.reload()
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
