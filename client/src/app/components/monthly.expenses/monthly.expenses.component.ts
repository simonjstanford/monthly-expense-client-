import { Component } from '@angular/core';
import { BaseComponent } from '../base/base.component';
import { OauthServiceService } from 'src/app/services/oauth.service';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-monthly-expenses',
  templateUrl: './monthly.expenses.component.html',
  styleUrls: ['./monthly.expenses.component.css']
})
export class MonthlyExpensesComponent extends BaseComponent {
  constructor(oauthService: OauthServiceService, apiService: ApiService) {
    super(oauthService, apiService);
  }

  public addMonthlyExpense() {
    if (!this.expenses?.monthlyExpenses) {
      console.log("No list to add expense!");
      return;
    }

    const startDate = new Date();
    const endDate = new Date();
    endDate.setFullYear(startDate.getFullYear() + 10);

    this.expenses.monthlyExpenses.push({
      name: "New Monthly Item",
      value: 0,
      startDate: startDate,
      endDate: endDate,
    });
  }
}
