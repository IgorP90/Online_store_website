import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NarrowCategoryPageComponent } from './narrow-category-page.component';

describe('NarrowCategoryPageComponent', () => {
  let component: NarrowCategoryPageComponent;
  let fixture: ComponentFixture<NarrowCategoryPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NarrowCategoryPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NarrowCategoryPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
