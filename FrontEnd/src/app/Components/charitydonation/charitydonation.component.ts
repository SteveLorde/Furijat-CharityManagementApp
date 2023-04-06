import { Component, OnInit } from '@angular/core';
import { Charity } from 'src/app/Models/Charity';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';


@Component({
  selector: 'app-charitydonation',
  templateUrl: './charitydonation.component.html',
  styleUrls: ['./charitydonation.component.css']
})
export class CharitydonationComponent implements OnInit {

  charity: Charity
  searchText: string;
  p: number = 1

  constructor(private _ServerCom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.GetCharities()
  }

  GetCharities() {
    this._ServerCom.getCharity().subscribe((res: any) => {
      this.charity = res;
    });
  }

}
