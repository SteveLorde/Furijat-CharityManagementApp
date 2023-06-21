import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BackendCommunicationService } from 'src/app/Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  Login: any
  IsLoggedIn: any

  constructor(http: HttpClient) {
    this.IsLoggedIn = localStorage.getItem('loggedin')
  }

  ngOnInit() {
  }

  title = 'Furijat Application';



}
