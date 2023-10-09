import { Component } from '@angular/core';
import {Case} from "../../../Data/Models/Case";
import {APIService} from "../../../Services/APIService/api.service";

@Component({
  selector: 'app-cases-page',
  templateUrl: './cases-page.component.html',
  styleUrls: ['./cases-page.component.css']
})
export class CasesPageComponent {

  //variables
  Cases : Case[] = []
  constructor(private http : APIService) {
  }

  ngOnInit() {
    this.GetNews()
  }

  private GetNews() {
    this.http.GetNews().subscribe( (result : Case) => this.Cases = this.Cases.concat(result))
  }


}
