import { Component } from '@angular/core';
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
  user: User | null;
  expenses: UserExpenses | null;

  constructor(private oauthService: OauthServiceService, private apiService: ApiService) {
    this.user = null;
    this.expenses = null;
  }

  ngOnInit() {
    this.oauthService.currentUserSubject.subscribe((user) => {
      this.user = user;
      this.fetchUserData();
    });
  }

  fetchUserData() {
    if (!this.user) {
      return;
    }

    this.apiService.getUserData().subscribe((data) => {
      this.expenses = data;
    });
  }

  public onSave() {
    if (this.expenses) {
      this.apiService.saveUserData(this.expenses).subscribe((resp) => {
        console.log(resp);
      });
    } else {
      console.log("No expenses to save!");
    }
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
}
