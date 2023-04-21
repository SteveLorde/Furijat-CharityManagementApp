import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup, UntypedFormControl, Validators } from '@angular/forms'
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { CaseDTO } from 'src/app/Models/CaseDTO';
import { Charity } from '../../Models/CharityDTO';

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
      //charity: {} as Charity
  }

  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.GetCharities()
    console.log("Testing CaseReq" + this.CaseReq)
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
    this.CaseReq.firstName = this.AddCaseForm.get('firstname').value
    this.CaseReq.lastName = this.AddCaseForm.get('lastname').value
    this.CaseReq.description = this.AddCaseForm.get('description').value
    this.CaseReq.address = this.AddCaseForm.get('address').value
    this.CaseReq.currentAmount = this.AddCaseForm.get('currentamount').value
    this.CaseReq.totalAmount = this.AddCaseForm.get('totalamount').value
    this.CaseReq.status = "notvalid"
    //this.CaseReq.charity.id = this.AddCaseForm.get('charityid').value
    console.log(this.CaseReq)
    this._servercom.addCase(this.CaseReq).subscribe((res: any) => {
      if (res.status == 400, 401, 500 ) {
        this.AddCaseForm.reset
      }
    })

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
