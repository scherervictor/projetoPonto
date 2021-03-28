import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { RegistrarPonto } from './models/RegistrarPonto';
import { Observable, throwError } from 'rxjs';
import { PontoColaborador } from './models/PontoColaborador';

@Injectable({
  providedIn: 'root'
})
export class PontoService {
  private listarUrl = 'api/ponto/listar';
  private registrarPontoUrl = 'api/ponto/registrar';
  httpOptions = {
    headers: new HttpHeaders({ 'Accept': ['application/json', 'text/plain', '*/*'], 'Content-Type': 'application/json' })
  };

  registrarPonto(ponto: RegistrarPonto): Observable<RegistrarPonto> {
    return this.http.post<RegistrarPonto>(this.registrarPontoUrl, ponto)
      .pipe(
        catchError(this.handleError)
      );
  };

  listarPontos() : Observable<PontoColaborador[]> {
    return this.http.get<PontoColaborador[]>(this.listarUrl)
      .pipe(
        catchError(this.handleError)
      );
  };

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('Erro ocorreu:', error.error.message);
    } else {
      console.error(
        `Backend retornou code ${error.status}, ` +
        `body foi: ${error.error}`);
    }
    return throwError(
      'Algo de errado aconteceu.');
  }
  
  constructor(
    private http: HttpClient
  ) { }

}
