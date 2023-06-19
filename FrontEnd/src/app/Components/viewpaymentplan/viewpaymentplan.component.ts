import { Component } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Case } from '../../Models/Case';
import { Charity } from '../../Models/Charity';
import { ContactMessage } from '../../Models/ContactMessage';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { MailServiceBackendService } from '../../Services/MailServiceBackend/mail-service-backend.service';

@Component({
  selector: 'app-viewpaymentplan',
  templateUrl: './viewpaymentplan.component.html',
  styleUrls: ['./viewpaymentplan.component.css']
})
export class ViewpaymentplanComponent {

  case = {} as Case
  charity = {} as Charity
  id: any
  selectedemail: any
  contactmessage: ContactMessage
  errorMessage: any
  contactcase: boolean = false
  edittype: string = 'case'

  @ViewChild(ChildComponent) childComponent: ChildComponent


  constructor(private router: Router, private _Activatedroute: ActivatedRoute, private http: BackendCommunicationService, private mailservice: MailServiceBackendService) { }

  ngOnInit(): void {
    //Retrieve Case from Database by ID
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this.http.getCasesById(this.id).subscribe((res: Case) => {
      this.case = res
      this.charity = res.charity
    })
  }

  ContactForm = new UntypedFormGroup({
    //name: new UntypedFormControl(''),
    Subject: new UntypedFormControl(''),
    Body: new UntypedFormControl(''),
    ToEmail: new UntypedFormControl(''),
  })

  EditCase() {
    this.router.navigate(['/edit'], { queryParams: { id: this.case.id, edittype: this.edittype } })
  }

  ContactCase() {
    this.contactcase = !this.contactcase
  }

  DebtResolution() {
    this.contactmessage.ToEmail = "mostafa.maher98@gmail.com"
    this.contactmessage.Subject = "Your Debt Has Been Resolved"
    this.contactmessage.Body = "Congratulations Mr/Mrs" + this.case.firstName + this.case.lastName + "your debt has been resolved by your creditor"
    this.mailservice.postmessage(this.contactmessage).subscribe()

    this.contactmessage.ToEmail = "mostafa.maher98@gmail.com"
    this.contactmessage.Subject = "Creditor resolved debt of case" + this.case.firstName + "of ID" + this.case.id
    this.contactmessage.Body = "Creditr of Case" + this.case.firstName + this.case.lastName + "has resolved their debt"
    this.mailservice.postmessage(this.contactmessage).subscribe()
    this.case.totalAmount = 0
    this.http.updateCase(this.case.id, this.case).subscribe((res: any) => {
      Swal.fire('Case Debt resolved successfully')
    })
    this.router.navigateByUrl('/profile')
  }

}
