import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../model/Category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>('/api/Categories');
  }

  getSubcategories(id: number): Observable<Category[]> {
    return this.http.get<Category[]>(`/api/Categories/${id}/subcategories`);
  }

  putCategory(id: number, body: Category): Observable<any> {
    return this.http.put(`/api/Categories/${id}`, body);
  }
}
