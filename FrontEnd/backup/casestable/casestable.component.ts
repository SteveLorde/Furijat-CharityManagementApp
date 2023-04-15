import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { MatTableDataSource } from '@angular/material/table';
import { Case } from 'src/app/Models/Case';


@Component({
  selector: 'app-casestable',
  templateUrl: './casestable.component.html',
  styleUrls: ['./casestable.component.css']
})
export class CasestableComponent implements OnInit {

  dataSource: Case[]

  constructor(private _ServerCom: BackendCommunicationService) { }

  ngOnInit(): void {
    //this.GetCases();
  }
  /*
  displayedColumns: string[] = ['id', 'name', 'email'];

  this.dataSource = new MatTableDataSource<Case>();

  //Function that calls API (GET) to retrieve Case List
  GetCases() {
    return this._ServerCom.getCases().subscribe((data) => {
      this.dataSource = data;
    });
  }

  public filterProduct = (value: string) => {
    this.dataSource.filter = value;
  }
  */
}
