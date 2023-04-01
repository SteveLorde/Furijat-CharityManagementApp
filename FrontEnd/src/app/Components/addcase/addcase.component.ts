import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Case } from 'src/app/Models/Case';

@Component({
  selector: 'app-addcase',
  templateUrl: './addcase.component.html',
  styleUrls: ['./addcase.component.css']
})
export class AddcaseComponent implements OnInit {

  constructor() { }

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


  addCaseRequest: Case = {
      id: 0,
      firstName: '',
      lastName: '',
      description: '',
      address: '',
      currentAmount: 0,
      totalAmount: 0,
      status: ''
  }

  AddCase(CaseRequest: Case) {

  }

  onSubmit() {
    console.log(this.AddCaseForm.value);
  }

}
