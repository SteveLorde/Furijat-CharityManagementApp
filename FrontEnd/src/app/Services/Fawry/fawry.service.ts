import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FawryService {

  constructor() { }

  apiurl = 'https://atfawry.fawrystaging.com/ECommerceWeb/Fawry/payments/charge';


}
