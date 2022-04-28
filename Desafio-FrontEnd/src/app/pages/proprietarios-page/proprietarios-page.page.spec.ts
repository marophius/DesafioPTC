import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProprietariosPagePage } from './proprietarios-page.page';

describe('ProprietariosPagePage', () => {
  let component: ProprietariosPagePage;
  let fixture: ComponentFixture<ProprietariosPagePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProprietariosPagePage ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProprietariosPagePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
