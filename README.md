# Simple Banking System

This is a simple banking system developed using .NET WinForms and C# programming language with Entity Framework for database operations. The backend database management system used for this project is SQL Server.

## Features:
- **Login System**: Employees can log in using their credentials.
- **Client Management**: Employees can search for clients, view client details, and manage client accounts.
- **Account Operations**: Employees can deposit or withdraw funds from client accounts, view transaction history, and add new accounts.

## Technologies Used:
- **Frontend**: .NET WinForms
- **Backend**: C# programming language
- **Database**: SQL Server

## Database:
- The database management system used is SQL Server.
- Utilized Entity Framework for seamless interaction with the database.
- SQL queries used in the project can be found in the `SQL Queries` folder, which contains stored procedures, functions, and triggers.

## Demo:
### Photos
|![login](https://github.com/Ali-Elchab/BankingSystem/assets/106644215/b273308a-3f02-42ef-b0fb-67137c962bf1)|![main](https://github.com/Ali-Elchab/BankingSystem/assets/106644215/1c4deba7-fa01-4db0-bfa0-3849fc3286d7)|
| ------------------------------------- | ------------------------------ | 
|![search](https://github.com/Ali-Elchab/BankingSystem/assets/106644215/69253c59-f298-4110-83c8-18290b68a78e)|![add](https://github.com/Ali-Elchab/BankingSystem/assets/106644215/e4dce7ae-f79b-4b4e-a354-3de886a2d339) |
|  ![details](https://github.com/Ali-Elchab/BankingSystem/assets/106644215/70c2a969-4964-4b1d-949c-23696b53c3f7) | ![history](https://github.com/Ali-Elchab/BankingSystem/assets/106644215/251e7bbf-0e2e-4d7f-bd98-a7aed2054392)|
![Uploading login.png…]()




![deposit](https://github.com/Ali-Elchab/BankingSystem/assets/106644215/f444a1a6-3fba-47d8-903c-136d35f7612d)
- **Video Demo**: [Add link to video demo here]



## Setup Instructions:
1. Clone this repository.
2. Open the project in Visual Studio.
3. Ensure you have SQL Server installed and configured.
4. Modify the database connection string in the project to match your SQL Server settings.
5. Run the Entity Framework migrations to set up the database schema:
   ```bash
   dotnet ef database update
