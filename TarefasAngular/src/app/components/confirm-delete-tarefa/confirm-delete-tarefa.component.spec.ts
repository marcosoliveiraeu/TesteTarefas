import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmDeleteTarefaComponent } from './confirm-delete-tarefa.component';

describe('ConfirmDeleteTarefaComponent', () => {
  let component: ConfirmDeleteTarefaComponent;
  let fixture: ComponentFixture<ConfirmDeleteTarefaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfirmDeleteTarefaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfirmDeleteTarefaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
