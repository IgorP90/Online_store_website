import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NavigationComponent } from './components/navigation/navigation.component';
import { CategoryComponent } from './components/category/category.component';
import { ItemComponent } from './components/item/item.component';
import { CartPageComponent } from './pages/cart-page/cart-page.component';
import { ProductPageComponent } from './pages/product-page/product-page.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { NarrowCategoryPageComponent } from './pages/narrow-category-page/narrow-category-page.component';
import { NarrowCategoriesComponent } from './components/narrow-categories/narrow-categories.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    AdminPageComponent,
    NavigationComponent,
    CategoryComponent,
    ItemComponent,
    CartPageComponent,
    ProductPageComponent,
    NarrowCategoryPageComponent,
    NarrowCategoriesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
