import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserExpenses } from '../models/userExpenses';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { 
  }
  
  getUserData() {
    return this.http
      .get<UserExpenses>('/api/user/data')
      .pipe(map((val) =>{
        this.parseDateStrings(val);
        return val;
      }));
  }

  parseDateStrings(expenses: UserExpenses) {
    if (expenses && expenses.months) {
      expenses.months.forEach((month) => {
        month.monthStart = new Date(month.monthStart);
      });
    }

    if (expenses && expenses.annualExpenses) {
      expenses.annualExpenses.forEach((annualExpense) => {
        annualExpense.startDate = new Date(annualExpense.startDate);
        annualExpense.endDate = new Date(annualExpense.endDate);
      });
    }
  }

  saveUserData(data: UserExpenses) {
    return this.http.post('/api/user/data', data);
  }
}
