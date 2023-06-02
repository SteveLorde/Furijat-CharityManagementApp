import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms'
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Case } from 'src/app/Models/Case';
import { Charity } from '../../Models/Charity';
import { User } from '../../Models/User';

@Component({
  selector: 'app-addcase',
  templateUrl: './addcase.component.html',
  styleUrls: ['./addcase.component.css']
})
export class AddcaseComponent implements OnInit {

 
  charity: Charity
  CaseReq: Case
  charityemail: any

  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.GetCharities()

  }

  AddCaseForm = new UntypedFormGroup({
    firstname: new UntypedFormControl(),
    lastname: new UntypedFormControl(),
    description: new UntypedFormControl(),
    address: new UntypedFormControl(),
    amountneeded: new UntypedFormControl(),
    currentamount: new UntypedFormControl(),
    totalamount: new UntypedFormControl(),
    charityid: new UntypedFormControl(),
  })

  AddCase() {
    this.CaseReq = { charity: { user: {} as User } as Charity } as Case
    this.CaseReq.firstName = this.AddCaseForm.get('firstname').value
    this.CaseReq.lastName = this.AddCaseForm.get('lastname').value
    this.CaseReq.description = this.AddCaseForm.get('description').value
    this.CaseReq.address = this.AddCaseForm.get('address').value
    this.CaseReq.currentAmount = this.AddCaseForm.get('currentamount').value
    this.CaseReq.totalAmount = this.AddCaseForm.get('totalamount').value
    this.CaseReq.status = "notvalid"
    this.CaseReq.charity.id = this.AddCaseForm.get('charityid').value
    this._servercom.addCase(this.CaseReq).subscribe((res: any) => { })
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
