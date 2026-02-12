import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';


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

  cartItems: any[] = [];
  totalPrice: number = 0;

  message = '';
  error = '';

  constructor(private http: HttpClient, private router: Router) {}
  

  ngOnInit() {
    this.loadProducts();
    this.router.events
    .pipe(filter(event => event instanceof NavigationEnd))
    .subscribe(() => {
      this.loadProducts();
    });
  }

  loadProducts() {
    this.http.get<any[]>(`${this.baseUrl}/products`).subscribe({
      next: data => this.products = data,
      error: () => this.error = 'Failed to load products'
    });
  }

  updateCart(product: any, qty: string) {
    const quantity = Number(qty);

    this.cart = this.cart.filter(i => i.productId !== product.id);
    if (quantity > product.stock) {
  this.error = `Only ${product.stock} left for ${product.name}`;
  this.refreshCartView();
  return;
}

    if (quantity > 0) {
      this.cart.push({
        productId: product.id,
        quantity: quantity,
        name: product.name
      });
    }

    this.refreshCartView();
  }

  refreshCartView() {

  if (this.error) {
    this.message = '';
  }

  this.cartItems = this.cart.map(item => {
    const product = this.products.find(p => p.id === item.productId);
    return {
      ...item,
      price: product?.price || 0
    };
  });

  this.totalPrice = this.cartItems.reduce(
    (sum, item) => sum + item.price * item.quantity,
    0
  );
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
        this.message = 'Order placed successfully';
      } else {
        this.error = `Out of stock: ${failedItems.join(', ')}`;
      }

      this.cart = [];
      this.cartItems = [];
      this.totalPrice = 0;
      this.loadProducts();
    }
  }
  switchToAdmin() {
  const username = prompt('Enter admin username:');
  const password = prompt('Enter admin password:');
  if (!username || !password) return;

  this.http.post<any>(`${this.baseUrl}/auth/login`, { username, password })
    .subscribe({
      next: (res) => {
       
        localStorage.setItem('adminToken', res.token); 
        alert('Login successful');
        this.router.navigate(['/home/admin-dashboard']);
      },
      error: () => alert('Invalid credentials')
    });
}


}
