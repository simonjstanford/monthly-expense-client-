import { Component } from '@angular/core';
import { User } from 'src/app/models/user';
import { UserExpenses } from 'src/app/models/userExpenses';
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
    this.oauthService.getUser().subscribe((user) => {
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
}
