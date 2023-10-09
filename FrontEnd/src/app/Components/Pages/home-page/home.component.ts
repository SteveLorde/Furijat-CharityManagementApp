import { Component } from '@angular/core';
import {News} from "../../../Data/Models/News";
import {APIService} from "../../../Services/APIService/api.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  News: News[] = []

  constructor(private http : APIService) {
  }

  ngOnInit() {
    this.GetNews()
  }

  private GetNews() {
    this.http.GetNews().subscribe((result : News) => this.News = this.News.concat(result) )
  }


}
