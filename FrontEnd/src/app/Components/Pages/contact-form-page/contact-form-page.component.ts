import { Component } from '@angular/core';
import { ContactMessage } from '../../../Data/Models/ContactMessage'
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-contact-form-page',
  templateUrl: './contact-form-page.component.html',
  styleUrls: ['./contact-form-page.component.css']
})
export class ContactFormPageComponent {

  constructor() {
  }

  contactform = new FormGroup( {
    ToSend : new FormControl(''),
    Subject : new FormControl(''),
    Body : new FormControl(''),
  })

  submitmail() {
    let mail: ContactMessage = {Body: "", Subject: "", ToSend: ""}
    Object.assign(mail, this.contactform.value)
    this.contactform.reset()

    //call api

    // re-null mail
    mail = {Body: '', Subject: '', ToSend:''}


  }

}
