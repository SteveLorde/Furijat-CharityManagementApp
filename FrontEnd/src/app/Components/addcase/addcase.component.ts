import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { CaseDTO } from 'src/app/Models/Case';
import { Charity } from '../../Models/Charity';

@Component({
  selector: 'app-addcase',
  templateUrl: './addcase.component.html',
  styleUrls: ['./addcase.component.css']
})
export class AddcaseComponent implements OnInit {


  charity: Charity
  idtest: Charity

  //Dummy Object
  CaseReq: CaseDTO = {
      id: 0,
      firstName: '',
      lastName: '',
      description: '',
      address: '',
      currentAmount: 0,
      totalAmount: 0,
      status: '',
      charity: undefined
  }

  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.GetCharities()
  }

  AddCaseForm = new FormGroup({
    firstname: new FormControl(),
    lastname: new FormControl(),
    description: new FormControl(),
    address: new FormControl(),
    amountneeded: new FormControl(),
    currentamount: new FormControl(),
    totalamount: new FormControl(),
    charityId: new FormControl(),
  })

  AddCase(CaseReq: CaseDTO) {
    CaseReq = this.AddCaseForm.value
    console.log(CaseReq)
    //console.log("the id of the charity of this case is " + this.CaseReq.charity.id)
    this._servercom.addCase(CaseReq).subscribe()
  }

  GetCharities() {
    this._servercom.getCharity().subscribe((res: any) => {
      this.charity = res;
    });
  }

  onSubmit() {
    console.log(this.AddCaseForm.value);
  }

}
