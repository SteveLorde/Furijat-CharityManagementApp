import { Component } from '@angular/core';
import { Case } from '../../../Models/Case';
import { Charity } from '../../../Models/Charity';
import { User } from '../../../Models/User';
import { BackendCommunicationService } from '../../../Services/BackendCommunication/backend-communication.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-charityprofile',
  templateUrl: './charityprofile.component.html',
  styleUrls: ['./charityprofile.component.css']
})
export class CharityprofileComponent {

  constructor(private http: BackendCommunicationService, private router: Router) { }

  ngOnInit(): void {
  }

  user = {} as User
  Cases = { charity: {} as Charity } as Case
  id: any
  utid: any
  usertype: any
  p: number = 1

  GenerateReport() {

  }

  Message() {
    this.router.navigateByUrl('/contactform');
  }

  GetCases() {
    this.http.getCases().subscribe((res) => {
      this.Cases = res
    })
  }


  EditCase() {

  }

  approve(element: any, id:any ) {
    element.id = id
    element.status = "In Need"
    element.charity.id =
    this.http.updateCase(id, element).subscribe()
  }

  reject(element: Case, id: any) {
    element.id = id
    element.status = "waiting"
    element.charity.id = 0
    this.http.updateCase(id,element).subscribe()
  }
  ProvideAssistance() {
    this.router.navigateByUrl('/provideassistancebycharity')
  }

  DeleteCase(id: any, element: Case) {

  }

}
