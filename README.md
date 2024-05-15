# Overview

This project aims to provide a comprehensive guide to building a modern dating application. It covers various aspects, including setting up the backend and frontend, implementing features like photo upload, private messaging, filtering, sorting, and more.

## Features

- Drag and drop photo upload with cloud platform integration.
- Private messaging system for user communication.
- Data filtering, sorting, and paging for improved user experience.
- Notification system implemented in Angular.
- JWT Authentication for user authentication.
- Error handling in both the API and the SPA.
- Data persistence using Entity Framework Core.
- Real-time notifications and presence management using SignalR.

## Getting Started

1. Clone the repository to your local machine.
2. Navigate to the backend folder and run `dotnet run` to start the ASP.NET Core WebAPI server.
3. Navigate to the frontend folder and run `ng serve` to start the Angular development server.
4. Open your browser and go to `http://localhost:5000` to access the application.

## Usage

To use this project, follow the instructions provided in each section of the codebase. Start by setting up the backend using ASP.NET Core WebAPI and then proceed to build the frontend using Angular. Each feature is implemented incrementally, allowing for easy understanding and customization.

### Viewing SQLite Database Tables in Visual Studio Code

#### Prerequisites
- [Visual Studio Code](https://code.visualstudio.com/)
- [SQLite extension](https://marketplace.visualstudio.com/items?itemName=alexcvzz.vscode-sqlite) installed in VS Code

#### Instructions
1. Open the project folder in Visual Studio Code.
2. Ensure that your SQLite database file (with the `.sqlite` or `.db` extension) is located within the project directory.
3. Install the SQLite extension if you haven't already. You can find it in the VS Code marketplace or by clicking [here](https://marketplace.visualstudio.com/items?itemName=alexcvzz.vscode-sqlite).
4. Once the extension is installed, open the Command Palette in VS Code by pressing `Ctrl+Shift+P` (Windows/Linux) or `Cmd+Shift+P` (Mac).
5. Type "SQLite: Open Database" in the command palette and select it when it appears.
6. Browse to the location of the SQLite database file within the project directory and select it.
7. The SQLite extension will open the selected database file, and you will see a list of tables in the sidebar of VS Code.
8. Click on a table name to view its contents. The table data will be displayed in the editor pane.
9. You can now browse and interact with the table data directly within VS Code.

## Version Information

- **Backend:**
  - .NET: 8.0.4
  - Microsoft.EntityFrameworkCore.Sqlite: 8.0.4
  - Microsoft.EntityFrameworkCore.Design: 8.0.4

- **Frontend:**
  - Angular CLI: 17.3.7
  - Node: 20.0.0

## Contribution

Feel free to contribute to this project by adding new features, fixing bugs, or improving the documentation. Pull requests are welcome!
