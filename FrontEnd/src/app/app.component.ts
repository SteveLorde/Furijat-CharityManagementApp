import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BackendCommunicationService } from 'src/app/Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(http: HttpClient) {
  }

  title = 'FrontEnd';

  isUserAuthenticated = (): boolean => {
    return false
  }
  logOut = () => {
    localStorage.removeItem("jwt");
  }

}
