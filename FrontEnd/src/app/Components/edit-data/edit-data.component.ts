import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-edit-data',
  templateUrl: './edit-data.component.html',
  styleUrls: ['./edit-data.component.css']
})
export class EditDataComponent {

  edittype: any
  id: any
  editelement: any

  constructor(private http: BackendCommunicationService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
      this.edittype = params['edittype']

      if (this.edittype == 'charity') {
        this.getcharity()
      }
      else if (this.edittype == 'case') {
        this.getcase()
      }
      else if (this.edittype == 'donator') {
        this.getdonator()
      }
      else if (this.edittype == 'creditor') {
        this.getcreditor()
      }
    })
  }

  GoProfile() {
    this.router.navigateByUrl('/profile')
  }

  getcase() {
    this.http.getCasesById(this.id).subscribe((res) => {
      this.editelement = res
    })
  }

  getcharity() {
    this.http.getCharitybyId(this.id).subscribe((res) => {
      this.editelement = res
    })
  }

  getcreditor() {
    this.http.getCasesById(this.id).subscribe((res) => {
      this.editelement = res
    })
  }

  getdonator() {
    this.http.getCasesById(this.id).subscribe((res) => {
      this.editelement = res
    })
  }

  getuser() {
    this.http.getCasesById(this.id).subscribe((res) => {
      this.editelement = res
    })
  }

  SubmitEditCase() {
    this.http.updateCase(this.editelement, this.editelement.id).subscribe()
  }

  SubmitEditCharity() {
    this.http.UpdateCharitybyID(this.editelement.id,this.editelement).subscribe()
  }

  SubmitEditDonator() {
    this.http.UpdateCharitybyID(this.editelement, this.editelement.id).subscribe()
  }

  SubmitEditCreditor() {
    this.http.UpdateCharitybyID(this.editelement, this.editelement.id).subscribe()
  }

  SubmitEditUser() {
    this.http.UpdateUser(this.editelement, this.editelement.id).subscribe()
  }


 }
