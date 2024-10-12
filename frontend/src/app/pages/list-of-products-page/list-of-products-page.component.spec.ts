import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOfProductsPageComponent } from './list-of-products-page.component';

describe('ListOfProductsPageComponent', () => {
  let component: ListOfProductsPageComponent;
  let fixture: ComponentFixture<ListOfProductsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListOfProductsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListOfProductsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
