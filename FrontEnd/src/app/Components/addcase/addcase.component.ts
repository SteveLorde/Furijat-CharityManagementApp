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


  charity = { } as  Charity
  CaseReq = { } as CaseDTO
  Case2 = {} as CaseDTO

  



  constructor(private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.GetCharities()
    this.Case2.charity = {} as Charity
    //this.Case2.charity.Id = 4
    //console.log(this.Case2)
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
    this.Case2.firstName = this.AddCaseForm.get('firstname').value
    this.Case2.lastName = this.AddCaseForm.get('lastname').value
    this.Case2.description = this.AddCaseForm.get('description').value
    this.Case2.address = this.AddCaseForm.get('address').value
    this.Case2.currentAmount = this.AddCaseForm.get('currentamount').value
    this.Case2.totalAmount = this.AddCaseForm.get('totalamount').value
    this.Case2.charity.id = this.AddCaseForm.get('charityid').value
    console.log(this.Case2)
    this._servercom.addCase(this.Case2).subscribe()
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
