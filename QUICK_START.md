# 🚀 Quick Start Guide

**Cargo Ship Management System - সহজ সেটআপ গাইড**

যদি আপনি এই project টি GitHub থেকে download করে থাকেন, তাহলে এই guide follow করুন।

---

## ⚡ দ্রুত সেটআপ (5 মিনিটে)

### 📝 যা যা লাগবে:

1. ✅ **Visual Studio** (2017 বা তার পরের version)
2. ✅ **SQL Server Express** (Free) - যদি না থাকে তাহলে install করুন
3. ✅ **SQL Server Management Studio (SSMS)** - Database manage করার জন্য

---

## 🔧 Step-by-Step Installation

### Step 1️⃣: SQL Server Install করুন (যদি না থাকে)

**SQL Server আছে কিনা check করুন:**

- Windows Search এ লিখুন: "Services"
- "SQL Server (SQLEXPRESS)" খুঁজুন
- যদি পান, তাহলে আপনার SQL Server আছে ✅

**যদি না থাকে, তাহলে install করুন:**

1. **SQL Server Express Download:**

   - 👉 https://www.microsoft.com/en-us/sql-server/sql-server-downloads
   - "Download now" এ click করুন (Express edition)
   - Download করে install করুন

2. **SSMS (SQL Server Management Studio) Download:**
   - 👉 https://aka.ms/ssmsfullsetup
   - Download করে install করুন

**Installation Notes:**

- Express edition সম্পূর্ণ **FREE**
- Installation এর সময় সব default settings রাখুন
- Server name note করে রাখুন (usually: `localhost\SQLEXPRESS`)

---

### Step 2️⃣: Database Setup করুন

এখন আপনার কাছে **৩টি option** আছে database setup করার জন্য:

#### 🌟 **Option A: Automated Setup (সবচেয়ে সহজ - Recommended)**

1. Project folder এ যান
2. `SetupDatabase.bat` file এ **double-click** করুন
3. যখন জিজ্ঞাসা করবে, আপনার SQL Server name লিখুন
   - সাধারণত: `localhost\SQLEXPRESS` বা `.\SQLEXPRESS`
4. "Y" press করে continue করুন
5. সবকিছু automatically setup হয়ে যাবে! ✅

#### 📊 **Option B: Using SSMS (Manual but Visual)**

1. **SQL Server Management Studio** খুলুন
2. Connect করুন:
   - Server name: `localhost\SQLEXPRESS` (বা আপনার server name)
   - Authentication: "Windows Authentication"
   - Connect button click করুন
3. **File → Open → File** এ click করুন
4. Project folder থেকে `DatabaseSchema.sql` select করুন
5. **Execute** button (সবুজ তীর) বা **F5** press করুন
6. Success message দেখবেন ✅

#### 💻 **Option C: Command Line**

Command Prompt খুলে run করুন:

```bash
cd "path\to\CargoShipManagementSystem"
sqlcmd -S localhost\SQLEXPRESS -E -i DatabaseSchema.sql
```

---

### Step 3️⃣: Connection String Update করুন

1. Visual Studio তে project খুলুন
2. `App.config` file খুলুন
3. এই line খুঁজুন:

```xml
<add name="CargoShipDB"
     connectionString="Data Source=YOUR_SERVER_NAME;..." />
```

4. `YOUR_SERVER_NAME` replace করুন আপনার server name দিয়ে:

**আপনার server name কি জানেন না?**

- SSMS খুলুন
- Connect করার সময় যে name দেখাচ্ছে সেটাই

**সাধারণ server names:**

```
localhost\SQLEXPRESS      (SQL Server Express - সবচেয়ে common)
.\SQLEXPRESS              (Same as above)
localhost                 (Default SQL Server instance)
(local)                   (Alternative for default)
```

**উদাহরণ:**

```xml
<add name="CargoShipDB"
     connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=CargoShipDB;Integrated Security=True;"
     providerName="System.Data.SqlClient" />
```

---

