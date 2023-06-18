import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Case } from '../../../Models/Case';
import { BackendCommunicationService } from '../../../Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-debtorprofile',
  templateUrl: './debtorprofile.component.html',
  styleUrls: ['./debtorprofile.component.css']
})
export class DebtorprofileComponent {

  userid: any

  constructor(private http: BackendCommunicationService, private router: Router) { }

  ngOnInit(): void {
    this.userid = localStorage.getItem('userid')
    this.GetCasebyID(this.userid)
  }

  assistanceform: boolean = false

  case: Case


  GetCasebyID(id: any) {
    this.http.getCasesById(id).subscribe((res: Case) => {
      this.case = res
    })
  }

  ApplyForAssistance() {

  }


}
