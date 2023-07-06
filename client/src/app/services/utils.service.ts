import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilsService {

  constructor() { }

  isString(x: any) {
    return Object.prototype.toString.call(x) === "[object String]"
  }
}
