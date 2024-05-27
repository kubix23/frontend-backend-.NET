import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../../user/model/User';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  getUser(login: string): Observable<User> {
    return this.http.get<User>(`/api/Users/${login}`);
  }

  patchUser(login: string, body: User): Observable<any> {
    return this.http.patch(`/api/Users/${login}`, body);
  }

  deleteUser(login: string): Observable<any> {
    return this.http.delete(`/api/Users/${login}`);
  }
}
