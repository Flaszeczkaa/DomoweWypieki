# Home Pastries (Domowe Wypieki) - Bakery Management System 🍰

A desktop application designed to manage orders, products, and clients for a local bakery. Built with **C# Windows Forms** and **ADO.NET** (disconnected architecture), backed by an **MS SQL Server** database. 

This project was developed as an academic assignment to demonstrate practical knowledge of ADO.NET, including `DataSet`, `SqlDataAdapter`, `DataRelation`, and `BindingSource`.

## 🚀 Features

* **Disconnected Data Architecture:** Heavy use of in-memory `DataSet` to minimize database connections, with bulk updates via `SqlDataAdapter.Update()`.
* **Master-Detail Views:** Seamlessly link Orders (Master) with Order Items (Detail) using `DataRelation` and `BindingSource`.
* **Catalog Management:** Full CRUD operations for static-priced cakes, custom cake sizes, and premium add-ons.
* **Historical Pricing (Snapshots):** The system stores product prices at the exact moment of purchase. Future catalog price changes do not affect archival orders.
* **Business Logic & Validation:**
  * Maximum order discount is capped at 20% (validated at the SQL constraint and UI level).
  * Orders cannot be marked as "Delivered" until fully paid (verified via C# business logic before database update).
  * Auto-calculated fields at the database level (`PERSISTED` columns).

## 🛠️ Tech Stack

* **Language:** C#
* **Framework:** .NET Framework (Windows Forms)
* **Data Access:** ADO.NET (SqlDataAdapter, DataSet, DataTable, BindingNavigator)
* **Database:** MS SQL Server (T-SQL)

## ⚙️ Setup & Installation

1. **Database Setup:** * Open MS SQL Server Management Studio (SSMS).
   * Run the provided SQL script located in the `SQL/` folder to create the `DomoweWypieki` database and its relational structure.
2. **Application Configuration:**
   * Open the `.sln` file in Visual Studio.
   * Locate the `ConnectionString` within the codebase (or `App.config`) and update the `Data Source` to match your local MS SQL Server instance name.
3. **Run:** Build and start the project. 

## 📖 User Guide

1. **Dictionaries First:** Navigate to the product catalogs (Cakes, Cake Sizes, Add-ons) to populate the bakery's offering. Always click the "Save" (Floppy disk) icon to push changes from the `DataSet` to the database.
2. **Client Registration:** Add a new client in the 'Clients' tab.
3. **Order Processing:** Go to the 'Orders' tab. Create an order header in the top grid. Select the newly created order and add items (cakes/torts) in the bottom grid. The system will auto-calculate totals.
4. **Payments:** Register a customer's payment in the 'Payments' tab. You cannot change an order's status to "Delivered" unless the registered payments meet or exceed the order's total value.