### Step 4️⃣: Build এবং Run করুন

1. Visual Studio এ solution open করুন
2. **Solution Explorer** এ right-click → **Restore NuGet Packages**
3. **Build → Rebuild Solution** (Ctrl+Shift+B)
4. **Debug → Start Debugging** (F5) বা Start button click করুন
5. Login screen দেখবেন! 🎉

---

## 🔑 Login Credentials

Database setup করার পর আপনি এই accounts দিয়ে login করতে পারবেন:

| Username | Password    | Role     |
| -------- | ----------- | -------- |
| admin    | admin123    | Admin    |
| manager  | manager123  | Manager  |
| operator | operator123 | Operator |
| viewer   | viewer123   | Viewer   |

**অথবা** নিজে নতুন account তৈরি করতে **"Register"** button click করুন!

---

## ❓ Common Problems এবং Solutions

### ❌ Problem 1: "Cannot connect to database"

**Solution:**

- SQL Server service চালু আছে কিনা check করুন:
  - Windows Search → "Services" → "SQL Server (SQLEXPRESS)" → Start
- App.config এ server name সঠিক আছে কিনা check করুন

### ❌ Problem 2: "Login failed"

**Solution:**

- Windows Authentication use করছেন তো?
- App.config এ `Integrated Security=True` আছে কিনা check করুন

### ❌ Problem 3: "Database 'CargoShipDB' does not exist"

**Solution:**

- DatabaseSchema.sql আবার run করুন
- অথবা SetupDatabase.bat আবার run করুন

### ❌ Problem 4: "Invalid column name 'FullName' or 'Email'"

**Solution:**

- `UpdateUsersTable.sql` run করুন
- এটি missing columns add করে দেবে

### ❌ Problem 5: Build error - "ConfigurationManager does not exist"

**Solution:**

- Project এ System.Configuration reference আছে কিনা check করুন
- Solution rebuild করুন (Ctrl+Shift+B)

---

## 📂 Important Files

| File                   | Purpose                                  |
| ---------------------- | ---------------------------------------- |
| `DatabaseSchema.sql`   | Database তৈরি করে (tables + sample data) |
| `SetupDatabase.bat`    | Automated database setup script          |
| `UpdateUsersTable.sql` | Users table update করে (যদি error হয়)   |
| `ViewAllUsers.sql`     | Database এ কি কি users আছে দেখায়        |
| `App.config`           | Database connection settings             |
| `README.md`            | Detailed documentation                   |
| `USER_ROLES_GUIDE.md`  | User roles এর বিস্তারিত                  |

---

## 📞 Help এবং Support

যদি কোনো সমস্যা হয়:

1. **Check the logs:**
   - `setup_log.txt` (যদি SetupDatabase.bat ব্যবহার করেন)
2. **Verify SQL Server:**
   - Services এ "SQL Server (SQLEXPRESS)" running আছে কিনা
3. **Test Connection:**
   - SSMS দিয়ে manually connect করার try করুন
4. **Common Issues:**
   - Database না থাকলে → DatabaseSchema.sql আবার run করুন
   - Connection error হলে → App.config check করুন
   - Build error হলে → NuGet packages restore করুন

---

## 🎯 Next Steps

Database setup হয়ে গেলে:

1. ✅ Login করুন (default credentials ব্যবহার করে)
2. ✅ Dashboard explore করুন
3. ✅ Ship, Cargo, Berth management features try করুন
4. ✅ নিজের user account তৈরি করুন (Register button)
5. ✅ Reports generate করুন

---

## 🔒 Security Note

⚠️ **Important:** এই application টি educational/demo purposes এর জন্য। Production এ use করার আগে:

- Passwords hash করুন (plain text store করবেন না)
- Connection string encrypt করুন
- Proper authentication এবং authorization implement করুন
- SQL injection protection verify করুন

---

**Happy Coding! 🚢💻**

যদি আরও help লাগে, README.md এবং USER_ROLES_GUIDE.md পড়ুন।
