import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Charity } from 'src/app/Models/Charity';
import { Router } from '@angular/router';
import { User } from '../../Models/User';
import { UserStorageService } from '../../Services/UserStorageService/user-storage.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-addcharity',
  templateUrl: './addcharity.component.html',
  styleUrls: ['./addcharity.component.css']
})
export class AddcharityComponent implements OnInit {

  charity: Charity
  user: User

  constructor(private http: BackendCommunicationService, private router: Router, private userstorage: UserStorageService) { }

  ngOnInit(): void {
    this.GetUser()
  }

  GetUser() {
    this.user.id = this.userstorage.user.id
  }


  AddCharityForm = new UntypedFormGroup({
    name: new UntypedFormControl(),
    description: new UntypedFormControl(),
    address: new UntypedFormControl(),
    phonenumber: new UntypedFormControl(),
    email: new UntypedFormControl(),
  })

  AddCharity() {
    const charity = this.AddCharityForm.value
    charity.status = "pending"
    console.log(charity)
    this.http.addCharity(charity).subscribe()
    this.http.UpdateUser(this.user.id, this.user).subscribe((res: User) => {
      Swal.fire({
        title: 'Account Registered Successfully',
        showCancelButton: true,
        confirmButtonText: 'Login',
        cancelButtonText: 'Home'
      }).then((result) => {
        if (result.isConfirmed) {
          this.router.navigate(['/login']) // Replace '/new-page' with the desired route
        })
    },
      (error) => {
        Swal.fire(error.error)
      })
  }

  onSubmit() {
    console.log(this.AddCharityForm.value);
    this.router.navigateByUrl('/charitylist')
  }
}
