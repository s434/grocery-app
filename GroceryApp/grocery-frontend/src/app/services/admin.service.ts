import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private baseUrl = "http://localhost:5000"; 

  constructor(private http: HttpClient) {}

  getAllOrders() {
    const token = localStorage.getItem("adminToken");

    return this.http.get(`${this.baseUrl}/orders/all`, {
      headers: {
        Authorization: `Bearer ${token}`
      }
    });
  }
}
