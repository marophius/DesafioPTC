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

  public obterTodos(): Observable<HttpResponse<Proprietario[]>> {
    return this.http.get<HttpResponse<Proprietario[]>>(this.apiUrl + '/Proprietario');
  }

  public obterPorId(id: string): Observable<HttpResponse<Proprietario>> {
    return this.http.get<HttpResponse<Proprietario>>(this.apiUrl + '/Proprietario/' +id);
  }
}
