import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private baseUrl = "http://localhost:5000"; 
  private getAuthHeaders() {
  const token = localStorage.getItem("adminToken");
  return { Authorization: `Bearer ${token}` };
}


  constructor(private http: HttpClient) {}

  getAllOrders() {
  return this.http.get(`${this.baseUrl}/orders/all`, {
    headers: this.getAuthHeaders()
  });
}

updateStock(productId: number, stock: number) {
  return this.http.put(
    `${this.baseUrl}/products/stock`,
    { productId,stock },
    { headers: this.getAuthHeaders() }
  );
}
}
