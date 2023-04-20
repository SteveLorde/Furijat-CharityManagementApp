import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Mail } from '../../Models/Mail';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { MailServiceBackendService } from 'src/app/Services/MailServiceBackend/mail-service-backend.service';

@Component({
  selector: 'app-contactformbackend',
  templateUrl: './contactformbackend.component.html',
  styleUrls: ['./contactformbackend.component.css']
})
export class ContactformbackendComponent implements OnInit {

  mail: Mail
  mailsent: string

  constructor(private _mailservicebackend: MailServiceBackendService) { }

  ngOnInit(): void {
  }

  ContactForm = new FormGroup({
    ToEmail: new FormControl(),
    Subject: new FormControl(),
    Body: new FormControl(),
  })

  submit() {
    this.mail = this.ContactForm.value
    this._mailservicebackend.postmessage(this.mail).subscribe((res: any) => {
      if (res)
      {
        this.mailsent = "Mail sent successfully to" + this.mail.ToEmail
      }
    })
  }

}
