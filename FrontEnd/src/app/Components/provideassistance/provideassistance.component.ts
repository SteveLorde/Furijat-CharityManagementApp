import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Case } from '../../Models/Case';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { CasePaymentService } from '../../Services/CasePayment/case-payment.service';

@Component({
  selector: 'app-provideassistance',
  templateUrl: './provideassistance.component.html',
  styleUrls: ['./provideassistance.component.css']
})
export class ProvideassistanceComponent {
  case = {} as Case
  id: any
  donateamount: number = 0

  constructor(private router: Router, private _Activatedroute: ActivatedRoute, private _servercom: BackendCommunicationService, private casepayservice: CasePaymentService) { }

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
    this.router.navigateByUrl('/Profile')
  }


}
