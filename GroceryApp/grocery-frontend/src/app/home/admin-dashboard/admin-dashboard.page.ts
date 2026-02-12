import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { NotificationService } from '../../services/notification.service';
import { AdminService } from '../../services/admin.service';
@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.page.html',
  standalone: true,
  imports: [CommonModule, FormsModule, IonicModule]
})
export class AdminDashboardPage implements OnInit {


  baseUrl = 'http://localhost:5000'; 

  totalRevenue: number = 0;
  topProducts: { name: string, quantitySold: number }[] = [];
  lowStockProducts: { name: string, stock: number }[] = [];
  loading: boolean = true;

  showCreateProduct = false;
  showStockManager = false;
  newProduct = { name: '', price: 0, stock: 0 };

  constructor(private http: HttpClient, private router: Router, private notificationService: NotificationService, private adminService: AdminService) {}

  ngOnInit() {
    this.loadDashboard();
    this.loadProducts();
  }
  loadProducts() {
  this.http.get<any[]>("http://localhost:5000/products")
    .subscribe(data => {
      this.products = data;
    });
}

  loadDashboard() {
    const token = localStorage.getItem('adminToken');
    if (!token) {
      alert('Please login as admin first!');
      this.router.navigate(['/home']);
      return;
    }

    const headers = new HttpHeaders({ Authorization: `Bearer ${token}` });

    this.http.get<any>(`${this.baseUrl}/api/admin/dashboard`, { headers })
      .subscribe({
        next: data => {
          this.totalRevenue = data.totalRevenue;
          this.topProducts = data.topSellingProducts;
          this.lowStockProducts = data.lowStockProducts;
          this.loading = false;
        },
        error: err => {
          console.error('Error loading dashboard:', err);
          alert('Failed to load dashboard. You may need to login again.');
          this.router.navigate(['/home']);
        }
      });
  }
  orders: any[] = [];
  products: any[] = [];


loadOrders() {
  this.adminService.getAllOrders()
    .subscribe(res => {
      this.orders = res as any[];
    });
}

ionViewWillEnter() {
  this.loadOrders();
}

  createProduct() {
    const token = localStorage.getItem('adminToken');
    if (!token) {
      alert('Admin not logged in!');
      return;
    }

    if (!this.newProduct.name || this.newProduct.price <= 0 || this.newProduct.stock < 0) {
      alert('Please fill in valid product details');
      return;
    }

    const headers = new HttpHeaders({ Authorization: `Bearer ${token}` });

    this.http.post(`${this.baseUrl}/products`, this.newProduct, { headers })
      .subscribe({
        next: () => {
          alert('Product created successfully');
          this.showCreateProduct = false;
          this.newProduct = { name: '', price: 0, stock: 0 };
          this.loadDashboard(); 
        },
        error: err => {
          console.error(err);
          alert('Failed to create product');
        }
      });
    }
    
    saveAllStocks() {
      const updates = this.products
      .filter(p => p.newStock !== undefined && p.newStock !== null)
      .map(p => {
        const stock = Number(p.newStock);

      if (!isNaN(stock) && stock >= 0) {
        return this.adminService.updateStock(p.id, stock).toPromise();
      }
      return null;
      });
      Promise.all(updates)
      .then(() => {
        alert("Stocks updated successfully!");
        this.products.forEach(p => {
        if (p.newStock !== undefined) {
          p.stock = p.newStock;
          p.newStock = undefined;
        }
      });

      this.showStockManager = false;
    })
    .catch(() => alert("Some updates failed"));
  }

    sendPromo() {
        this.notificationService
        .sendPromoNotification(
            'Special Offer!',
            'Get 20% off on all groceries today!'
        )
        .then(() => {
            alert('Promo notification sent (mock)');
        });
    }
    logout() {
        if(confirm('Are you sure you want to logout?')){
            localStorage.removeItem('adminToken');
            this.router.navigate(['/home']);
        }}
    }
