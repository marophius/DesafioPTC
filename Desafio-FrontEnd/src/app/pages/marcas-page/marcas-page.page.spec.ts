import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarcasPagePage } from './marcas-page.page';

describe('MarcasPagePage', () => {
  let component: MarcasPagePage;
  let fixture: ComponentFixture<MarcasPagePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarcasPagePage ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarcasPagePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
