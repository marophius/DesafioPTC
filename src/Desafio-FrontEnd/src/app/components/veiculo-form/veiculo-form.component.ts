import { Component, OnInit } from '@angular/core';
import { MdbModalRef } from 'mdb-angular-ui-kit/modal';
import { Veiculo } from 'src/app/models/veiculo';
import { MASKS } from 'ng-brazil';
@Component({
  selector: 'app-veiculo-form',
  templateUrl: './veiculo-form.component.html',
  styleUrls: ['./veiculo-form.component.scss']
})
export class VeiculoFormComponent implements OnInit {

  public MASKS = MASKS;
  public veiculo: Veiculo = new Veiculo();

  constructor(
    public modalRef: MdbModalRef<VeiculoFormComponent>
  ) { 
    
  }

  ngOnInit(): void {
  }

  closeModal() {
    this.modalRef.close();
  }

  onSubmit() {

  }

}
