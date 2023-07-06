import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UtilsService } from 'src/app/services/utils.service';

@Component({
  selector: 'app-datepicker',
  templateUrl: './datepicker.component.html',
  styleUrls: ['./datepicker.component.css']
})
export class DatepickerComponent {
  private _selectedDate: Date = new Date();

  constructor(private utils: UtilsService) {
  }

  @Input()
  set selectedDate(value: Date) {

    if (this.utils.isString(value)) {
      this._selectedDate = new Date(value as any);
    } else {
      this._selectedDate = value;
    }
    
    this.selectedDateChange.emit(value);
  }
  get selectedDate(): Date {
    return this._selectedDate;
  }
  
  @Output() selectedDateChange: EventEmitter<Date> = new EventEmitter<Date>();

  onDateSelected() {
    this.selectedDateChange.emit(this.selectedDate);
  }
}
