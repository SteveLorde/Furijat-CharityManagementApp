import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'casestatusvalidfilter'
})
export class CasestatusValidfilterPipe implements PipeTransform {

  transform(values: any[], ...args: any[]): any[] {
    return values.filter(a => a.status == "notvalid")
  }

}
