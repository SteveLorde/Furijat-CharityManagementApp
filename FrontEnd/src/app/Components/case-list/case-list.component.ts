import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from 'src/app/Services/BackendCommunication/backend-communication.service';
import { Case } from 'src/app/Models/Case'
import { Charity } from 'src/app/Models/Charity'

@Component({
  selector: 'app-case-list',
  templateUrl: './case-list.component.html',
  styleUrls: ['./case-list.component.css']
})
export class CaseListComponent implements OnInit {

  constructor(private _ServerCom: BackendCommunicationService) { }


  public Case: any = [];
  public CharityList: Charity[] = [];

  ngOnInit(): void {
    this.GetCases();
  }

  //Function that calls API (GET) to retrieve Case List
  GetCases() {
    return this._ServerCom.getTEST().subscribe((data: {}) => {
      this.Case = data;
    });
  }
}

