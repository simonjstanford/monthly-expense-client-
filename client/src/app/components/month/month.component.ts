import { Component, Input } from '@angular/core';
import { Expense, ExpenseMonth } from 'src/app/models/userExpenses';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import { BaseComponent } from '../base/base.component';
import { OauthServiceService } from 'src/app/services/oauth.service';

@Component({
  selector: 'app-month',
  templateUrl: './month.component.html',
  styleUrls: ['./month.component.css']
})
export class MonthComponent extends BaseComponent {
  @Input() month!: ExpenseMonth
  @Input() index!: number

  constructor(oauthService: OauthServiceService, apiService: ApiService, formBuilder: FormBuilder) {
    super(oauthService, apiService, formBuilder);

    this.expenseForm = this.formBuilder.group({
      outgoings: new FormArray([]),
      income: new FormArray([])
    });
  }

  get outgoingsExpenseFormArray() { return this.formControls['outgoings'] as FormArray; }
  get outgoingsExpensesFormGroup() { return this.outgoingsExpenseFormArray.controls as FormGroup[]; }
  get incomeExpenseFormArray() { return this.formControls['income'] as FormArray; }
  get incomeExpensesFormGroup() { return this.incomeExpenseFormArray.controls as FormGroup[]; }

  override handleNewUserData(): void {
    if (this.month.outgoings) {
      this.month.outgoings.forEach((x) => {
        this.addToForm(x, this.outgoingsExpenseFormArray);
      });

      this.month.income.forEach((x) => {
        this.addToForm(x, this.incomeExpenseFormArray);
      });
    }
  }

  private addToForm(expense: Expense, formArray: FormArray) {
    const newGroup = this.formBuilder.group({
      name: [expense.name, Validators.required],
      value: [expense.value, [Validators.required, Validators.min(0)]],
    });
  
    formArray.push(newGroup);
  }

  public addOutgoingExpense() {
    const newExpense = {
      name: "New Outgoing Item",
      value: 0,
    };

    this.addToForm(newExpense, this.outgoingsExpenseFormArray);
  }


  public addIncome() {
    const newExpense = {
      name: "New Income Item",
      value: 0,
    };

    this.addToForm(newExpense, this.incomeExpenseFormArray);
  }

  public removeOutgoingFromForm(index: number) {
    if (!this.outgoingsExpenseFormArray) {
      console.log("No list to add expense!");
      return;
    }

    this.outgoingsExpenseFormArray.removeAt(index);
  }

  public removeIncomeFromForm(index: number) {
    if (!this.incomeExpenseFormArray) {
      console.log("No list to add expense!");
      return;
    }

    this.incomeExpenseFormArray.removeAt(index);
  }

  public onSubmit() {
    if (this.expenseForm.invalid) {
      console.log("Unable to save, invalid form");
      return;
    }

    if (this.month && this.expenses)
    {
      const newOutgoings = this.expenseForm.value['outgoings'];
      const newIncome = this.expenseForm.value['income'];
      this.expenses.months[this.index].outgoings = newOutgoings;
      this.expenses.months[this.index].income = newIncome;
      this.onSave();
    }
  }
}
