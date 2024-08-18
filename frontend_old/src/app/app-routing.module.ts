import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { CartPageComponent } from './pages/cart-page/cart-page.component';
import { ItemComponent } from './components/item/item.component';
import { ProductPageComponent } from './pages/product-page/product-page.component';
import { CategoryPageComponent } from './pages/category-page/category-page.component';

const routes: Routes = [
  {path:'', component: HomePageComponent},
  {path:'admin', component: AdminPageComponent},
  {path:'cart', component: CartPageComponent},
  {path:'product/:id',component: ProductPageComponent},
  {path:'wide_category/:name',component:CategoryPageComponent},
  {path:'narrow_category/:name',component:CategoryPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
