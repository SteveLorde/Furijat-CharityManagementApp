import { Component } from '@angular/core';
import {Charity} from "../../../Data/Models/Charity";

@Component({
  selector: 'app-charities-page',
  templateUrl: './charities-page.component.html',
  styleUrls: ['./charities-page.component.css']
})
export class CharitiesPageComponent {

  //variables
  Charities : Charity[] = []
  constructor() {
  }

  GetCharities() {
    //api call
    //this.Charities =
  }

}
