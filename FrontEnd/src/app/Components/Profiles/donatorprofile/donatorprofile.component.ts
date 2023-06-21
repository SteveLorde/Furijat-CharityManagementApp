import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { BackendCommunicationService } from '../../../Services/BackendCommunication/backend-communication.service';
import { UserlogComponent } from 'src/app/Components/userlog/userlog.component'

@Component({
  selector: 'app-donatorprofile',
  templateUrl: './donatorprofile.component.html',
  styleUrls: ['./donatorprofile.component.css']
})
export class DonatorprofileComponent {

  constructor(private http: BackendCommunicationService, private router: Router) { }

  ngOnInit(): void {

  }

  @ViewChild('childComponent', { static: true }) donationlog: UserlogComponent

  ViewCases() {
    this.router.navigateByUrl('/case')
  }
  Message() {
    this.router.navigateByUrl('/contactform')
  }

}
