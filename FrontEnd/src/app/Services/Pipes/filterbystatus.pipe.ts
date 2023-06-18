import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterbystatus'
})
export class FilterbystatusPipe implements PipeTransform {

  transform(items: any[], status: string): any[] {
    if (!items) {
      return [];
    }
    if (!status) {
      return items;
    }
    return items.filter(item => item.status === status);
    }
  }
