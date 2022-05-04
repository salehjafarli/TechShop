import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './Pages/category/category.component';
import { ProductComponent } from './Pages/product/product.component';

const routes: Routes = [
  //We dont have any homepage
  { path: '', component: ProductComponent },
  { path: 'products', component: ProductComponent },
  { path: 'categories', component: CategoryComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
