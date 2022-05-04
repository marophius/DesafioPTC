import { Component, OnInit } from '@angular/core';
import { MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';
import { ProprietarioFormComponent } from 'src/app/components/proprietario-form/proprietario-form.component';
import { Proprietario } from 'src/app/models/proprietario';
import { ProprietarioService } from 'src/app/services/proprietario.service';

@Component({
  selector: 'app-proprietarios-page',
  templateUrl: './proprietarios-page.page.html',
  styleUrls: ['./proprietarios-page.page.scss']
})
export class ProprietariosPagePage implements OnInit {

  public proprietarios: Proprietario[] = [];

  public modalRef!: MdbModalRef<ProprietarioFormComponent>;

  constructor(
    private modalService: MdbModalService,
    private proprietarioService: ProprietarioService,
  ) { }

  ngOnInit(): void {

    this.carregarProprietarios();
  }



  alterarStatus(proprietario: Proprietario) {
    this.proprietarioService.alterarStatus(String(proprietario.id), proprietario)
      .subscribe(
        result => {
        console.log(result);
        this.carregarProprietarios();
      },
        error => {
          console.log(error)
        }
      )
  }

  abrirModalFormulario() {
    this.modalRef = this.modalService.open(ProprietarioFormComponent, {
      modalClass: 'modal-md',
    });

    this.modalRef.onClose.subscribe(
      (message: any) => {
      this.carregarProprietarios();
    },
      error => {
        console.log(error)
      }
    )
  }

  abrirModalFormularioData(proprietario: Proprietario) {
    this.modalRef = this.modalService.open(ProprietarioFormComponent, {
      modalClass: 'modal-xl',
      data: {
        proprietario: proprietario
      }
    });

    this.modalRef.onClose.subscribe(
      (event: any) => {
      this.carregarProprietarios();
    },
      error => {
        console.log(error);
      }
    );
  }

  carregarProprietarios() {
    this.proprietarioService.obterTodos()
      .subscribe(
        result => {
        this.proprietarios = result;
      },
        error => {
          console.log(error);
        }
      )
  }

}
