import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms'
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Case } from 'src/app/Models/Case';
import { Charity } from '../../Models/Charity';
import { User } from '../../Models/User';
import { UserStorageService } from '../../Services/UserStorageService/user-storage.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-addcase',
  templateUrl: './addcase.component.html',
  styleUrls: ['./addcase.component.css']
})
export class AddcaseComponent implements OnInit {

 
  charity: Charity
  CaseReq: Case
  charityemail: any
  loggedintype: any
  user: User

  constructor(private http: BackendCommunicationService, private userstorage: UserStorageService, private router: Router) { }

  ngOnInit(): void {
    this.GetUser()
    this.GetCharities()

  }

  GetUser() {
      this.user = this.userstorage.user
  }
 

  AddCaseForm = new UntypedFormGroup({
    firstname: new UntypedFormControl(),
    lastname: new UntypedFormControl(),
    description: new UntypedFormControl(),
    location: new UntypedFormControl(),
    totalamount: new UntypedFormControl(),
    charityid: new UntypedFormControl(),
  })

  AddCase() {
    let CaseReq = this.AddCaseForm.value
    CaseReq.status = "pending"
    this.http.addCase(CaseReq).subscribe()
    this.user.userType = "Case"
    this.http.UpdateUser(this.user.id, this.user).subscribe((res: User) => {
      Swal.fire({
        title: `Case ${CaseReq.name} registered successfully`,
        showCancelButton: false,
        confirmButtonText: 'OK'
      }).then((result) => {
        this.router.navigateByUrl('/login')
      });
    },
      (error) => {
        Swal.fire(error.error)
      })
  }

  GetCharities() {
    this.http.getCharity().subscribe((res: any) => {
      this.charity = res;
    })
  }

}
