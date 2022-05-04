import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProprietarioFormComponent } from './proprietario-form.component';

describe('ProprietarioFormComponent', () => {
  let component: ProprietarioFormComponent;
  let fixture: ComponentFixture<ProprietarioFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProprietarioFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProprietarioFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
