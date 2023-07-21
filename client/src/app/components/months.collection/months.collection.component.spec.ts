import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthsCollectionComponent } from './months.collection.component';

describe('MonthsCollectionComponent', () => {
  let component: MonthsCollectionComponent;
  let fixture: ComponentFixture<MonthsCollectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonthsCollectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MonthsCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
