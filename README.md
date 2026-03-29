# 🍰 Home Bakery Management System

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![ADO.NET](https://img.shields.io/badge/ADO.NET-000000?style=for-the-badge&logo=microsoft&logoColor=white)

A comprehensive desktop application designed to manage a home-based bakery. This project demonstrates practical implementation of database concepts, focusing on the **disconnected data access architecture** using ADO.NET. 

This was developed as a final academic project for the "Programming in ADO.NET Technology" course by **Natalia Flaszka** and **Zuzanna Jonczyk**.

---

## 🚀 Technical Highlights

This project was built to showcase understanding of core database programming concepts:
* **Disconnected Architecture:** Data manipulation is performed in-memory using `DataSet` and `DataTable` objects. Changes are tracked and explicitly synchronized with the database, minimizing active connection time.
* **ACID Transactions:** The checkout and order finalization process uses `SqlTransaction` to ensure that order headers, line items, and payment details are saved atomically.
* **Soft Deletion:** Instead of physically deleting products, the system uses a "Withdraw from offer" feature to maintain historical integrity for past invoices.
* **Master-Detail Data Binding:** Orders and their specific items are linked and displayed dynamically using relational data structures.

---

## ✨ Key Features

### 1. Catalog & Customer Management
* **Product Catalog:** Add, edit, and manage bakery items. Products can be safely hidden from new orders without breaking past records.
* **Customer Base:** Store contact details with dynamic filtering (by name, surname, or email). Deletion is protected by foreign key constraints (only customers without order history can be removed).

### 2. Order Processing Workflow
* **Virtual Cart (In-Memory):** Build orders dynamically. The UI adapts based on the product category (e.g., showing topper options only for custom cakes). The cart exists purely in RAM until checkout.
* **Checkout & Payment:** Assign customers, set delivery dates, and apply discounts (up to 20% validation). Supports multiple payment methods (Cash, BLIK, etc.).
* **Order Review (Master-Detail):** Browse a summary table of all orders. Clicking an order instantly loads its specific line items in a detailed view.
* **Status Management:** Orders can be tracked and canceled. Cancellation is restricted by business logic (e.g., cannot cancel orders marked as "In Progress" or "Delivered").

---

## 🛠️ Getting Started

Follow these steps to run the application locally.

### Prerequisites
* Visual Studio (2019/2022 recommended)
* Microsoft SQL Server
* SQL Server Management Studio (SSMS)

### Installation & Setup

1.  **Database Setup:**
    * Open SSMS and connect to your local SQL Server instance.
    * Execute the provided `CreateDataBase.sql` script. This will generate the `DomoweWypieki` database along with all required tables, relationships, and constraints.
2.  **Configure Application:**
    * Clone this repository and open the project in Visual Studio.
    * Locate the database connection settings in the source code (usually in `App.config` or a dedicated connection class).
    * Update the `ConnectionString` to point to your local SQL instance (e.g., change `Data Source=.\SQLEXPRESS` to match your server).
3.  **Run:**
    * Build and run the solution (F5). 
    * *Note: Ensure you add at least one active product and one customer before attempting to create a new order.*
    
---

## 👥 Authors
* **Natalia Flaszka** - [GitHub Profile](https://github.com/Flaszeczkaa). 
* **Zuzanna Jonczyk** - [GitHub Profile](https://github.com/emilajonczyk7).
