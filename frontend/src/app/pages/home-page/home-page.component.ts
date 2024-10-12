import { Component, OnInit } from '@angular/core';
import { NavigationComponent } from '../../components/navigation/navigation.component';
import { WideCategoryComponent } from '../../components/wide-category/wide-category.component';
import { ProductComponent } from '../../components/product/product.component';
import { NarrowCategoriesComponent } from '../../components/narrow-categories/narrow-categories.component';
import { CategoryService } from '../../services/category.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [
    CommonModule, 
    NavigationComponent, 
    WideCategoryComponent, 
    ProductComponent,
    NarrowCategoriesComponent ],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent implements OnInit {

  wideCategories:any[] = []

  constructor(private categoryService:CategoryService){}

  ngOnInit(): void {
    this.categoryService.getAllWideCategories().subscribe(data=>{
      this. wideCategories = data
    })

  }

  event:string = ''
} 
