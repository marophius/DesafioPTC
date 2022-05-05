import { Component, OnInit } from '@angular/core';
import { Veiculo } from 'src/app/models/veiculo';
import { VeiculoService } from 'src/app/services/veiculo.service';

@Component({
  selector: 'app-veiculos-page',
  templateUrl: './veiculos-page.page.html',
  styleUrls: ['./veiculos-page.page.scss']
})
export class VeiculosPagePage implements OnInit {

  public veiculos: Veiculo[] = [];

  constructor(
    private veiculoService: VeiculoService
  ) { }

  ngOnInit(): void {
  }

  obterVeiculos() {

  }

}
