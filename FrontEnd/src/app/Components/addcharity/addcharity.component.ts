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
    this.user = this.userstorage.user
  }


  AddCharityForm = new UntypedFormGroup({
    name: new UntypedFormControl(),
    description: new UntypedFormControl(),
    location: new UntypedFormControl(),
    phonenumber: new UntypedFormControl(),
    email: new UntypedFormControl(),
  })

  AddCharity() {
    let charity = this.AddCharityForm.value
    charity.status = "pending"
    console.log(charity)
    this.http.addCharity(charity).subscribe()
    this.user.userType = "Charity"
    this.http.UpdateUser(this.user.id, this.user).subscribe((res: User) => {
      Swal.fire({
        title: `Charity ${charity.name} registered successfully`,
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
