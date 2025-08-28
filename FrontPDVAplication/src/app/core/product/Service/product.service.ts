import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../model/product.model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = `${environment.apiUrl}/Product`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}/getAll`);
  }

  getById(id: string): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/getById?id=${id}`);
  }

  create(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.apiUrl}/create`, product);
  }

  update(product: Product): Observable<Product> {
    return this.http.put<Product>(`${this.apiUrl}/update`, product);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/delete?id=${id}`);
  }
}
