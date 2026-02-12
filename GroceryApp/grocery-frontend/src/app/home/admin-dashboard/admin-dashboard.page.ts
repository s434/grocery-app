import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.page.html',
  standalone: true,
  imports: [CommonModule, FormsModule, IonicModule]
})
export class AdminDashboardPage implements OnInit {

  totalRevenue: number = 0;
  topProducts: { name: string, quantitySold: number }[] = [];
  lowStockProducts: { name: string, stock: number }[] = [];
  loading: boolean = true;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadDashboard();
  }

  loadDashboard() {
    this.http.get<any>('http://localhost:5000/api/admin/dashboard') 
      .subscribe({
        next: (data) => {
          this.totalRevenue = data.totalRevenue;
          this.topProducts = data.topSellingProducts;
          this.lowStockProducts = data.lowStockProducts;
          this.loading = false;
        },
        error: (err) => {
          console.error('Error loading dashboard:', err);
          this.loading = false;
        }
      });
  }
}
