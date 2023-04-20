import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { CaseDTO } from 'src/app/Models/CaseDTO';
import { FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-validatecase',
  templateUrl: './validatecase.component.html',
  styleUrls: ['./validatecase.component.css']
})
export class ValidatecaseComponent implements OnInit {

  caseelement: CaseDTO[] = []
  casetoadd: CaseDTO
  searchText: string;
  p: number = 1

  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.RetrieveCaseList()
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

  AddCaseToValidate(caseelement: CaseDTO[],casetoadd: CaseDTO) {
    casetoadd = this.AddCaseForm.value
    console.log(casetoadd)
    caseelement.push(casetoadd)
  }

  RetrieveCaseList() {
    this._servercom.getCases().subscribe((res: any) => {
      this.caseelement = res
    })
  }

  ConfirmCase(element: any) {
    this._servercom.addCase(element).subscribe((res: any) => {
      console.log("validating and adding case called", res.name)
    })
  }

}
