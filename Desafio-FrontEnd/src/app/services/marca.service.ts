import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Marca } from '../models/marca';
@Injectable({
  providedIn: 'root'
})
export class MarcaService {

  private readonly apiUrl = environment.host;

  get headersDefault() {
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "DELETE, POST, GET, PUT, OPTIONS",
      "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With",
    });
    return headers;
  }

  constructor(
    private http:HttpClient
    ) { }

    public obterMarcas(): Observable<Marca[]> {
      return this.http.get<Marca[]>(this.apiUrl + '/Marca', {headers: this.headersDefault, observe: 'body'});
    }

    public obterMarcasAtivas(): Observable<Marca[]> {
      return this.http.get<Marca[]>(this.apiUrl + '/Marca/somente-ativos');
    }

    public adicionarMarca(marca: Marca): Observable<HttpResponse<Marca>> {
      return this.http.post<HttpResponse<Marca>>(this.apiUrl + '/Marca', marca);
    }

    public alterarStatus(id: string, marca: Marca): Observable<HttpResponse<Marca>> {
      return this.http.put<HttpResponse<Marca>>(this.apiUrl + '/Marca/' + id, marca);
    }
}
