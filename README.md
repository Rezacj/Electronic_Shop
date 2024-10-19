
# 📚 Electronic Shop  

یک فروشگاه آنلاین برای مدیریت و فروش دوره‌های آموزشی، کتاب‌های آنلاین، و محصولات الکترونیکی. این پروژه با تمرکز بر بهینه‌سازی کدها توسعه داده شده و ظاهر صرفاً برای نمایش بهتر قابلیت‌ها طراحی شده است.

---

## 🚀 ویژگی‌ها  
- **ثبت‌نام و ورود کاربران:** با ایمیل و رمز عبور  
- **سبد خرید:** امکان جستجو و افزودن محصولات به سبد خرید  
- **مدیریت ادمین:** پنل CRUD برای اضافه، ویرایش و حذف محصولات  
- **ورود به پنل ادمین:** با وارد کردن `/admin/` در URL پس از ورود  

**داده‌های آزمایشی:**  
- **ادمین:** `admin@example.com / admin123`  
- **کاربر عادی:** `user1@gmail.com / 123`

---

## 🛠 تکنولوژی‌های استفاده شده  
- **ASP.NET Core 8**  
- **EF Core**  
- **Razor Pages**  
- **HTML, CSS, JavaScript**
- **SQL Server** (برای مدیریت دیتابیس)  

> **توجه:** داده‌های حساس هش نشده‌اند چون این نسخه برای تست است.

---

## ⚙ پیش‌نیازها  
- **ASP.NET Core SDK**  
- **ASP.NET Core Runtime**

---

## 🔧 نصب و راه‌اندازی  
1. کلون کردن ریپوزیتوری:  
   ```bash
   git clone https://github.com/Rezacj/Electronic_Shop.git
   cd Electronic_Shop
   ```
2. اعمال مایگریشن:  
   ```bash
   dotnet ef database update
   ```
3. اجرای برنامه:  
   ```bash
   dotnet run
   ```
4. **ورود به پنل ادمین:** وارد URL زیر شوید:  
   ```bash
   http://localhost:5000/admin/
   ```

---

## ✨ توضیحات اضافه  
- ظاهر ساده است، چون تمرکز بر روی **کدهای بهینه** بوده.  
- تصاویر محصولات ثابت هستند و قابلیت آپلود بعداً اضافه می‌شود.

---
