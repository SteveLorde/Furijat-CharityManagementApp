import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BackendCommunicationService } from '../../../Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-donatorprofile',
  templateUrl: './donatorprofile.component.html',
  styleUrls: ['./donatorprofile.component.css']
})
export class DonatorprofileComponent {

  constructor(private http: BackendCommunicationService, private router: Router) { }

  ngOnInit(): void {

  }

  ViewCases() {
    this.router.navigateByUrl('/case')
  }


}
