import { Component, OnInit } from '@angular/core';
import { MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';
import { MarcaFormComponent } from 'src/app/components/marca-form/marca-form.component';
import { Marca } from 'src/app/models/marca';
import { MarcaService } from 'src/app/services/marca.service';

@Component({
  selector: 'app-marcas-page',
  templateUrl: './marcas-page.page.html',
  styleUrls: ['./marcas-page.page.scss']
})
export class MarcasPagePage implements OnInit {

  public modalRef!: MdbModalRef<MarcaFormComponent>;
  public marcas: Marca[] = [];
  public textButton!: string;

  constructor(
    private marcasService: MarcaService,
    private modalService: MdbModalService,
  ) { }

  ngOnInit(): void {

    this.obterMarcas();
  }

  public obterMarcas() {
    this.marcasService.obterMarcas()
      .subscribe(
        marcas => {
          this.marcas = marcas;
        },
        error => {
          console.log(error);
        }
      );
  }

  public alterarStatus(marca: Marca) {
    this.marcasService.alterarStatus(marca.id!, marca)
      .subscribe(
        result => {
          console.log(result);
          this.obterMarcas();
          // window.location.reload();
        },
        error => {
          console.log(error);
        }
      );
  }

  public abrirModalFormulario() {
    this.modalRef = this.modalService.open(MarcaFormComponent, {
      modalClass: 'modal-md',
    });
  }

}
