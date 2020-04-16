import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { Router } from '@angular/router';
import { LoginViewModel } from './authentication/_ViewModels/LoginViewModel';
import { RegisterViewModel } from './authentication/_ViewModels/RegisterViewModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.apiEndpoint + '/api/Auth/';
  public decodedToken: any;

  constructor(private httpClient: HttpClient, private router: Router) { }

  public Register(signUpViewModel: RegisterViewModel): Observable<any> {
    return this.httpClient.post<UserToken>(this.baseUrl + "register", signUpViewModel)
      .pipe(map(response => {
        if (response) {
          localStorage.setItem('token', 'Bearer ' + response.tokenString);
        }
      }));
  }

  helper = new JwtHelperService();

  login(loginViewModel: LoginViewModel) {
    debugger
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.httpClient.post<UserToken>(this.baseUrl + 'login', JSON.stringify(loginViewModel), httpOptions)
      .pipe(map(response => {
        if (response) {
          debugger
          localStorage.setItem('token', 'Bearer ' + response.tokenString);
        }
      }));
  }

  checkUserExistsByEmail(Email: string): Observable<boolean> {
    return this.httpClient.get<boolean>(this.baseUrl + "checkUserExistsByEmail/" + Email, { responseType: "json" });
  }

  getUserId(): number {
    return this.decodedToken.nameid;
  }

  getToken(): string {
    return localStorage.getItem('token');
  }

  loggedIn() {
    if (this.getToken()) {
      this.decodedToken = this.helper.decodeToken(this.getToken());
      const expirationDate = this.helper.getTokenExpirationDate(this.getToken());
      const isExpired = this.helper.isTokenExpired(this.getToken());
      return !isExpired;
    }

    return false;
  }


  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  public FormatDate(date: Date): string {
    var t = new Date(date);
    //t.setDate(t.getDate());
    //return t.toLocaleString();
    var formattedDate = t.getFullYear() + '-' + (t.getMonth() + 1) + '-' + t.getDate() + ' ' + t.getHours() + ":" + t.getMinutes();
    return formattedDate;

  }

  //public handleError(error: any) {
  //  const applicationError = error.headers.get('Application-Error');
  //  if (applicationError) {
  //    return ErrorObservable.create(applicationError);
  //  }

  //  return ErrorObservable.create('Server Error');
  //}
}


export interface UserToken {
  id: string;
  tokenString: string;
}
