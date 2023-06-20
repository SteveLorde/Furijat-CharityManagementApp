import { Component, OnInit } from '@angular/core';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';
import { Case } from 'src/app/Models/Case';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Charity } from '../../Models/Charity';
import Swal from 'sweetalert2';

export interface PagingConfig {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
}

@Component({
  selector: 'app-casetablenative',
  templateUrl: './casetablenative.component.html',
  styleUrls: ['./casetablenative.component.css']
})
export class CasetablenativeComponent implements OnInit {

  Cases = { charity: { } as Charity } as Case
  searchText: string;
  p: number = 1
  name: any
  status: any
  usertype: any

  statusfilter: any = 'approved'

  constructor(private http: BackendCommunicationService, private route: ActivatedRoute,private router: Router) {}

  ngOnInit(): void {
    this.usertype = localStorage.getItem('usertype')
    this.GetCases()
  }

  GetCases() {
    this.http.getCases().subscribe((res) => {
      this.Cases = res
    })
  }

  Donate(element: Case) {
    console.log(this.usertype)
    if (this.usertype == 'donator') {
      this.router.navigate(['/donate'], { queryParams: { id: element.id } })
    }
    else {
      Swal.fire({
        title: 'No Permission to Donate, only registered Donators allowed would you like to register?',
        showCancelButton: true,
        confirmButtonText: 'Register',
        cancelButtonText: 'No'
      }).then((result) => {
        if (result.isConfirmed) {
          this.router.navigate(['/register']); // Replace '/new-page' with the desired route
        }
      })
    }
  }
}
