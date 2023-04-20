import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { CaseDTO } from 'src/app/Models/CaseDTO';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Charity } from '../../Models/CharityDTO';

export interface PagingConfig {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
}

@Component({
  selector: 'app-casetablenative',
  templateUrl: './casetablenative.component.html',
  styleUrls: ['./casetablenative.component.css']
})
export class CasetablenativeComponent implements OnInit {

  Cases: CaseDTO
  charity: Charity
  searchText: string;
  p: number = 1
  name: any
  status: any

  constructor(private _ServerCom: BackendCommunicationService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.GetCases()
  }

  GetCases() {
    this._ServerCom.getCases().subscribe((res: any) => {
      this.Cases = res;
    });
  }

}
