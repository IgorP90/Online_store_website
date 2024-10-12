import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-narrow-categories',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './narrow-categories.component.html',
  styleUrl: './narrow-categories.component.css'
})
export class NarrowCategoriesComponent implements OnInit {

  narrowCategories:any[] = []

  constructor(private categoryService:CategoryService){}

  ngOnInit(): void {
    this.categoryService.getAllNarrowCategories().subscribe(data=>{
      this.narrowCategories = data
    })

    this.narrowCategories.forEach(e => {
      console.debug(e)
    });
    
}

}
