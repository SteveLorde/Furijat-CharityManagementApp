import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Case } from 'src/app/Models/Case';

@Component({
  selector: 'app-addcase',
  templateUrl: './addcase.component.html',
  styleUrls: ['./addcase.component.css']
})
export class AddcaseComponent implements OnInit {
  CaseReq!: Case;

  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
  }

  AddCaseForm = new FormGroup({
    firstname: new FormControl(),
    lastname: new FormControl(),
    description: new FormControl(),
    address: new FormControl(),
    amountneeded: new FormControl(),
    currentamount: new FormControl(),
    totalamount: new FormControl(),
  })

  AddCase(CaseReq: Case) {
    CaseReq = this.AddCaseForm.value
    console.log(CaseReq)
    this._servercom.addCase(CaseReq).subscribe()
  }

  onSubmit() {
    console.log(this.AddCaseForm.value);
  }

}
