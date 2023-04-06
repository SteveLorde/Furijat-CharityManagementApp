import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Case } from 'src/app/Models/Case';
import { FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-validatecase',
  templateUrl: './validatecase.component.html',
  styleUrls: ['./validatecase.component.css']
})
export class ValidatecaseComponent implements OnInit {

  caseelement: Case[] = []
  casetoadd: Case
  searchText: string;
  p: number = 1

  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
  }

  AddCaseForm = new FormGroup({
    firstName: new FormControl(),
    lastName: new FormControl(),
    description: new FormControl(),
    address: new FormControl(),
    amountneeded: new FormControl(),
    currentamount: new FormControl(),
    totalamount: new FormControl(),
  })

  AddCaseToValidate(caseelement: Case[],casetoadd: Case) {
    casetoadd = this.AddCaseForm.value
    console.log(casetoadd)
    caseelement.push(casetoadd)
  }

  ConfirmCase(element: any) {
    this._servercom.addCase(element).subscribe((res: any) => {
      console.log("validating and adding case called", res.name)
    })
  }

}
