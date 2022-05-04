import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Proprietario } from '../models/proprietario';
@Injectable({
  providedIn: 'root'
})
export class ProprietarioService {

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
    private http: HttpClient
  ) { }

  public obterTodos(): Observable<Proprietario[]> {
    return this.http.get<Proprietario[]>(this.apiUrl + '/Proprietario');
  }

  public obterAtivos(): Observable<Proprietario[]> {
    return this.http.get<Proprietario[]>(this.apiUrl + '/Proprietario/somente-ativos', {headers: this.headersDefault});
  }

  public adicionarProprietario(proprietario: Proprietario): Observable<Proprietario> {
    return this.http.post<Proprietario>(this.apiUrl + '/Proprietario', proprietario);
  }

  public alterarStatus(id: string, proprietario: Proprietario): Observable<HttpResponse<Proprietario>> {
    return this.http.put<HttpResponse<Proprietario>>(this.apiUrl + '/Proprietario/alterar-status/' + id, proprietario);
  }

  public alterarProprietario(id: string, proprietario: Proprietario): Observable<HttpResponse<Proprietario>> {
    return this.http.put<HttpResponse<Proprietario>>(this.apiUrl + '/Proprietario/' + id, proprietario);
  }
}
