import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UtilsService } from 'src/app/services/utils.service';

interface Month {
  id: number;
  name: string;
}

@Component({
  selector: 'app-monthpicker',
  templateUrl: './monthpicker.component.html',
  styleUrls: ['./monthpicker.component.css']
})
export class MonthpickerComponent {
  private _selectedMonth: number = 0

  constructor(private utils: UtilsService) {
  }

  @Input()
  set selectedMonth(value: number) {

    if (this.utils.isString(value)) {
      this._selectedMonth = parseInt(value as any);
    } else {
      this._selectedMonth = value;
    }
    
    this._selectedMonth = value;
    this.selectedMonthChange.emit(+value); // Emit the converted value as number
  }
  get selectedMonth(): number {
    return this._selectedMonth;
  }
  
  @Output() selectedMonthChange: EventEmitter<number> = new EventEmitter<number>();

  months: Month[] = [
    { id: 1, name: 'January' },
    { id: 2, name: 'February' },
    { id: 3, name: 'March' },
    { id: 4, name: 'April' },
    { id: 5, name: 'May' },
    { id: 6, name: 'June' },
    { id: 7, name: 'July' },
    { id: 8, name: 'August' },
    { id: 9, name: 'September' },
    { id: 10, name: 'October' },
    { id: 11, name: 'November' },
    { id: 12, name: 'December' }
  ];

  onMonthSelected() {
    this.selectedMonthChange.emit(this.selectedMonth);
  }
}
