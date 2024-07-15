import { Pipe, PipeTransform ,Injectable } from '@angular/core';

@Pipe({
  name: 'dateFormat'
})
@Injectable({
  providedIn: 'root'
})
export class DateFormatPipe implements PipeTransform {

  transform(value: string | null | undefined): string {

    if (!value) {
      return '';
    }

    const date = new Date(value);
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();
    return `${day}/${month}/${year}`;
  }

}
