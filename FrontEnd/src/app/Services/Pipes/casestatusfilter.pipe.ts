import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'casestatusfilter'
})
export class CasestatusfilterPipe implements PipeTransform {

  transform(values: any[], ...args: any[]): any[] {
    return values.filter(a => a.status == "notvalid")
  }

}
