import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { MatTableDataSource } from '@angular/material/table';

//test interface/class
export interface todo {
  userid: number;
  id: number;
  title: string;
  completed: string;
}

@Component({
  selector: 'app-casestable',
  templateUrl: './casestable.component.html',
  styleUrls: ['./casestable.component.css']
})
export class CasestableComponent implements OnInit {

  constructor(private _ServerCom: BackendCommunicationService) { }

  ngOnInit(): void {
    this.GetCases();
  }

  displayedColumns: string[] = ['id', 'name', 'email'];

  dataSource = new MatTableDataSource<todo>();

  //Function that calls API (GET) to retrieve Case List
  GetCases() {
    return this._ServerCom.getTEST().subscribe((data) => {
      this.dataSource = data;
    });
  }

  public filterProduct = (value: string) => {
    this.dataSource.filter = value;
  }
}
