import { Pipe, PipeTransform } from '@angular/core';
//import { Donation } from '../../Models/Donation';

@Pipe({
  name: 'filterpendingdonationsbycaseid'
})
export class FilterbycaseidPipe implements PipeTransform {

  transform(items: any[], caseid: number): any[] {
    if (!items) return [];
    if (!caseid) return items;
    return items.filter(item => item.caseId === caseid);
  }

}
