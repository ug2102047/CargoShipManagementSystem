# User Roles এবং Permissions

## 🔐 Role Types এবং তাদের পার্থক্য

আপনার Cargo Ship Management System এ ৪ ধরনের user role আছে। প্রত্যেক role এর আলাদা আলাদা access level এবং permissions আছে।

---

## 👤 1. Viewer (দর্শক)

**Access Level:** শুধুমাত্র দেখতে পারবে

### ✅ যা করতে পারবে:

- Dashboard দেখতে পারবে
- Ship, Cargo, Berth এর তথ্য **শুধু দেখতে** পারবে
- Reports দেখতে পারবে
- Search এবং Filter করতে পারবে

### ❌ যা করতে পারবে না:
- কোনো data Add করতে পারবে না
- কোনো data Update করতে পারবে না
- কোনো data Delete করতে পারবে না
- Report Generate করতে পারবে না

**কখন ব্যবহার করবেন:** যারা শুধু তথ্য দেখতে চান, কোনো পরিবর্তন করবেন না (যেমন: Guest, Client, Auditor)

---

## 👨‍💼 2. Operator (অপারেটর)

**Access Level:** দৈনন্দিন কাজের জন্য

### ✅ যা করতে পারবে:

- Dashboard দেখতে পারবে
- Ship, Cargo, Berth এর তথ্য **দেখতে এবং Add** করতে পারবে
- Existing data **Update** করতে পারবে
- Ship এ Cargo assign করতে পারবে
- Berth এ Ship assign করতে পারবে
- Basic Reports generate করতে পারবে

### ❌ যা করতে পারবে না:

- Data **Delete** করতে পারবে না (শুধু Manager/Admin পারবে)
- User management করতে পারবে না

**কখন ব্যবহার করবেন:** যারা প্রতিদিন data entry এবং update করেন (যেমন: Port Officer, Data Entry Operator)

---

## 👨‍💼 3. Manager (ম্যানেজার)

**Access Level:** সম্পূর্ণ operational control

### ✅ যা করতে পারবে:

- সব কিছু যা Operator করতে পারে
- Data **Delete** করতে পারবে
- Advanced Reports এবং Analytics দেখতে পারবে
- Financial Reports generate করতে পারবে
- Invoice তৈরি করতে পারবে
- System settings change করতে পারবে (কিছু ক্ষেত্রে)

### ❌ যা করতে পারবে না:

- অন্য user এর account manage করতে পারবে না (শুধু Admin পারবে)
- System-level configuration change করতে পারবে না

**কখন ব্যবহার করবেন:** যারা port বা department পরিচালনা করেন (যেমন: Port Manager, Operations Manager)

---

## 👨‍💻 4. Admin (প্রশাসক)

**Access Level:** সম্পূর্ণ system control

### ✅ যা করতে পারবে:

- **সব কিছু** যা Manager করতে পারে
- User account তৈরি, edit, delete করতে পারবে
- User roles change করতে পারবে
- System-level settings এবং configuration change করতে পারবে
- Database backup/restore করতে পারবে
- System logs এবং audit trails দেখতে পারবে
- Security settings manage করতে পারবে

**কখন ব্যবহার করবেন:** IT Administrator বা System Owner এর জন্য

---

## 📊 Role Comparison Table

| Feature          | Viewer | Operator | Manager | Admin |
| ---------------- | ------ | -------- | ------- | ----- |
| View Data        | ✅     | ✅       | ✅      | ✅    |
| Add Data         | ❌     | ✅       | ✅      | ✅    |
| Update Data      | ❌     | ✅       | ✅      | ✅    |
| Delete Data      | ❌     | ❌       | ✅      | ✅    |
| Generate Reports | ❌     | ✅       | ✅      | ✅    |
| Create Invoices  | ❌     | ❌       | ✅      | ✅    |
| Manage Users     | ❌     | ❌       | ❌      | ✅    |
| System Settings  | ❌     | ❌       | ❌      | ✅    |

---

## 🔒 Security Best Practices

1. **Viewer Role দিয়ে শুরু করুন:** নতুন user registration এর ক্ষেত্রে default role হিসেবে Viewer ব্যবহার করুন
2. **Least Privilege Principle:** শুধুমাত্র প্রয়োজনীয় permissions দিন
3. **Regular Audit:** নিয়মিত check করুন কে কি করছে
4. **Admin Account সীমিত রাখুন:** খুব কম লোককে Admin access দিন

---

## 📝 Note

বর্তমানে আপনার system এ role-based restrictions implement করা নেই। সব user সব feature access করতে পারে। ভবিষ্যতে চাইলে আমরা role-based permissions add করতে পারি।

---

## 🆘 সাধারণ প্রশ্ন

**Q: Registration এর সময় কোন role select করব?**  
A: যদি সাধারণ user হন তাহলে **Viewer** select করুন। Admin আপনার role পরে upgrade করে দিতে পারবে।

**Q: আমার role কিভাবে জানব?**  
A: Login করার পর Dashboard এ আপনার role দেখাবে।

**Q: Role change করতে চাইলে কি করব?**  
A: Admin এর সাথে যোগাযোগ করুন। শুধুমাত্র Admin role change করতে পারে।
