import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'casestatusfilternotvalid'
})
export class CasestatusfilterPipe implements PipeTransform {

  transform(values: any[], ...args: any[]): any[] {
    return values.filter(a => a.status == "notvalid")
  }

}
