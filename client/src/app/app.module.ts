import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CurrentMonthComponent } from './components/current.month/current.month.component';
import { UserExpensesComponent } from './components/user.expenses/user.expenses.component';
import { DatepickerComponent } from './components/datepicker/datepicker.component';
import { AppRoutingModule } from './app-routing.module';
import { MonthlyExpensesComponent } from './components/monthly.expenses/monthly.expenses.component';
import { AnnualExpensesComponent } from './components/annual.expenses/annual.expenses.component';
import { NavComponent } from './components/nav/nav.component';
import { BaseComponent } from './components/base/base.component';
import { MonthsCollectionComponent } from './components/months.collection/months.collection.component';
import { MonthComponent } from './components/month/month.component';

@NgModule({
  declarations: [
    AppComponent,
    CurrentMonthComponent,
    UserExpensesComponent,
    DatepickerComponent,
    MonthlyExpensesComponent,
    AnnualExpensesComponent,
    NavComponent,
    BaseComponent,
    MonthsCollectionComponent,
    MonthComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
