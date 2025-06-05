# 📚 Book Library Management System

A simple Book Library Management System built with **ASP.NET MVC**, **Entity Framework Core (Code-First)**, and an **In-Memory Database**. It allows managing authors, books, and borrow/return transactions with business logic encapsulated in services.

---

## ✨ Features

- 🔍 List and filter books by availability, borrow date, and return date.
- ✅ Borrow and return books with proper validations.
- ✍️ Add, edit, and delete books and authors.
- 📦 Enum-based genre selection for books.
- 🔄 Dynamic status update using JavaScript in the Borrow Book UI.
- 📄 Pagination for better user experience and performance.

---

## 🔧 Technologies Used

- ASP.NET MVC (Latest)
- Entity Framework Core (In-Memory Database)
- C# (.NET 8)
- JavaScript (for dynamic UI)
- Bootstrap (for styling)

---

## 🧱 Architecture Overview:

📦 Presentation Layer (Views - Razor Pages)
   ↓
🎮 Controller Layer (ASP.NET MVC Controllers)
   ↓
⚙️ Service Layer (Business Logic Services)
   ↓
💾 Data Access Layer (EF Core with In-Memory DB)

## 🧰 Technology Stack

💻 Frontend:	HTML, CSS, Bootstrap, JavaScript

🧠 Backend:	ASP.NET MVC (Model-View-Controller)

🗂️ ORM:	Entity Framework Core

🧪 Database:	In-Memory Database (for testing/demo)

💬 Language:	C#

🏗️ Architecture:	N-Tier Architecture

🎯 Design Patterns:	Dependency Injection, DTOs

✅ Validation:	Data Annotations + Business Logic Layer

🧰 IDE:	Visual Studio 2022+

🔁 Version Control:	Git & GitHub


## 🚀 How to Run the Project

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/book-library-system.git
   cd book-library-system
