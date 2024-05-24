import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../model/Contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  constructor(private http: HttpClient) { }

  getContact(id: number): Observable<Contact> {
    return this.http.get<Contact>(`/api/Contacts/${id}`);
  }

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>('/api/Contacts');
  }

  putContact(id: number, body: Contact): Observable<any> {
    return this.http.put(`/api/Contacts/${id}`, body);
  }

  deleteContact(id: number): Observable<any> {
    return this.http.delete(`/api/Contacts/${id}`);
  }
}
