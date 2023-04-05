import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Case } from 'src/app/Models/Case';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

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

  Cases: Case[] = [];
  searchText: string;
  p: number = 1;
  name: any;

  constructor(private _ServerCom: BackendCommunicationService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.GetCases()
  }

  GetCases() {
    this._ServerCom.getCases().subscribe((res: any[]) => {
      this.Cases = res;
    });
  }

}
