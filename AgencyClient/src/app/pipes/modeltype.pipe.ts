import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'modeltype'
})
export class ModelTypePipe implements PipeTransform {

  transform(value: string): string {
    return value.split('\n')[0].replace("-","");
  }

}
