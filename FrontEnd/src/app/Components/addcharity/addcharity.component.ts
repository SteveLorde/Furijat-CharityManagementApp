import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Charity } from 'src/app/Models/Charity';
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


  AddCharityForm = new FormGroup({
    name: new FormControl(),
    description: new FormControl(),
    address: new FormControl(),
    phonenumber: new FormControl(),
    email: new FormControl(),
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
