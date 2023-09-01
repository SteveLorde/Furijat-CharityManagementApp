import { Pipe, PipeTransform } from '@angular/core';
//import { Creditor } from '../../Models/Creditor';

@Pipe({
  name: 'filterbycreditorsbycaseID'
})
export class FilterbycreditorsbycaseIDPipe implements PipeTransform {

  transform(items: any[], caseid: number): any[] {
    if (!items) return [];
    if (!caseid) return items;
    return items.filter(item => item.caseID === caseid);
  }

}
