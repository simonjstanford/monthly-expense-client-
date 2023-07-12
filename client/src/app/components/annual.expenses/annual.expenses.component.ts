import { Component } from '@angular/core';
import { BaseComponent } from '../base/base.component';
import { OauthServiceService } from 'src/app/services/oauth.service';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-annual-expenses',
  templateUrl: './annual.expenses.component.html',
  styleUrls: ['./annual.expenses.component.css']
})
export class AnnualExpensesComponent extends BaseComponent {
  constructor(oauthService: OauthServiceService, apiService: ApiService) {
    super(oauthService, apiService);
  }
  
  public addAnnualExpense() {
    if (!this.expenses?.annualExpenses) {
      console.log("No list to add expense!");
      return;
    }

    const startDate = new Date();
    const endDate = startDate;
    endDate.setFullYear(startDate.getFullYear() + 10);

    this.expenses.annualExpenses.push({
      name: "New Annual Item",
      value: 0,
      month: 0,
      startDate: startDate,
      endDate: endDate,
    });
  }
}
