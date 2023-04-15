import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { CaseDTO } from 'src/app/Models/Case';
import { BackendCommunicationService } from '../../src/app/Services/BackendCommunication/backend-communication.service';


@Component({
  selector: 'app-casestable',
  templateUrl: './casestable.component.html',
  styleUrls: ['./casestable.component.css']
})
export class CasestableComponent implements OnInit {

  dataSource: CaseDTO[]

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
