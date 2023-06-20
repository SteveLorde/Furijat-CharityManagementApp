import { Component } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Case } from '../../Models/Case';
import { Creditor } from '../../Models/Creditor';
import { User } from '../../Models/User';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { UserStorageService } from '../../Services/UserStorageService/user-storage.service';

@Component({
  selector: 'app-addcreditor',
  templateUrl: './addcreditor.component.html',
  styleUrls: ['./addcreditor.component.css']
})
export class AddcreditorComponent {


  user: User
  Cases: Case

  constructor(private http: BackendCommunicationService, private userstorage: UserStorageService, private router: Router) { }

  ngOnInit(): void {
    this.GetUser()
    this.GetCases()
  }

  AddDonatorForm = new UntypedFormGroup({
    phone: new UntypedFormControl(),
    address: new UntypedFormControl(),
    payment_Account: new UntypedFormControl(),
    caseID: new UntypedFormControl(),
  })

  GetUser() {
    this.user = this.userstorage.user
  }

  GetCases() {
    
    this.http.getCases().subscribe((res: any) => {
      debugger
      this.Cases = res
    })
  }

  AddCreditor() {
    debugger
    let creditor = {} as Creditor
    creditor.id = this.userstorage.user.id
    creditor = this.AddDonatorForm.value
    this.http.addCreditor(creditor).subscribe()
    this.user.userType = "Creditor"
    this.http.UpdateUser(this.user.id, this.user).subscribe((res: User) => {
      Swal.fire({
        title: `successfully registered as Donator`,
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

}
