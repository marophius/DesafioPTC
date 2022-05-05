import { Component, OnInit } from '@angular/core';
import { Endereco } from 'src/app/models/endereco';
import { Nome } from 'src/app/models/nome';
import { Proprietario } from 'src/app/models/proprietario';
import { ProprietarioService } from 'src/app/services/proprietario.service';
import { MASKS } from 'ng-brazil';
import { EnderecoService } from 'src/app/services/endereco.service';
import { MdbModalRef } from 'mdb-angular-ui-kit/modal';

@Component({
  selector: 'app-proprietario-form',
  templateUrl: './proprietario-form.component.html',
  styleUrls: ['./proprietario-form.component.scss']
})
export class ProprietarioFormComponent implements OnInit {

  public MASKS = MASKS;
  public proprietario: Proprietario = new Proprietario('', new Nome(''), '', new Endereco('', '', '', '', '', ''), 0);

  constructor(
    private propService: ProprietarioService,
    private enderecoService: EnderecoService,
    public modalRef:MdbModalRef<ProprietarioFormComponent>
  ) 
  {
    console.log(this.proprietario);
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if(this.proprietario.id != '' && this.validarProprietario()) {
      this.alterarProprietario();
    }else {
      if(this.validarProprietario()) {
        this.adicionarProprietario();
      }
    }
    
  }

  onChange() {
    this.enderecoService.buscarEndereco(String(this.proprietario.endereco!.cep))
      .subscribe(
        result => {
          this.proprietario.endereco = result;
      },
        error => {
          console.log(error);
        }
      )
  }

  closeModal() {
    this.modalRef.close();
  }

  adicionarProprietario() {
    this.propService.adicionarProprietario(this.proprietario)
        .subscribe(
          result => {
            console.log(result);
            this.proprietario = new Proprietario('', new Nome(''), '', new Endereco('', '', '', '', '', ''), 0);
          },
          error => {
            console.log(error);
          }
        )
  }

  alterarProprietario() {
    this.propService.alterarProprietario(String(this.proprietario.id), this.proprietario)
        .subscribe(
          result => {
            console.log(result);
            this.closeModal();
          },
          error => {
            console.log(error);
          }
        );
  }

  validarProprietario() {
    if(this.proprietario.nome == '' && this.proprietario.email == '' && this.proprietario.endereco?.cep == '' && this.proprietario.documento?.toString() == '') {
      return false;
    }
    return true;
  }

}
