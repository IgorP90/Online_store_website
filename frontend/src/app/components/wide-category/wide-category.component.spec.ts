import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WideCategoryComponent } from './wide-category.component';

describe('WideCategoryComponent', () => {
  let component: WideCategoryComponent;
  let fixture: ComponentFixture<WideCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WideCategoryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WideCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
