import { Component, OnInit } from '@angular/core';
import { MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';
import { VeiculoFormComponent } from 'src/app/components/veiculo-form/veiculo-form.component';
import { Veiculo } from 'src/app/models/veiculo';
import { VeiculoService } from 'src/app/services/veiculo.service';

@Component({
  selector: 'app-veiculos-page',
  templateUrl: './veiculos-page.page.html',
  styleUrls: ['./veiculos-page.page.scss']
})
export class VeiculosPagePage implements OnInit {

  public veiculos: Veiculo[] = [];
  public modalRef!: MdbModalRef<VeiculoFormComponent>;

  constructor(
    private veiculoService: VeiculoService,
    public modalService: MdbModalService,
  ) { }

  ngOnInit(): void {
  }

  obterVeiculos() {
    this.veiculoService.obterVeiculos()
      .subscribe(
        result => {
        this.veiculos = result;
      },
        error => {
          console.log(error);
        }
    )
  }

  alterarStatus(veiculo: Veiculo) {

  }

  abrirModalFormularioData(veiculo: Veiculo) {

  }

  abrirModalFormulario() {
    this.modalRef = this.modalService.open(VeiculoFormComponent, {
      modalClass: 'modal-md'
    });
    this.modalRef.onClose.subscribe(
      (event: any) => {
        this.obterVeiculos();
      },
      error => {
        console.log(error);
      }
      );
  }

}
