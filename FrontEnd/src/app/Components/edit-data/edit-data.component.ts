import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-data',
  templateUrl: './edit-data.component.html',
  styleUrls: ['./edit-data.component.css']
})
export class EditDataComponent {

  edittype: any
  id: any
  editelement: any

  constructor( private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
      this.edittype = params['edittype']

      if (this.edittype == 'charity') {

      }
      else if (this.edittype == 'case') {

      }
      else if (this.edittype == 'donator') {

      }
      else if (this.edittype == 'creditor') {

      }
    })
  }


 }
