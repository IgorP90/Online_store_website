import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { ListOfProductsPageComponent } from './pages/list-of-products-page/list-of-products-page.component';
import { ProductPageComponent } from './pages/product-page/product-page.component';
import { NgModule } from '@angular/core';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';

export const routes: Routes = [
    {path: '', component: HomePageComponent},
    {path: 'products/:name', component: ListOfProductsPageComponent},
    {path: 'product/:id', component: ProductPageComponent},
    {path: 'admin', component: AdminPageComponent}
];