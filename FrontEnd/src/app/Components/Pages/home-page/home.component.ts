import { Component } from '@angular/core';
import {News} from "../../../Data/Models/News";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  News: News[]


}
