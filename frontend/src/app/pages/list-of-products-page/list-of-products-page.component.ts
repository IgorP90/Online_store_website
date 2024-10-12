import { Component, OnInit } from '@angular/core';
import { NavigationComponent } from '../../components/navigation/navigation.component';
import { ActivatedRoute, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-list-of-products-page',
  standalone: true,
  imports: [CommonModule, NavigationComponent , RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './list-of-products-page.component.html',
  styleUrl: './list-of-products-page.component.css'
})
export class ListOfProductsPageComponent implements OnInit {
  
  constructor(private categoryService: CategoryService , private route:ActivatedRoute){}

  products:any[] = []

  ngOnInit():void{

    this.categoryService.getProductsByNarrowCategoryName(this.route.snapshot.params['name']).subscribe(data=>{
      this.products = data
    })

  }
}
