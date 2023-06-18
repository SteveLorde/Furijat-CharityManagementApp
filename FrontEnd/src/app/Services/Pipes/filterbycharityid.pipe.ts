import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterbycharityid'
})
export class FilterbycharityidPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
