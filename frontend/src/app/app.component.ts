import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {NavigationComponent} from './components/navigation/navigation.component';
import { WideCategoryComponent } from './components/wide-category/wide-category.component';
import { ProductComponent } from './components/product/product.component';
import { NarrowCategoriesComponent } from './components/narrow-categories/narrow-categories.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet, 
    NavigationComponent, 
    WideCategoryComponent, 
    ProductComponent, 
    NarrowCategoriesComponent,],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
}
