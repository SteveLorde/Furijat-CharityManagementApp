import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterbydonatorid'
})
export class FilterbydonatoridPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
