import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Case } from '../../../Models/Case';
import { Creditor } from '../../../Models/Creditor';
import { Charity } from '../../../Models/Charity';
import { BackendCommunicationService } from '../../../Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-creditorprofile',
  templateUrl: './creditorprofile.component.html',
  styleUrls: ['./creditorprofile.component.css']
})
export class CreditorprofileComponent {

  creditor: Creditor 
  p: number = 1
  Cases: Case

  constructor(private http: BackendCommunicationService, private router: Router) { }

  ngOnInit(): void {
    //this.userid = localStorage.getItem('userid')
    //this.GetCreditorandCasebyID(this.userid)
  }

  GetCreditorandCasebyID(id: number) {
    this.http.GetCreditorByID(id).subscribe((res: Creditor) => {
      this.http.getCasesById(res.caseID).subscribe((res: Case) => {
        this.Cases = res
      })
    })
  }

 
  ViewPaymentPlan() {

  }

}
