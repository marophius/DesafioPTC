import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Veiculo } from '../models/veiculo';

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {

  get headersDefault() {
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "DELETE, POST, GET, PUT, OPTIONS",
      "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With",
    });
    return headers;
  }

  private readonly apiUrl = environment.host;

  constructor(
    private http: HttpClient
  ) { }

  obterVeiculos(): Observable<Veiculo[]> {
    return this.http.get<Veiculo[]>(this.apiUrl + '/Veiculo', {headers: this.headersDefault});
  }

  obterPorId(id: string): Observable<Veiculo> {
    return this.http.get<Veiculo>(this.apiUrl + '/Veiculo/' + id, {headers: this.headersDefault});
  }

  obterPorRenavam(renavam: number): Observable<Veiculo> {
    return this.http.get<Veiculo>(this.apiUrl + '/Veiculo/'+ renavam, {headers: this.headersDefault});
  }

  adicionarVeiculo(veiculo: Veiculo): Observable<Veiculo> {
    return this.http.post<Veiculo>(this.apiUrl + '/Veiculo', veiculo);
  }

  alterarVeiculo(id: string, veiculo: Veiculo): Observable<Veiculo> {
    return this.http.put<Veiculo>(this.apiUrl + '/Veiculo/' + id, veiculo);
  }

  alterarStatus(id: string, veiculo: Veiculo, status: number): Observable<Veiculo> {
    return this.http.put<Veiculo>(this.apiUrl + '/Veiculo/' + id + '/' + status, veiculo);
  }
}
