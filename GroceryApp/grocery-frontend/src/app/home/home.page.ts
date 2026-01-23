import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class HomePage implements OnInit {

  baseUrl = 'http://localhost:5000';   

  products: any[] = [];
  cart: { productId: number; quantity: number; name: string }[] = [];

  message = '';
  error = '';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.http.get<any[]>(`${this.baseUrl}/products`).subscribe({
      next: data => this.products = data,
      error: () => this.error = 'Failed to load products'
    });
  }

  updateCart(product: any, qty: string) {
    const quantity = Number(qty);

    // Remove existing entry
    this.cart = this.cart.filter(i => i.productId !== product.id);

    if (quantity > 0) {
      this.cart.push({
        productId: product.id,
        quantity: quantity,
        name: product.name
      });
    }
  }

  placeOrder() {
    this.message = '';
    this.error = '';

    if (this.cart.length === 0) {
      this.error = 'Please select at least one product';
      return;
    }

    let failedItems: string[] = [];
    let completed = 0;

    this.cart.forEach(item => {

      const order = {
        productId: item.productId,
        quantity: item.quantity
      };

      this.http.post(`${this.baseUrl}/orders`, order).subscribe({
        next: () => {
          completed++;
          this.checkFinish(completed, failedItems);
        },
        error: () => {
          failedItems.push(item.name);
          completed++;
          this.checkFinish(completed, failedItems);
        }
      });

    });
  }

  checkFinish(completed: number, failedItems: string[]) {
    if (completed === this.cart.length) {

      if (failedItems.length === 0) {
        this.message = 'Order placed successfully ✅';
      } else {
        this.error = `Out of stock: ${failedItems.join(', ')}`;
      }

      this.cart = [];
      this.loadProducts();
    }
  }
}
