import { Component } from '@angular/core';
import {Case} from "../../../Data/Models/Case";

@Component({
  selector: 'app-cases-page',
  templateUrl: './cases-page.component.html',
  styleUrls: ['./cases-page.component.css']
})
export class CasesPageComponent {

  //variables
  Cases : Case[] = []
  constructor() {
  }

  GetCases() {
    //api call
    //this.Cases =
  }

}
