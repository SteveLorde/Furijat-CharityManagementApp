import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Charity } from 'src/app/Models/Charity';
import { Router } from '@angular/router';
import { User } from '../../Models/User';

@Component({
  selector: 'app-addcharity',
  templateUrl: './addcharity.component.html',
  styleUrls: ['./addcharity.component.css']
})
export class AddcharityComponent implements OnInit {

  charity: Charity
  user: User

  constructor(private http: BackendCommunicationService, private router: Router) { }

  ngOnInit(): void {
    
  }


  AddCharityForm = new UntypedFormGroup({
    name: new UntypedFormControl(),
    description: new UntypedFormControl(),
    address: new UntypedFormControl(),
    phonenumber: new UntypedFormControl(),
    email: new UntypedFormControl(),
  })

  AddCharity(charity: Charity) {
    charity = this.AddCharityForm.value
    charity.status = "pending"
    console.log(charity)
    this.http.addCharity(charity).subscribe()
    this.http.getUserbyId(this.user.id).subscribe((res: User) => {

    })
    
  }

  onSubmit() {
    console.log(this.AddCharityForm.value);
    this.router.navigateByUrl('/charitylist')
  }
}
