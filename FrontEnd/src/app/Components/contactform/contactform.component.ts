import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, UntypedFormGroup, UntypedFormControl } from '@angular/forms';
import { Charity } from '../../Models/Charity';
import { ContactMessage } from '../../Models/ContactMessage';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { MailServiceBackendService } from 'src/app/Services/MailServiceBackend/mail-service-backend.service';
import Swal from 'sweetalert2';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contactform',
  templateUrl: './contactform.component.html',
  styleUrls: ['./contactform.component.css'],
})
export class ContactformComponent implements OnInit {
  charity: Charity
  selectedemail: any
  contactmessage: ContactMessage
  errorMessage: any

  selectedemailroute: any

  constructor(
    private mailservice: MailServiceBackendService, private _servercom: BackendCommunicationService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.selectedemailroute = params['selectedemail']
    })
    this.GetCharities()
  }

  ContactForm = new UntypedFormGroup({
    Subject: new UntypedFormControl(''),
    Body: new UntypedFormControl(''),
    ToEmail: new UntypedFormControl(''),
  })

  GetCharities() {
    this._servercom.getCharity().subscribe((res: any) => {
      this.charity = res;
    });
  }

  submit(contactmessage: ContactMessage) {
    contactmessage = this.ContactForm.value
    contactmessage.ToEmail = "mostafa.maher98@gmail.com"
    this.mailservice.postmessage(contactmessage).subscribe((res: any) => {
      if (res.ok) {
        Swal.fire('Mail Sent Successfully')
        this.ContactForm.reset();
      } else {
        console.error(res)
        Swal.fire('Mail Sent Successfully')
      }
    })
  }
}
