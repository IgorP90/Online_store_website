import { Component } from '@angular/core';
import { NavigationComponent } from '../../components/navigation/navigation.component';
import { WideCategoryComponent } from '../../components/wide-category/wide-category.component';
import { ProductComponent } from '../../components/product/product.component';
import { NarrowCategoriesComponent } from '../../components/narrow-categories/narrow-categories.component';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [
    NavigationComponent, 
    WideCategoryComponent, 
    ProductComponent,
    NarrowCategoriesComponent ],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent {

}

