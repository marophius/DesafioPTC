import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MdbModalRef } from 'mdb-angular-ui-kit/modal';
import { Marca } from 'src/app/models/marca';
import { Nome } from 'src/app/models/nome';
import { MarcaService } from 'src/app/services/marca.service';

@Component({
  selector: 'app-marca-form',
  templateUrl: './marca-form.component.html',
  styleUrls: ['./marca-form.component.scss']
})
export class MarcaFormComponent implements OnInit {
  public marcaStatus = [
    {name: "Ativado", status: 0},
    {name: "Cancelado", status: 1}
  ]
  public marca: Marca = new Marca('', new Nome(''), 0 );
  public checked: boolean = false;
  constructor(
    private marcasService: MarcaService,
    public modalRef: MdbModalRef<MarcaFormComponent>
  ) { }

  ngOnInit(): void {
  }

  onSubmit() {
    this.marcasService.adicionarMarca(this.marca)
      .subscribe(result => {
        console.log(result);
      },
        error => {
          console.log(error);
        }
      )
  }

  closeModal() {
    this.modalRef.close();
  }

}
