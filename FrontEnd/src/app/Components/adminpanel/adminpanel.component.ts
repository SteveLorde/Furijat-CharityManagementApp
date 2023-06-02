import { Component } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-adminpanel',
  templateUrl: './adminpanel.component.html',
  styleUrls: ['./adminpanel.component.css']
})

export class AdminpanelComponent {


  constructor(private backend: BackendCommunicationService) { }

  ngOnInit(): void {

  }


  view: any

  Users: any
  Cases: any
  Donators: any
  Charities: any
  Creditors: any

  FetchUsers() { this.backend.getUsers().subscribe((res) => { this.Users = res }) }
  FetchDebtors() { this.backend.getCases().subscribe((res) => { this.Cases = res }) }
  FetchCharities() {this.backend.getCharity().subscribe((res) => {this.Charities = res}) }
  //FetchCreditors() { this.backend.getcreditors().subscribe((res) => { this.Creditors = res }) }
  FetchDonators() { }

  
  SetView(view) {
    this.view = view
    console.log("successfully got click event setting view to " + this.view)
    switch (this.view) {
      case 'users': {
        this.FetchUsers()
        break
      }
      case 'debtors': {
        this.FetchDebtors()
        break
      }
      case 'charities': {
        this.FetchCharities()
        break
      }
      case 'donators': {

        break
      }
      case 'creditors': {

        break
      }
      default:
    }
  }

}
