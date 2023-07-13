import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from 'src/app/models/user';
import { Expense, UserExpenses } from 'src/app/models/userExpenses';
import { ApiService } from 'src/app/services/api.service';
import { OauthServiceService } from 'src/app/services/oauth.service';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-base',
  template: `
    <p>
      base works!
    </p>
  `,
  styles: [
  ]
})
export class BaseComponent {
  private currentUserSubject: Subscription | undefined;
  
  public expenseForm: FormGroup;
  public user: User | null;
  public expenses: UserExpenses | null;
  public saved: boolean;
  public errorSaving: boolean;

  constructor(protected oauthService: OauthServiceService, protected apiService: ApiService, protected formBuilder: FormBuilder) {
    this.user = null;
    this.expenses = null;
    this.saved = false;
    this.errorSaving = false;

    this.expenseForm = this.formBuilder.group({
      expense: new FormArray([])
    });
  }

  get formControls() { return this.expenseForm.controls; }
  get expenseFormArray() { return this.formControls['expense'] as FormArray; }
  get expensesFormGroup() { return this.expenseFormArray.controls as FormGroup[]; }

  ngOnInit() {
    this.currentUserSubject = this.oauthService.currentUserSubject.subscribe({
        next: (user) => this.handleNewUser(user)
      });
  }

  private handleNewUser(user: User | null) {
    if (user != this.user) {
      this.user = user;
      this.fetchUserData();
    }
  }

  fetchUserData() {
    if (!this.user) {
      console.log("Can't fetch data as no user!");
      return;
    }

    this.apiService.getUserData().subscribe({
      next: (data) => {
        this.expenses = data;
        this.handleNewUserData(data)
      },
      error: (e) => this.expenses = {
        user: this.user?.userDetails ?? "",
        months: [],
        monthlyExpenses: [],
        annualExpenses: [],
      },
    });
  }

  protected handleNewUserData(data: UserExpenses): void {
    //overridden in sub classes
  }

  ngOnDestroy() {
    this.currentUserSubject?.unsubscribe();
  }

  public onSave() {
    if (!this.expenses) {
      console.log("No expenses to save!");
      return;
    }

    this.apiService.saveUserData(this.expenses).subscribe({
      next: (resp) => this.saved = true,
      error: (e) => this.errorSaving = true,
    });
  }

  public removeExpense(data: Expense[], item: Expense) {
    if (!data) {
      console.log("No list to add expense!");
      return;
    }

    const index = data.indexOf(item, 0);
    if (index > -1) {
      data.splice(index, 1);
    }
  }
}
