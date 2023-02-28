import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BackendCommunicationService } from 'src/app/Services/BackendCommunication/backend-communication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public forecasts?: WeatherForecast[];

  constructor(http: HttpClient) {
  }

  title = 'FrontEnd';
}


/* test function
getCars(): void {
  this.Backend.getAll().subscribe(
    (data: Car[]) => {
      this.cars = data;
      this.success = 'successful retrieval of the list';
    },
    (err) => {
      console.log(err);
      this.error = err;
    }
  );
}
*/

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
