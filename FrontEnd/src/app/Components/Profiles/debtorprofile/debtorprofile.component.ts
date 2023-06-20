import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Case } from '../../../Models/Case';
import { Charity } from '../../../Models/Charity';
import { Creditor } from '../../../Models/Creditor';
import { User } from '../../../Models/User';
import { BackendCommunicationService } from '../../../Services/BackendCommunication/backend-communication.service';
import { UserStorageService } from '../../../Services/UserStorageService/user-storage.service';

@Component({
  selector: 'app-debtorprofile',
  templateUrl: './debtorprofile.component.html',
  styleUrls: ['./debtorprofile.component.css']
})
export class DebtorprofileComponent {

  user: User
  Charities: Charity

  assistanceform: boolean = false

  case: Case
  Creditors: Creditor

  caseidtofilter: any


  constructor(private http: BackendCommunicationService, private router: Router, private fb: FormBuilder, private userstorage: UserStorageService) { }

  ngOnInit(): void {

    this.user.id = this.userstorage.user.id
    this.GetCasebyID(this.user.id)
  }



  form = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    description: ['', Validators.required],
    address: ['', [Validators.required, Validators.email]],
    phonenumber: ['', Validators.minLength(7)],
    totalamount: ['', Validators.required],
    selectedcharity: ['', Validators.required],
  })

  GetCasebyID(id: any) {
    this.http.getCasesById(id).subscribe((res: Case) => {
      this.case = res
      this.caseidtofilter = res.id
    })
  }

  GetCharities() {
    this.http.getCharity().subscribe((res: any) => {
      this.Charities = res
    })
  }

  AcceptCreditor(creditor: Creditor) {
    creditor.caseID = this.case.id
    this.http.UpdateCreditorByID(creditor.id, creditor).subscribe((res: any) => {

    },
      (error) => {
        Swal.fire(error.error)
      })
  }

  RejectCreditor(creditor: Creditor) {
    creditor.caseID = this.case.id
    this.http.UpdateCreditorByID(creditor.id, creditor).subscribe((res: any) => {

    },
      (error) => {
        Swal.fire(error.error)
      })
  }

  ApplyForAssistance() {

  }
  ToggleAssistFor() {
    this.assistanceform = !this.assistanceform
  }

}
