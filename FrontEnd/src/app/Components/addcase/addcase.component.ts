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

  CaseReq: CaseDTO = {
      id: 0,
      firstName: '',
      lastName: '',
      description: '',
      address: '',
      currentAmount: 0,
      totalAmount: 0,
      status: '',
      charity: {
          id: 0,
          name: '',
          description: '',
          location: '',
          phone: '',
          email: '',
          userdonation: 0
      }
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
    charityid: new FormControl(),
  })

  AddCase() {
    this.CaseReq = this.AddCaseForm.value
    this.CaseReq.charity.id = this.AddCaseForm.get('charityid').value
    console.log(this.CaseReq)
    console.log("Charity property" + this.CaseReq.charity)
    console.log("Charity id" + this.CaseReq.charity.id)
    this._servercom.addCase(this.CaseReq).subscribe()
  }

  GetCharities() {
    this._servercom.getCharity().subscribe((res: any) => {
      this.charity = res;
    });
  }

  onSubmitTest() {
    console.log(this.AddCaseForm.value);
  }

}
