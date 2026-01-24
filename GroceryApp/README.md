# Grocery Ordering System

A simple full-stack grocery ordering application built using:

- Backend: ASP.NET Core Web API  
- Frontend: Angular + Ionic (basic UI)  
- Database: Entity Framework Core

The system allows users to view products, select quantities, place orders, and automatically handles stock validation.

---

## Project Structure

### Backend (ASP.NET Core)

GroceryApp
│
├── Controllers
│ ├── ProductsController.cs
│ └── OrdersController.cs
|
├── Data
│ └── AppDbContext.cs
│
├── Models
│ ├── CreateOrderDto.cs
│ ├── Product.cs
│ └── Order.cs
│
├── Repositories
│ ├── IOrderRepository.cs
│ ├── IProductRepository.cs
│ ├── OrderRepository.cs
│ └── ProductRepository.cs
│
├── Services
│ ├── IOrderService.cs
| ├── IProductService.cs
| ├── OrderService.cs
│ └── ProductService.cs
│
├── Program.cs 
└── Startup.cs

**Explanation:**

- Controllers → Handle HTTP requests and responses 
- Data → Database context and configuration
- Models → Database entities  
- Repositories → Handle database operations  
- Services → Contain business logic  

### Frontend (Angular / Ionic)

GroceryApp
├── src/app/home
  ├── home.page.ts
  └── home.page.html


- `home.page.ts` → API calls, cart logic, order handling  
- `home.page.html` → UI layout  


## API Explanation

### 1. Get All Products

**Endpoint:** 
GET /products

**Description:**  
Returns a list of all available products with their price and stock.

**Response Example:**
```json
[
  {
    "id": 1,
    "name": "Apple",
    "price": 50,
    "stock": 10
  }
]

### 2. Place Order

**Endpoint:** 
POST /orders
Request Body:

{
  "productId": 1,
  "quantity": 2
}
Description:

1. Validates stock
2. Calculates total price
3. Reduces stock
4. Saves order to database

Responses:
Success → Order created
Failure → Out of stock / invalid request

Where Business Logic is Handled?
All business logic is implemented in the Service layer, mainly in:
Services/OrderService.cs

This includes:
Checking if product exists
Validating stock availability
Calculating total price
Updating product stock
Saving order
Returning success or failure