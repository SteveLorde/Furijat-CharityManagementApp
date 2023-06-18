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
    this.id = this.route.snapshot.queryParamMap.get('id');
    this.edittype = this.route.snapshot.queryParamMap.get('edittype');
  }

  getcase() {
    this.http.getCasesById(this.id).subscribe((res) => {
      this.editelement = res
    })
  }

  getcharity() {
    this.http.getCasesById(this.id).subscribe((res) => {
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
    this.router.navigateByUrl('/profile')
  }

  SubmitEditCharity() {
    this.http.UpdateCharitybyID(this.editelement, this.editelement.id).subscribe()
    this.router.navigateByUrl('/profile')
  }

  SubmitEditDonator() {
    this.http.UpdateCharitybyID(this.editelement, this.editelement.id).subscribe()
    this.router.navigateByUrl('/profile')
  }

  SubmitEditCreditor() {
    this.http.UpdateCharitybyID(this.editelement, this.editelement.id).subscribe()
    this.router.navigateByUrl('/profile')
  }

  SubmitEditUser() {
    this.http.UpdateUser(this.editelement, this.editelement.id).subscribe()
    this.router.navigateByUrl('/profile')
  }


 }
