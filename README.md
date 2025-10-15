🎓 StudentSync

StudentSync is a C#/.NET project I built to manage and organize student information efficiently using a clean, layered architecture.
It’s designed as a foundation for a student management system that can handle CRUD operations, reporting, and database integration — while keeping the structure maintainable and scalable.

🧠 Overview

StudentSync follows a layered architecture approach:

PresentationLayer – Handles the user interface and main program flow.

DataLayer – Manages data access, storage, and models for student records.

This separation of concerns keeps the code clean, modular, and easy to expand as more features are added.

⚙️ Features

✅ Full .NET project setup with proper solution structure (StudentSync.sln, .csproj, Program.cs)
✅ Organized Presentation and Data layers for scalability
✅ Seed dataset with preloaded student info for development and testing
✅ App.config setup for environment and runtime configuration
✅ Includes branding assets (like Logo.png) for a professional touch
✅ Structured for easy expansion into CRUD operations, reporting, and database connectivity

🚀 Technologies Used

C# / .NET Framework

Object-Oriented Programming (OOP) principles

Layered architecture (Presentation + Data layers)

App.config for configuration management

📂 Project Structure
StudentSync/
│
├── DataLayer/
│   ├── Models/
│   ├── DataAccess/
│   └── StudentData.cs
│
├── PresentationLayer/
│   ├── UI/
│   └── Program.cs
│
├── Assets/
│   └── Logo.png
│
├── App.config
├── StudentSync.sln
└── README.md
