import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from 'src/app/Services/BackendCommunication/backend-communication.service';
import { FormsModule } from '@angular/forms';
import { Case } from 'src/app/Models/Case'
import { Charity } from 'src/app/Models/Charity'

@Component({
  selector: 'app-case-list',
  templateUrl: './case-list.component.html',
  styleUrls: ['./case-list.component.css']
})
export class CaseListComponent implements OnInit {

  constructor(private _ServerCom: BackendCommunicationService) { }

  //declare an empty array for Case interface
  public Cases: any = [];
  public case = new Case();
  public CharityList: Charity[] = [];

  ngOnInit(): void {
    this.GetCases();
    this.fetchStudents();
  }

  //Function that calls API (GET) to retrieve Case List
  GetCases() {
    return this._ServerCom.getTEST().subscribe((data) => {
      this.Cases = data;
    });
  }

  //test for pagination
  Students: any;
  allStudents: number = 0;
  pagination: number = 1;
  fetchStudents() {
    this._ServerCom.getStudents(this.pagination).subscribe((res: any) => {
      this.Students = res.data;
      this.allStudents = res.total;
      console.log(res.total);
    });
  }
  renderPage(event: number) {
    this.pagination = event;
    this.fetchStudents();
  }
  
  //function that calls API (POST) to create new cases in list
  PostCases() {
    return this._ServerCom.PostTest(this.case).subscribe()
  }
}

