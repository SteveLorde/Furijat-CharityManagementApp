import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Case } from '../../Models/Case';
import { Charity } from '../../Models/Charity';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-provideassistance',
  templateUrl: './provideassistance.component.html',
  styleUrls: ['./provideassistance.component.css']
})
export class ProvideassistanceComponent {

  charity: Charity
  cases: Case
  id: any
  //paymentmethodVISA: boolean = false
  //paymentmethodFawry: boolean = false
  paymentmethod: any
  donateamount: number = 0
  cardnumber: number = 0
  cardccv: number = 0
  fawrynumber: number = 0

  constructor(private router: Router, private _Activatedroute: ActivatedRoute, private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this._servercom.getCharitybyId(this.id).subscribe((res: any) => {
      this.charity = res
    })
  }


  Donate() {
    //this.charity. = this.donateamount
    //this.donatelog.PushtoListCharity(this.charity)
    //api request to POST donation to specific charity
    this.Close()
  }

  /*
  CreateCasePayment() {
    this.casepayservice.casepayment.id = this.case.id
    //this.casepayservice.casepayment.paymentMethod =
    this.casepayservice.casepayment.paymentAmount = this.donateamount
    this.casepayservice.CasePay()
  }
  */

  Close() {
    this.router.navigateByUrl('/charitylist')
  }

}
