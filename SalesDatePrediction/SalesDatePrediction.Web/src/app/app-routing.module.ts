import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers.component';
import { NewOrderComponent } from './new-order/new-order.component';

const routes: Routes = [
  { path: 'new-order/:customerId/:customerName', component: NewOrderComponent },
  { path: '', component: CustomersComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
