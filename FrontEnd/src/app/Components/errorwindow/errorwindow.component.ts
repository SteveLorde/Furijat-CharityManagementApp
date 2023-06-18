import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-errorwindow',
  templateUrl: './errorwindow.component.html',
  styleUrls: ['./errorwindow.component.css']
})
export class ErrorwindowComponent {

@Input() errorMessage: string;


close() {}

}
