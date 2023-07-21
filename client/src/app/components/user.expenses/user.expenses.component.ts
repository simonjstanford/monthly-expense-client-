import { Component } from '@angular/core';
import { Expense, ExpenseMonth } from 'src/app/models/userExpenses';
import { ApiService } from 'src/app/services/api.service';
import { OauthServiceService } from 'src/app/services/oauth.service';
import { BaseComponent } from '../base/base.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-expenses',
  templateUrl: './user.expenses.component.html',
  styleUrls: ['./user.expenses.component.css']
})
export class UserExpensesComponent extends BaseComponent {
  constructor(oauthService: OauthServiceService, apiService: ApiService, formBuilder: FormBuilder) {
    super(oauthService, apiService, formBuilder);
  }

  public addExpense(data: Expense[]) {
    if (!data) {
      console.log("No list to add expense!");
      return;
    }

    data.push({
      name: "New Item",
      value: 0,
    });
  }
}
