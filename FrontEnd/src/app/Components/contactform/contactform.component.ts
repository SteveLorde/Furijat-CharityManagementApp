import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { Charity } from '../../Models/CharityDTO';
import { ContactMessage } from '../../Models/ContactMessage';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { MailserviceService } from 'src/app/Services/MailService/mailservice.service';

@Component({
  selector: 'app-contactform',
  templateUrl: './contactform.component.html',
  styleUrls: ['./contactform.component.css'],
})
export class ContactformComponent implements OnInit {
  charity: Charity;
  contactmessage: ContactMessage;
  errorMessage: any;

  constructor(
    private mailservice: MailserviceService,
    private _servercom: BackendCommunicationService
  ) {}

  ngOnInit(): void {
    this.GetCharities();
  }

  ContactForm = new UntypedFormGroup({
    name: new UntypedFormControl(),
    message: new UntypedFormControl(),
    email: new UntypedFormControl(),
  });

  GetCharities() {
    this._servercom.getCharity().subscribe((res: any) => {
      this.charity = res;
    });
  }

  submit(contactmessage: ContactMessage) {
    contactmessage = this.ContactForm.value;
    //console.log(contactmessage)
    this.mailservice.postmessage(contactmessage).subscribe((res: any) => {
      if (res.ok) {
        this.ContactForm.reset();
      } else {
        console.error(res);
      }
    });
  }
}
