import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NarrowCategoriesComponent } from './narrow-categories.component';

describe('NarrowCategoriesComponent', () => {
  let component: NarrowCategoriesComponent;
  let fixture: ComponentFixture<NarrowCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NarrowCategoriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NarrowCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
