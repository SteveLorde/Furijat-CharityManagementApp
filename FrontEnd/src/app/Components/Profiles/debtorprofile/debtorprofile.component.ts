import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Case } from '../../../Models/Case';
import { Charity } from '../../../Models/Charity';
import { BackendCommunicationService } from '../../../Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-debtorprofile',
  templateUrl: './debtorprofile.component.html',
  styleUrls: ['./debtorprofile.component.css']
})
export class DebtorprofileComponent {

  userid: any
  Charities: Charity

  assistanceform: boolean = false

  case: Case

  constructor(private http: BackendCommunicationService, private router: Router, private fb: FormBuilder) { }

  ngOnInit(): void {

    this.userid = localStorage.getItem('userid')
    this.GetCasebyID(this.userid)
  }

  form = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    description: ['', Validators.required],
    address: ['', [Validators.required, Validators.email]],
    phonenumber: ['', Validators.minLength(8)],
    totalamount: ['', Validators.required],
    selectedcharity: ['', Validators.required],
  })




  GetCasebyID(id: any) {
    this.http.getCasesById(id).subscribe((res: Case) => {
      this.case = res
    })
  }

  GetCharities() {
    this.http.getCharity().subscribe((res: any) => {
      this.Charities = res
    })
  }

  ApplyForAssistance() {

  }


}
