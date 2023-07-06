import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UserComponent } from './components/user/user.component';
import { CurrentMonthComponent } from './components/current.month/current.month.component';
import { UserExpensesComponent } from './components/user.expenses/user.expenses.component';
import { MonthpickerComponent } from './components/monthpicker/monthpicker.component';
import { DatepickerComponent } from './components/datepicker/datepicker.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    CurrentMonthComponent,
    UserExpensesComponent,
    MonthpickerComponent,
    DatepickerComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
