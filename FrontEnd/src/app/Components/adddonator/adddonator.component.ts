import { Component } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Donator } from '../../Models/Donator';
import { User } from '../../Models/User';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { UserStorageService } from '../../Services/UserStorageService/user-storage.service';

@Component({
  selector: 'app-adddonator',
  templateUrl: './adddonator.component.html',
  styleUrls: ['./adddonator.component.css']
})
export class AdddonatorComponent {

  user: User

  constructor(private http: BackendCommunicationService, private userstorage: UserStorageService, private router: Router) { }

  ngOnInit(): void {
    this.GetUser()
  }

  AddDonatorForm = new UntypedFormGroup({
    phone: new UntypedFormControl(),
    address: new UntypedFormControl(),
  })

  GetUser() {
    this.user = this.userstorage.user
  }

  AddDonator() {
    let donator: Donator
    donator.id = this.userstorage.user.id
    donator = this.AddDonatorForm.value
    this.http.addDonator(donator).subscribe()
    this.user.userType = "Donator"
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
