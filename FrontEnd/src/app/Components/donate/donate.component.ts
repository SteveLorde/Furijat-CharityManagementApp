import { Component, OnInit } from '@angular/core';
import { Case } from 'src/app/Models/Case';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { DonatelogService } from 'src/app/Services/DonateLog/donatelog.service';
import { CasePaymentService } from 'src/app/Services/CasePayment/case-payment.service'

@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.css']
})
export class DonateComponent implements OnInit {

  case = {} as Case
  id: any
  donateamount: number = 0
paymentmethod: any

  constructor(private donatelog: DonatelogService, private router: Router, private _Activatedroute: ActivatedRoute, private _servercom: BackendCommunicationService, private casepayservice: CasePaymentService) { }

  ngOnInit(): void {
    //Retrieve Case from Database by ID
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this._servercom.getCasesById(this.id).subscribe((res: any) => {
      this.case = res
    })
    //this.case.currentAmount = this.case.currentAmount + this.donateamount
  }

  Donate() {
    this.case.currentAmount = this.case.currentAmount + this.donateamount
    console.log("current amount is ", this.case.currentAmount)
    this.CreateCasePayment()
    this._servercom.updateCase(this.case, this.id).subscribe()
    this.Close()
  }

  CreateCasePayment() {
    //this.casepayservice.Setcasepayment(this.case.id, this.donateamount)
    this.casepayservice.AddCasePayment().subscribe()
    console.log("Creating CasePay" + this.casepayservice.casepayment)
  }

  Close() {
    this.router.navigateByUrl('/Case')
  }


}
