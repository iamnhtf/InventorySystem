# 🧾 Inventory Management System – Backend API

A backend API for managing inventory, built with **ASP.NET Core**.
This project focuses on real-world inventory operations such as product management, stock tracking, and low-stock alerts.

---

## 🚀 Features

* 📦 Product Management (Create, Read)
* 🔄 Stock In / Stock Out tracking
* 📊 Inventory summary per product
* ⚠️ Reorder level warning (low stock detection)
* 🌐 RESTful API design
* 📘 Swagger API documentation
* 🗄️ Code-first database (Entity Framework Core)

---

## 🛠️ Tech Stack

* **ASP.NET Core (.NET 9)**
* **Entity Framework Core**
* **SQL Server**
* **Docker**
* **Swagger / OpenAPI**

---

## 📂 Project Structure

```
InventorySystem.API/
│── Controllers/
│── Data/
│── Dtos/
│── Entities/
│── Migrations/
│── Program.cs
```

---

## ⚙️ Getting Started

### 🔹 Run locally

```bash
dotnet restore
dotnet build
dotnet run
```

👉 Access Swagger:

```
http://localhost:8080/swagger
```

---

### 🔹 Run with Docker

```bash
docker build -t inventory-app .
docker run -p 8080:8080 inventory-app
```

---

## 🧪 API Example

### Create Product

```http
POST /api/products
```

```json
{
  "name": "Product A",
  "sku": "SP001",
  "unit": "pcs",
  "importPrice": 10,
  "sellPrice": 15,
  "reorderLevel": 5
}
```

---

## 📊 Sample Response

```json
{
  "id": "guid",
  "name": "Product A",
  "sku": "SP001",
  "quantityInStock": 0,
  "isLowStock": true
}
```

---

## 🎯 Learning Goals

* Practice building RESTful APIs
* Understand inventory domain logic
* Work with Entity Framework Core
* Containerize applications with Docker
* Prepare for cloud deployment (AWS)

---

## 🚀 Future Improvements

* Authentication & Authorization (JWT)
* Role-based access control
* Pagination & filtering
* CI/CD pipeline
* Deploy to AWS (EC2 / ECS)

---

## 👨‍💻 Author

Developed by **Thái Nguyễn**
