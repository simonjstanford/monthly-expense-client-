import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MonthlyExpensesComponent } from './components/monthly.expenses/monthly.expenses.component';
import { AnnualExpensesComponent } from './components/annual.expenses/annual.expenses.component';
import { UserExpensesComponent } from './components/user.expenses/user.expenses.component';

const routes: Routes = [
  { path: '', component: UserExpensesComponent },
  { path: 'monthly', component: MonthlyExpensesComponent },
  { path: 'annual', component: AnnualExpensesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }