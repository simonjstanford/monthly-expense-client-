import { Component } from '@angular/core';
import { BaseComponent } from '../base/base.component';
import { OauthServiceService } from 'src/app/services/oauth.service';
import { ApiService } from 'src/app/services/api.service';
import { FormBuilder, Validators } from '@angular/forms';
import { MonthlyExpense, UserExpenses } from 'src/app/models/userExpenses';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-monthly-expenses',
  templateUrl: './monthly.expenses.component.html',
  styleUrls: ['./monthly.expenses.component.css']
})
export class MonthlyExpensesComponent extends BaseComponent {
  constructor(oauthService: OauthServiceService, apiService: ApiService, formBuilder: FormBuilder) {
    super(oauthService, apiService, formBuilder);
  }

  public addMonthlyExpense() {
    if (!this.expenseFormArray) {
      console.log("No list to add expense!");
      return;
    }

    const startDate = new Date();
    const endDate = new Date();
    endDate.setFullYear(startDate.getFullYear() + 10);

    const newExpense = {
      name: "New Monthly Item",
      value: 0,
      startDate: startDate,
      endDate: endDate,
    };

    this.addToForm(newExpense);
  }

  override handleNewUserData(data: UserExpenses): void {
    if (data && data.monthlyExpenses) {
      data.monthlyExpenses.forEach((x) => {
        this.addToForm(x);
      });
    }
  }

  private addToForm(expense: MonthlyExpense) {
    const newGroup = this.formBuilder.group({
      name: [expense.name, Validators.required],
      value: [expense.value, [Validators.required, Validators.min(0)]],
      startDate: [formatDate(expense.startDate, 'yyyy-MM-dd', 'en'), Validators.required],
      endDate: [formatDate(expense.endDate, 'yyyy-MM-dd', 'en'), Validators.required],
    });
  
    this.expenseFormArray.push(newGroup);
  }

  public onSubmit() {
    if (this.expenseForm.invalid) {
      console.log("Unable to save, invalid form");
      return;
    }

    if (this.expenses)
    {
      const values = this.expenseForm.value['expense'];
      this.expenses.monthlyExpenses = values;
      this.onSave();
    }
  }
}
