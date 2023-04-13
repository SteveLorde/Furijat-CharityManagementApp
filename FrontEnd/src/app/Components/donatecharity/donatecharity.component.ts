import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Charity } from 'src/app/Models/Charity';
import { ActivatedRoute, Router } from '@angular/router';
import { DonatelogService } from 'src/app/Services/DonateLog/donatelog.service';


@Component({
  selector: 'app-donatecharity',
  templateUrl: './donatecharity.component.html',
  styleUrls: ['./donatecharity.component.css']
})
export class DonatecharityComponent implements OnInit {

  charity: Charity = {
      id: 0,
      name: '',
      description: '',
      location: '',
      phone: '',
      email: ''
  }

  id: any
  donateamount: number = 0
  cardnumber: number = 0
  cardccv: number = 0

  constructor(private donatelog: DonatelogService, private router: Router, private _Activatedroute: ActivatedRoute, private _servercom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this._servercom.getCharitybyId(this.id).subscribe((res: any) => {
      this.charity = res
    })
  }


  Donate() {
    //this.charity.currentAmount = this.case.currentAmount + this.donateamount
    //console.log("current amount is ", this.charity.currentAmount)
    //this._servercom.updateCase(this.case, this.id).subscribe()
    this.donatelog.PushtoListCharity(this.charity)
    this.Close()
  }

  Close() {
    this.router.navigateByUrl('/charitylist')
  }


}
