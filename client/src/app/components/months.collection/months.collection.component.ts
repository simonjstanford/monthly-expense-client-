import { Component } from '@angular/core';
import { BaseComponent } from '../base/base.component';
import { FormBuilder } from '@angular/forms';
import { ExpenseMonth } from 'src/app/models/userExpenses';
import { ApiService } from 'src/app/services/api.service';
import { OauthServiceService } from 'src/app/services/oauth.service';

@Component({
  selector: 'app-months-collection',
  templateUrl: './months.collection.component.html',
  styleUrls: ['./months.collection.component.css']
})
export class MonthsCollectionComponent extends BaseComponent {
  constructor(oauthService: OauthServiceService, apiService: ApiService, formBuilder: FormBuilder) {
    super(oauthService, apiService, formBuilder);
  }

  public addMonth() {
    if (!this.expenses) {
      console.log("No list to add month!");
      return;
    }

    const month: ExpenseMonth = this.createNewMonth();

    if (!this.expenses.months) {
      this.expenses.months = [month];
    } else {
      this.expenses.months.push(month);
    }
  }

  private createNewMonth(): ExpenseMonth {
    const currentMonth = new Date();
    const firstDay = new Date(Date.UTC(currentMonth.getFullYear(), currentMonth.getMonth(), 1));

    return {
      monthStart: firstDay,
      income: [],
      outgoings: []
    };
  }

  public removeMonth(month: ExpenseMonth) {
    if (!this.expenses) {
      console.log("No list to remove month!");
      return;
    }

    const index = this.expenses.months.indexOf(month, 0);
    if (index > -1) {
      this.expenses.months.splice(index, 1);
    }
  }
}
