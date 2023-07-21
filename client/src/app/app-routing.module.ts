import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MonthlyExpensesComponent } from './components/monthly.expenses/monthly.expenses.component';
import { AnnualExpensesComponent } from './components/annual.expenses/annual.expenses.component';
import { MonthsCollectionComponent } from './components/months.collection/months.collection.component';

const routes: Routes = [
  { path: '', component: MonthsCollectionComponent },
  { path: 'monthly', component: MonthlyExpensesComponent },
  { path: 'annual', component: AnnualExpensesComponent },

  // Wildcard route for handling unknown routes
  { path: '**', redirectTo: '' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }