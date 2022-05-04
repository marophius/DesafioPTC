import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Endereco } from '../models/endereco';

@Injectable({
  providedIn: 'root'
})
export class EnderecoService {

  private readonly apiUrl = "https://brasilapi.com.br/api/cep/v1/"
  constructor(
    private http: HttpClient
  ) { }

  buscarEndereco(cep: string): Observable<Endereco> {
    return this.http.get<Endereco>(this.apiUrl + cep);
  }
}
