import { Pipe, PipeTransform } from '@angular/core';
import { Case } from '../../Models/Case';

@Pipe({
  name: 'filterbycharityid'
})
export class FilterbycharityidPipe implements PipeTransform {

  transform(items: Case[], charityId: number): any[] {
    if (!items) return [];
    if (!charityId) return items;
    return items.filter(item => item.charityId === charityId);
  }

}
