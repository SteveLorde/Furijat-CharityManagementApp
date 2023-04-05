import { Component, OnInit } from '@angular/core';
import { Case } from 'src/app/Models/Case';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';




@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.css']
})
export class DonateComponent implements OnInit {

  case: Case = {
      id: 0,
      firstName: '',
      lastName: '',
      description: '',
      address: '',
      currentAmount: 0,
      totalAmount: 0,
      status: ''
  }

  id: any
  donateamount: number = 0

  constructor(private router: Router, private _Activatedroute: ActivatedRoute, private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    //Retrieve Case from Database by ID
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this._servercom.getCasesById(this.id).subscribe((res: any) => {
      this.case = res
    })

    this.case.currentAmount = this.case.currentAmount + this.donateamount
  }


  Donate() {
    this.case.currentAmount = this.case.currentAmount + this.donateamount
    console.log("current amount is ", this.case.currentAmount)
    this._servercom.updateCase(this.case, this.id).subscribe()
    this.Close()
  }

  Close() {
    this.router.navigateByUrl('/Case')
  }


}
