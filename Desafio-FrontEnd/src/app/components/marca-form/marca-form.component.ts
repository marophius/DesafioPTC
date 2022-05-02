import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
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
  public marca!: Marca;
  public checked: boolean = false;
  constructor(
    private marcasService: MarcaService,
  ) { }

  ngOnInit(): void {
  }

  onSubmit(data: any) {
    this.marca.nome = data.value.nome;
    this.marca.status = data.value.status;
    this.marcasService.adicionarMarca(this.marca)
      .subscribe(result => {
        console.log(result);
      },
        error => {
          console.log(error);
        }
      )
  }

}
