import { Component, Input, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-wide-category',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './wide-category.component.html',
  styleUrl: './wide-category.component.css'
})
export class WideCategoryComponent implements OnInit {

  // category:any[] = []

  // constructor(private categoryService:CategoryService){}

  @Input() wideCategory:any

  ngOnInit(): void {
    // this.categoryService.getAllWideCategories().subscribe(data=>{
    //   this. wideCategories = data
    // })

    // this. wideCategories.forEach(e => {
    //   console.debug(e)
    // });
    
}
}
