import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Charity } from 'src/app/Models/CharityDTO';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addcharity',
  templateUrl: './addcharity.component.html',
  styleUrls: ['./addcharity.component.css']
})
export class AddcharityComponent implements OnInit {

  charity: Charity

  constructor(private _servercom: BackendCommunicationService, private router: Router) { }

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
    console.log(charity)
    this._servercom.addCharity(charity).subscribe()
  }

  onSubmit() {
    console.log(this.AddCharityForm.value);
    this.router.navigateByUrl('/charitylist')
  }
}
