import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Case } from 'src/app/Interfaces/Case';

@Component({
  selector: 'app-casetablenative',
  templateUrl: './casetablenative.component.html',
  styleUrls: ['./casetablenative.component.css']
})
export class CasetablenativeComponent implements OnInit {

  Cases: Case[] = [];
  searchText: string;

  constructor(private _ServerCom: BackendCommunicationService) { }

  ngOnInit(): void {
    this._ServerCom.getTEST().subscribe((res: any[]) => {
      this.Cases = res;
    });
  }

}
