import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from 'src/app/models/user';
import { Expense, ExpenseMonth, UserExpenses } from 'src/app/models/userExpenses';
import { ApiService } from 'src/app/services/api.service';
import { OauthServiceService } from 'src/app/services/oauth.service';

@Component({
  selector: 'app-user-expenses',
  templateUrl: './user.expenses.component.html',
  styleUrls: ['./user.expenses.component.css']
})
export class UserExpensesComponent {
  currentUserSubject: Subscription | undefined;
  user: User | null;
  expenses: UserExpenses | null;

  saved: boolean;
  errorSaving: boolean;

  constructor(private oauthService: OauthServiceService, private apiService: ApiService) {
    this.user = null;
    this.expenses = null;
    this.saved = false;
    this.errorSaving = false;
  }

  ngOnInit() {
    this.currentUserSubject = this.oauthService.currentUserSubject.subscribe({
        next: (user) => {
          this.handleNewUser(user);
        }
      });
  }

  private handleNewUser(user: User | null) {
    if (user != this.user) {
      this.user = user;
      this.fetchUserData();
    }
  }

  ngOnDestroy() {
    this.currentUserSubject?.unsubscribe();
  }

  fetchUserData() {
    if (!this.user) {
      console.log("Can't fetch data as no user!");
      return;
    }

    this.apiService.getUserData().subscribe({
      next: (data) => this.expenses = data,
      error: (e) => this.expenses = {
        user: this.user?.userDetails ?? "",
        months: [],
        monthlyExpenses: [],
        annualExpenses: [],
      },
    });
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

  public addMonthlyExpense() {
    if (!this.expenses?.monthlyExpenses) {
      console.log("No list to add expense!");
      return;
    }

    const startDate = new Date();
    const endDate = startDate;
    endDate.setFullYear(startDate.getFullYear() + 10);

    this.expenses.monthlyExpenses.push({
      name: "New Monthly Item",
      value: 0,
      startDate: startDate,
      endDate: endDate,
    });
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

  private createNewMonth(): ExpenseMonth {
    const currentMonth = new Date();
    const firstDay = new Date(Date.UTC(currentMonth.getFullYear(), currentMonth.getMonth(), 1));

    return {
      monthStart: firstDay,
      income: [],
      outgoings: []
    };
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
