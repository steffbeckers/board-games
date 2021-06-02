import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ThousandBombsAndGrenadesComponent } from './thousand-bombs-and-grenades.component';

describe('ThousandBombsAndGrenadesComponent', () => {
  let component: ThousandBombsAndGrenadesComponent;
  let fixture: ComponentFixture<ThousandBombsAndGrenadesComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ThousandBombsAndGrenadesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThousandBombsAndGrenadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
