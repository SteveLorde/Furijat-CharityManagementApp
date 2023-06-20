import { Component } from '@angular/core';
import Swal from 'sweetalert2';
import { MailServiceBackendService } from '../../Services/MailServiceBackend/mail-service-backend.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {

  constructor(private mail: MailServiceBackendService) { }

  ngOnInit() {
  }

  Subscribe() {
    Swal.fire('You have subscribed to newsletters, check your email')
    this.mail.fakemessagenewsletter().subscribe()
  }
}
