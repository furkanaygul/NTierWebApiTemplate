# NTierWebApiTemplate

Katmanlı mimariyi (N-Tier Architecture) temel alan, **.NET 7 Web API** projeleri için hazır bir başlangıç şablonu.

Bu repo, tekrar eden altyapı işlerini sıfırdan kurmaya gerek bırakmadan; hızlı, düzenli ve sürdürülebilir bir yapı sağlar.  
Generic repository, Dapper ve Entity Framework Core ile esnek veri erişimi, FluentValidation ile güçlü doğrulama, kolay genişletme ve servis kayıt altyapısı ile donatılmıştır.

> **GitHub:** [github.com/furkanaygul/NTierWebApiTemplate](https://github.com/furkanaygul/NTierWebApiTemplate)

---

## 🚀 Özellikler

- Tam katmanlı mimari (Entity, DataAccess, Business, Service, Controller, Extensions)
- **Generic Repository** (hem Dapper hem EF Core desteği)
- Dapper & Entity Framework Core ile esnek veri erişim altyapısı
- **FluentValidation** ile gelişmiş DTO doğrulama
- Otomatik servis registration ve extension metodlar
- Mapping altyapısı (AutoMapper MappingProfile ile)
- Temiz, örnek ve genişletilebilir klasör yapısı
- Hızlı başlatmak için örnek entity, repository, service ve controller

---

## 🗂️ Klasör ve Katman Yapısı

NTierWebApiTemplate/
│
├─ 1.EntityLayer/
│ └─ Concrete/
│ └─ AccessControls/
│ ├─ BaseEntity.cs
│ └─ DemoClass.cs
│
├─ 2.DataAccessLayer/
│ ├─ Abstract/
│ │ ├─ IDemoDal.cs
│ │ └─ IGenericDal.cs
│ ├─ EF_Core/
│ │ └─ AppDbContext.cs
│ └─ Repositories/
│ └─ Dapper/
│ ├─ DapperGenericRepository.cs
│ └─ DemoRepository.cs
│
├─ 3.BusinessLayer/
│ ├─ Abstract/
│ │ ├─ IDemoClassService.cs
│ │ └─ IGenericService.cs
│ └─ Concreate/
│ └─ DemoClassManager.cs
│
├─ 4.ServiceLayer/
│ ├─ DTOs/
│ ├─ FluentValidations/
│ │ └─ DemoDtoValidator.cs
│ ├─ Interfaces/
│ │ ├─ IApiDemoService.cs
│ │ └─ IApiGenericService.cs
│ ├─ Managers/
│ │ └─ ApiDemoManager.cs
│ └─ Mappings/
│ └─ MappingProfile.cs
│
├─ 5.Controllers/
│ ├─ BaseController.cs
│ └─ DemoController.cs
│
├─ 6.Extensions/
│ ├─ DbInitializer.cs
│ ├─ FluentValidationExtension.cs
│ └─ ServiceRegistrationDI.cs
│
├─ appsettings.json
├─ BaseProjectTemplate.http
└─ Program.cs
