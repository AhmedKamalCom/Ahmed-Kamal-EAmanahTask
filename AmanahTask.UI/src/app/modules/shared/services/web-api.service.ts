import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';


import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';



import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';
interface ResultViewModel {
  Success: boolean;
  Message: string;
  Data: any;
  IsAuthorized: boolean;
}

@Injectable()
export class WebApiService {

  plainText: string
  resources: any[] = [];
  constructor(
    private http: HttpClient,
    private _snackBar: MatSnackBar) {

  }
  private setHeaders(isFile: boolean = false, path: string = ''): HttpHeaders {
    const headersConfig = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      // 'Language': this.languageService.getLanguageOrDefault(),
      // 'AccessToken': String(this.localStorageService.get("accessToken") || '')
    };
    if (!isFile) headersConfig['Content-Type'] = 'application/json';
    else delete headersConfig['Content-Type'];
    return new HttpHeaders(headersConfig);
  }
  private logError(path: string, error: any) {

    // if (!environment.production)
    console.log(path, error)
    if (error.status === 505 || error.status === 506) {
      this._snackBar.open(" You not authorized" ,"", {
        duration: 3000, panelClass: (["snack-error"])
      });
     
    }
  }
 

  private log(path, res) {
    if (!environment.production) console.log(path, res);
  }
  get(path: string, params?: HttpParams): Observable<ResultViewModel> {
    return this.http.get<ResultViewModel>(`${environment.api_url}${path}`, { headers: this.setHeaders(false, path), params }).pipe(tap(res => this.log(path, res), error => this.logError(path, error)));
  }
  post(path: string, body: Object = {}): Observable<ResultViewModel> {
    return this.http.post<ResultViewModel>(`${environment.api_url}${path}`, body, { headers: this.setHeaders(false, path) }).pipe(tap(res => this.log(path, res), error => this.logError(path, error)));
  }
  put(path: string, body: Object = {}): Observable<ResultViewModel> {
    return this.http.put<ResultViewModel>(`${environment.api_url}${path}`, body, { headers: this.setHeaders(false, path) }).pipe(tap(res => this.log(path, res), error => this.logError(path, error)));
  }
  delete(path: string, params?: HttpParams): Observable<ResultViewModel> {
    return this.http.delete<ResultViewModel>(`${environment.api_url}${path}`, { headers: this.setHeaders(false, path), params }).pipe(tap(res => this.log(path, res), error => this.logError(path, error)));
  }
  // fileUpload(path: string, formData: FormData): Observable<any> {
  //   return this.http.request(new HttpRequest('POST', `${environment.api_url}${path}`, formData, { headers: this.setHeaders(true), reportProgress: true })).pipe(tap(res => this.log(path, res), error => this.logError(path, error)));
  // }

  postFile(path: string, formData: FormData): Observable<ResultViewModel> {
    return this.http.post<ResultViewModel>(`${environment.api_url}${path}`, formData, { headers: this.setHeaders(true, path) }).pipe(tap(res => this.log(path, res), error => this.logError(path, error)));

  }

}