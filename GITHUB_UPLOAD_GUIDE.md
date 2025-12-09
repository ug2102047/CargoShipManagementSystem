# 🚀 GitHub এ Upload করার সম্পূর্ণ গাইড

এই file এ step-by-step বলা আছে কিভাবে আপনার project GitHub এ upload করবেন।

---

## 📋 Prerequisites (যা যা লাগবে)

1. ✅ **Git Installed** - [Download Git](https://git-scm.com/downloads)
2. ✅ **GitHub Account** - [Create Account](https://github.com/signup)
3. ✅ **Git configured** with your name and email

**Git check করুন:**

```bash
git --version
```

**Git configure করুন (যদি না করা থাকে):**

```bash
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"
```

---

## 🎯 Method 1: Command Line দিয়ে (Recommended)

### Step 1: GitHub এ New Repository তৈরি করুন

1. GitHub এ login করুন
2. উপরে ডান দিকে **"+"** → **"New repository"** click করুন
3. Repository details দিন:
   - **Repository name:** `CargoShipManagementSystem`
   - **Description:** `A Windows Forms application for managing cargo ships, berths, and cargo shipments`
   - **Public** or **Private** select করুন
   - **⚠️ Important:** "Add a README file", "Add .gitignore", "Choose a license" - এগুলো **select করবেন না** (আমরা ইতিমধ্যে তৈরি করেছি)
4. **"Create repository"** click করুন

### Step 2: Local Repository Initialize করুন

PowerShell বা Command Prompt open করে project folder এ যান:

```bash
cd "e:\4th semester\Syatem Analysis Project\CargoShipManagementSystem"
```

Git repository initialize করুন:

```bash
git init
```

### Step 3: Files Add করুন

সব files staging area তে add করুন:

```bash
git add .
```

**Check করুন কি কি files add হচ্ছে:**

```bash
git status
```

### Step 4: First Commit করুন

```bash
git commit -m "Initial commit: Complete Cargo Ship Management System with database setup"
```

### Step 5: Main Branch Rename করুন

```bash
git branch -M main
```

### Step 6: GitHub Repository এর সাথে Connect করুন

আপনার GitHub repository URL দিন:

```bash
git remote add origin https://github.com/YOUR_USERNAME/CargoShipManagementSystem.git
```

**⚠️ Important:** `YOUR_USERNAME` আপনার GitHub username দিয়ে replace করুন!

**Example:**

```bash
git remote add origin https://github.com/puspita47/CargoShipManagementSystem.git
```

### Step 7: Push করুন GitHub এ

```bash
git push -u origin main
```

**যদি authentication লাগে:**

- GitHub username দিন
- Password এর জায়গায় **Personal Access Token** use করতে হবে

**Personal Access Token তৈরি করার নিয়ম:**

1. GitHub → Settings → Developer settings → Personal access tokens → Tokens (classic)
2. "Generate new token" → "Generate new token (classic)"
3. Note: "CargoShipManagementSystem"
4. Expiration: 90 days বা যা চান
5. Select scopes: ✅ **repo** (সব কিছু check করুন)
6. "Generate token" click করুন
7. Token টি copy করে রাখুন (এটি আর দেখতে পাবেন না!)

✅ **Done!** আপনার project GitHub এ upload হয়ে গেছে!

---

## 🎯 Method 2: GitHub Desktop দিয়ে (Easy GUI Method)

### Step 1: GitHub Desktop Install করুন

Download: [GitHub Desktop](https://desktop.github.com/)

### Step 2: GitHub Desktop Setup

1. GitHub Desktop open করুন
2. "Sign in to GitHub.com" click করুন
3. Browser এ GitHub login করুন
4. Authorize GitHub Desktop

### Step 3: Repository Add করুন

1. **File → Add Local Repository** click করুন
2. Project folder select করুন: `e:\4th semester\Syatem Analysis Project\CargoShipManagementSystem`
3. "Initialize Git Repository" click করুন (যদি আগে initialize না করা থাকে)

### Step 4: Initial Commit

1. বাম দিকে সব files দেখবেন
2. নিচে Summary লিখুন: "Initial commit"
3. Description (optional): "Complete project with database setup and documentation"
4. **"Commit to main"** button click করুন

### Step 5: GitHub এ Publish

1. উপরে **"Publish repository"** button click করুন
2. Repository name check করুন
3. Description add করুন (optional)
4. **Keep this code private** checkbox (যদি private রাখতে চান)
5. **"Publish repository"** click করুন

✅ **Done!** GitHub Desktop automatically push করে দিয়েছে!

---

## 🎯 Method 3: Visual Studio দিয়ে

### Step 1: Visual Studio এ Project Open করুন

### Step 2: Git Initialize করুন

1. **View → Git Changes** (Ctrl+0, Ctrl+G)
2. "Create Git Repository" click করুন

### Step 3: GitHub এ Push করুন

1. **Git Changes** window এ
2. Commit message লিখুন: "Initial commit"
3. "Commit All" dropdown → **"Commit All and Push"**
4. GitHub account login করুন
5. Repository name দিন
6. **"Push"** click করুন

✅ **Done!** Visual Studio থেকেই upload হয়ে গেছে!

---

## 📁 যা যা Upload হবে

```
✅ Source Code (.cs files)
✅ Project Files (.csproj, .sln)
✅ Configuration (App.config)
✅ Database Scripts (DatabaseSchema.sql, etc.)
✅ Documentation (README.md, QUICK_START.md, etc.)
✅ Setup Scripts (SetupDatabase.bat)
✅ Git Configuration (.gitignore)
✅ License (LICENSE)

❌ bin/ folder (ignored)
❌ obj/ folder (ignored)
❌ .vs/ folder (ignored)
❌ packages/ folder (ignored - will be restored via NuGet)
```

---

## 🔄 পরবর্তী Updates Push করার নিয়ম

যখন আপনি code change করবেন এবং GitHub এ update করতে চাইবেন:

```bash
# Check what changed
git status

# Add all changes
git add .

# Commit with message
git commit -m "Update: describe what you changed"

# Push to GitHub
git push
```

**Example:**

```bash
git add .
git commit -m "Add: Ship tracking feature"
git push
```

---

## 🌿 Branch তৈরি করার নিয়ম (Advanced)

নতুন feature develop করার সময়:

```bash
# Create and switch to new branch
git checkout -b feature/new-feature-name

# Make changes, then commit
git add .
git commit -m "Add: new feature"

# Push branch to GitHub
git push -u origin feature/new-feature-name

# GitHub এ যান এবং Pull Request তৈরি করুন
```

---

## ❓ Common Issues এবং Solutions

### ❌ Issue 1: "fatal: not a git repository"

**Solution:**

```bash
git init
```

### ❌ Issue 2: "remote origin already exists"

**Solution:**

```bash
git remote remove origin
git remote add origin https://github.com/YOUR_USERNAME/CargoShipManagementSystem.git
```

### ❌ Issue 3: Authentication failed

**Solution:**

- Personal Access Token use করুন password এর জায়গায়
- GitHub Desktop use করুন (easier authentication)

### ❌ Issue 4: "Updates were rejected"

**Solution:**

```bash
git pull origin main --rebase
git push
```

### ❌ Issue 5: Too many files (large repository)

**Solution:**

```bash
# Check .gitignore is working
git status

# Remove cached files
git rm -r --cached .
git add .
git commit -m "Fix: Update .gitignore"
git push
```

---

## 📊 GitHub Repository Setup Checklist

After uploading, setup করুন:

- [ ] Repository description add করুন
- [ ] Topics/Tags add করুন: `csharp`, `windows-forms`, `sql-server`, `cargo-management`
- [ ] README.md display হচ্ছে কিনা check করুন
- [ ] About section fill করুন
- [ ] License দেখা যাচ্ছে কিনা check করুন
- [ ] Issues enable করুন
- [ ] Discussions enable করুন (optional)
- [ ] Wiki enable করুন (optional)

---

## 🎉 Congratulations!

আপনার project এখন GitHub এ live! 🚀

**Next Steps:**

1. Repository URL share করুন
2. README.md তে screenshot add করুন (optional)
3. Demo video বানান (optional)
4. Contributors invite করুন (optional)

**Your Repository URL:**

```
https://github.com/YOUR_USERNAME/CargoShipManagementSystem
```

---

## 📞 Need Help?

- GitHub Docs: https://docs.github.com
- Git Tutorial: https://git-scm.com/docs/gittutorial
- GitHub Desktop Help: https://docs.github.com/en/desktop

**Happy Coding! 💻🚢**
