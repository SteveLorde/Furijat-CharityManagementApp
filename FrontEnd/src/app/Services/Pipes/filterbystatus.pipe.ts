import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterbystatus'
})
export class FilterbystatusPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
