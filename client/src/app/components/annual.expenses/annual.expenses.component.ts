import { Component } from '@angular/core';
import { BaseComponent } from '../base/base.component';
import { OauthServiceService } from 'src/app/services/oauth.service';
import { ApiService } from 'src/app/services/api.service';
import { FormBuilder, Validators } from '@angular/forms';
import { AnnualExpense, UserExpenses } from 'src/app/models/userExpenses';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-annual-expenses',
  templateUrl: './annual.expenses.component.html',
  styleUrls: ['./annual.expenses.component.css']
})
export class AnnualExpensesComponent extends BaseComponent {
  constructor(oauthService: OauthServiceService, apiService: ApiService, formBuilder: FormBuilder) {
    super(oauthService, apiService, formBuilder);
  }
  
  public addAnnualExpense() {
    if (!this.expenses?.annualExpenses) {
      console.log("No list to add expense!");
      return;
    }

    const startDate = new Date();
    const endDate = new Date();
    endDate.setFullYear(startDate.getFullYear() + 10);

    const newExpense = {
      name: "New Annual Item",
      value: 0,
      month: 0,
      startDate: startDate,
      endDate: endDate,
    };

    this.addToForm(newExpense);
  }

  override handleNewUserData(data: UserExpenses): void {
    if (data && data.monthlyExpenses) {
      data.annualExpenses.forEach((x) => {
        this.addToForm(x);
      });
    }
  }

  private addToForm(expense: AnnualExpense) {
    const newGroup = this.formBuilder.group({
      name: [expense.name, Validators.required],
      value: [expense.value, [Validators.required, Validators.min(0)]],
      month: [expense.month, [Validators.required]],
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
      this.expenses.annualExpenses = values;
      this.onSave();
    }
  }
}
