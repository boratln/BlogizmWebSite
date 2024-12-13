# Blogizm Web
___
Bu projede, kullanıcıların anime, dizi/film ve oyun gibi kategorilerdeki haberleri takip edebileceği ve yorumlar bırakabileceği modern bir blog sitesi geliştirilmiştir. Kullanıcılar, farklı kategorilerdeki içeriklere göz atabilir ve yorum yaparak etkileşimde bulunabilirler.
# Ana Sayfa

![AnaSayfa](https://github.com/user-attachments/assets/49bac34a-eca7-41b3-b673-f81b073fda8e)
![Anasayfa2](https://github.com/user-attachments/assets/1eb7aeb7-f5a8-4b37-bd18-c09ea5242daa)
![AnaSayfa3](https://github.com/user-attachments/assets/0064392a-df54-4a10-9944-414da4d8c0cf)
![AnaSayfa4](https://github.com/user-attachments/assets/eed8409a-d27c-4c53-b96f-8c60f64dd540)
![Footer](https://github.com/user-attachments/assets/aec43046-c665-4f1e-9792-1565f7e2c9c7)
___
# Hakkımızda Sayfası 
![Hakkımızda1](https://github.com/user-attachments/assets/b7f423ba-8c5a-4e00-ac10-1fbab6a2829c)
![Hakkımızda2](https://github.com/user-attachments/assets/89995fb9-ff9e-49a6-994c-0a6bb1b3e588)
![Hakkımızda3](https://github.com/user-attachments/assets/fda3e227-b3bb-4a55-b552-b17a00ea634b)

___
# İletişim Sayfası

___
![İletişim](https://github.com/user-attachments/assets/b5561d20-78ac-488f-a0d5-5922df639479)
___
# Blog Sayfası

![Blog1](https://github.com/user-attachments/assets/d7a39370-aadb-476f-95a6-3f0112690b91)
![Blog2](https://github.com/user-attachments/assets/f0b2e649-990f-4539-8a95-2c3b33273b0a)
___
# Blog Detay Sayfası

![BlogDetay1](https://github.com/user-attachments/assets/035d8021-597a-4875-a18b-35aaccbbe5f6)
___
# Giriş Yap ve Kayıt Ol Sayfaları
![Giriş Yap](https://github.com/user-attachments/assets/4f94c9f4-cece-4242-806b-7785fbda4600)
![Kayıt Ol](https://github.com/user-attachments/assets/773a49c9-ffad-4e06-8ba3-c783920b2ebe)
___
# Admin Panel Blog Sayfası
![Admin Panel Blog](https://github.com/user-attachments/assets/da057f3c-5d34-45ea-acc6-71479864e50a)
![Admin Panel Blog Ekleme](https://github.com/user-attachments/assets/83647a8e-7b43-433b-a213-d5926ee9210f)
![Admin Panel Blog Güncelleme](https://github.com/user-attachments/assets/96f63295-8f32-40d5-ab72-a2f082e703ca)
___
# Web API Swagger
![Web Api Blog](https://github.com/user-attachments/assets/1b5bc8ef-8f65-4c8c-992b-8e2ec1e2e1e7)

# Kullanılan Teknolojiler
---
# Backend
---
*  **C#:** Backend tarafı C# Programlama dili ile yazılmıştır.
*  **LINQ:** Karmaşık sorgular için LINQ kullanılmıştır.
*  **Onion Architecture(Soğan Mimarisi):** Katmanlı mimari olarak Onion Architecture kullanılmıştır.
*  **CQRS:** Statik tablodaki işlemler için CQRS Tasarım deseni kullanılmıştır.
*  **Mediator** İşlemlerin yoğun olduğu tablolar için Mediator Tasarım deseni kullanılmıştır.
*  **JSON Web Token:** Kullanıcıların yetki işlemleri için Json Web Token kullanılmıştır.
*  **Swagger:** Api kontrol işlemleri için Swagger kullanılmıştır.
*  **Code First Yaklaşımı:** Veritabanındaki tablolar Code First yaklaşımı ile oluşturulmuştur.

  # Frontend
  ___
 * **HTML:** Sitenin temel tasarımı için HTML kullanılmıştır.
 *  **CSS:** Sitenin stil işlemleri için CSS kullanılmıştır.
 *  **Javascript:** Sayfa etkileşimleri için JavaScript kullanılmıştır.
 *  **SweetAlert:** Sayfada modern uyarı mesajları vermek için SweetAlert kullanılmıştır.

   &nbsp;

**Proje Yapısı ve Katmanlı Mimarisi**
___
Proje aşağıdaki katmanlı mimarisi takip eder:
- **Core:** Bu katmanda Application ve Domain alt katmanları bulunur.
- **Domain:** Bu katmanda veritabanı tablosundaki Entity'ler yer alır.
- **Application:** Bu katman iş katmanıdır. Tasarım desenleri olan CQRS ve Mediator temel yapıları yer alır.
- **Infrastructure:** Bu katmanda veritabanı dosyası ve Repository'ler bulunur.
- **Presentation:** Bu katman sunum katmanıdır. Bu katmanda Web API bulunur.
  



