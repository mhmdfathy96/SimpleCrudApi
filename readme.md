# SimpleCRUDAPI

A simple .NET 8 Web API demonstrating CRUD operations using **Entity Framework Core** and **SQL Server**.

---

## 🔧 Features

- Clean Web API structure following the **MVC pattern**
- Entity Framework Core (Code First)
- Connection string management:
  - ✅ **Development**: Using `dotnet user-secrets`
  - ✅ **Production**: Using **environment variables**
- Deployed using **GitHub Actions** and **FTP** to SmarterASP.NET
- Swagger UI for easy testing

---

## 🚀 Live Swagger Demo

You can test the CRUD endpoints here:

🔗 [http://mindtocode-001-site12.qtempurl.com/swagger/index.html](http://mindtocode-001-site12.qtempurl.com/swagger/index.html)

> ⚠️ **Note:** The API is fully deployed and functional — including the database.  
> However, if you clone and run it locally, you’ll need to configure your own connection string using `dotnet user-secrets` (see below), otherwise the DB won't connect.

---

## 🧪 Local Development

### 1. Clone the repository

```bash
git clone https://github.com/your-username/SimpleCRUDAPI.git
cd SimpleCRUDAPI
```

### 2. Set up user-secrets (to avoid storing sensitive data in code)

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Default" "Server=.;Database=SimpleCrudDb;Trusted_Connection=True;TrustServerCertificate=True"
```

### 3. Run the app

```bash
dotnet run --project SimpleCrudApi
```

Navigate to `https://localhost:<port>/swagger` to test the endpoints.

---

## ⚙️ Connection String Logic

Inside `Program.cs` or `DbContext` setup:

```csharp
var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("Default")
    : Environment.GetEnvironmentVariable("Default");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
```

---

## 🌐 Production Environment Setup

On the server (e.g., SmarterASP.NET), set your environment variable like:

**Key:** `Default`  
**Value:** `Server=SQLSERVERURL;Database=ProdDb;User Id=...;Password=...;TrustServerCertificate=True`

---

## 🔄 Deployment (via GitHub Actions)

This project uses GitHub Actions to build and deploy the API to **SmarterASP.NET** using FTP.

Secrets used:

- `FTP_SERVER`
- `FTP_USERNAME`
- `FTP_PASSWORD`
- `FTP_PATH` (e.g., `\simplecrudapi\`)

Note: Be careful with `FTP_PATH` — it should **end with a slash `/`** but **not include a duplicate folder name** to avoid nesting like `simplecrudapi/simplecrudapi`.

---

## ✅ Example API Endpoints

| Method | Endpoint              | Description         |
|--------|-----------------------|---------------------|
| GET    | `/api/items`          | Get all items       |
| GET    | `/api/items/{id}`     | Get item by ID      |
| POST   | `/api/items`          | Create new item     |
| PUT    | `/api/items/{id}`     | Update item         |
| DELETE | `/api/items/{id}`     | Delete item         |

All available via Swagger UI.

---

## 📂 Folder Structure

```
SimpleCrudApi/
│
├── Controllers/
├── Models/
├── Services/
├── Program.cs
├── appsettings.json
├── README.md
```

---

## Credits

Created to demonstrate simple practices with .NET Web API, EF Core, secrets management, and CI/CD using GitHub Actions.
