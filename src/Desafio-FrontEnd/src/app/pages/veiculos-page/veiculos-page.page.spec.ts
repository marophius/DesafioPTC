import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VeiculosPagePage } from './veiculos-page.page';

describe('VeiculosPagePage', () => {
  let component: VeiculosPagePage;
  let fixture: ComponentFixture<VeiculosPagePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VeiculosPagePage ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VeiculosPagePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
