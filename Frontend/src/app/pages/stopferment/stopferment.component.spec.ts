import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StopfermentComponent } from './stopferment.component';

describe('StopfermentComponent', () => {
  let component: StopfermentComponent;
  let fixture: ComponentFixture<StopfermentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StopfermentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StopfermentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
