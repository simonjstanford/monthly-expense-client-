import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CurrentMonthComponent } from './components/current.month/current.month.component';
import { UserExpensesComponent } from './components/user.expenses/user.expenses.component';
import { MonthpickerComponent } from './components/monthpicker/monthpicker.component';
import { DatepickerComponent } from './components/datepicker/datepicker.component';
import { AppRoutingModule } from './app-routing.module';
import { MonthlyExpensesComponent } from './components/monthly.expenses/monthly.expenses.component';
import { AnnualExpensesComponent } from './components/annual.expenses/annual.expenses.component';
import { NavComponent } from './components/nav/nav.component';

@NgModule({
  declarations: [
    AppComponent,
    CurrentMonthComponent,
    UserExpensesComponent,
    MonthpickerComponent,
    DatepickerComponent,
    MonthlyExpensesComponent,
    AnnualExpensesComponent,
    NavComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
