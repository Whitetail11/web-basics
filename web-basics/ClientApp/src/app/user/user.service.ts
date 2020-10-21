import { Injectable } from '@angular/core';
import { User } from '../model/User';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private httpClient: HttpClient) { }

  url: string = "api/user";

  get(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.url);
  }
  post(user: User): Observable<User> {
    return this.httpClient.post<User>(this.url, user);
  }
  delete(id: number): Observable<{}> {
    return this.httpClient.delete(`${this.url}/${id}`);
  }
  update(user: User): Observable<User> {
    return this.httpClient.put<User>(this.url, user);
  }
}
