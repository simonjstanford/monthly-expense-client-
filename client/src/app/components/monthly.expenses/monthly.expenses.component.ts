import { Component } from '@angular/core';
import { BaseComponent } from '../base/base.component';
import { OauthServiceService } from 'src/app/services/oauth.service';
import { ApiService } from 'src/app/services/api.service';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MonthlyExpense, UserExpenses } from 'src/app/models/userExpenses';

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

  override handleNewUserData(data: UserExpenses): void {
    if (data && data.monthlyExpenses) {
      data.monthlyExpenses.forEach((x) => {
        this.addToForm(x);
      });
    }
  }

  private addToForm(x: MonthlyExpense) {
    const newGroup = this.formBuilder.group({
      name: [x.name, Validators.required],
      value: [x.value, [Validators.required, Validators.min(0)]],
      startDate: [x.startDate, Validators.required],
      endDate: [x.startDate, Validators.required],
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
