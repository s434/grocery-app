import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({ providedIn: 'root' })
export class ApiService {
private baseUrl = 'http://localhost:5000';


constructor(private http: HttpClient) {}


getProducts() {
return this.http.get<any[]>(`${this.baseUrl}/products`);
}


placeOrder(productId: number, quantity: number) {
return this.http.post(`${this.baseUrl}/orders`, { productId, quantity });
}
}