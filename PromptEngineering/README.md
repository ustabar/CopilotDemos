# 🚀 GitHub Copilot Prompt Engineering Demo

Bu demo klasörü, GitHub Copilot ile etkili prompt yazma tekniklerini, çeşitli prompt çerçevelerini (framework) ve en iyi uygulamaları kapsamlı bir şekilde göstermektedir.

## 📁 Demo İçeriği

Bu klasör aşağıdaki yapıda organize edilmiştir:

### 📄 Ana Dosyalar
- **`mimari.txt`** - 16 farklı prompt mimarisi ve .NET Core bileşenleri hakkında özet
- **`Notes.txt`** - Çeşitli araştırma, satış, geliştirme ve tasarım prompt örnekleri

### 📂 Prompts Klasörü
- **`Frameworks.txt`** - 12+ detaylı prompt çerçevesi (A-P-E, A-P-P-R-O-A-C-H, R-T-F, T-A-G vb.)
- **`Instructions-Sample-Turkish.txt`** - Türkçe talimat örnekleri
- **`SQL-Sample-Turkish.txt`** - Türkçe SQL sorgu yazma için özel promptlar
- **`Various-Samples.txt`** - Çeşitli kullanım senaryoları için prompt örnekleri

### 🖼️ Pictures Klasörü
- Demo ile ilgili görsel materyaller

## 🎯 Demo Amacı

Bu demo aşağıdaki becerileri geliştirmeyi hedefler:
- ✅ Etkili prompt yazma teknikleri
- ✅ Çeşitli prompt framework'lerini kullanma
- ✅ GitHub Copilot ile verimli çalışma
- ✅ Kod kalitesini artırma
## 🚀 Demo Nasıl Çalıştırılır

### 1️⃣ Prompt Framework'lerini Keşfetmek

**Başlangıç Seviyesi:**
```powershell
# Temel framework'leri inceleyin
notepad Prompts\Frameworks.txt
```

**En Popüler Framework'ler:**

| Framework | Açıklama | Kullanım Alanı |
|-----------|----------|----------------|
| **A-P-E** | Action, Purpose, Expectation | Genel amaçlı promptlar |
| **R-T-F** | Role, Task, Format | Rol tabanlı görevler |
| **T-A-G** | Task, Action, Goal | Hedef odaklı işlemler |
| **T-R-A-C-E** | Task, Request, Actions, Context, Example | Kompleks projeler |

### 2️⃣ Pratik Örnekler

**Framework Örneği - A-P-E:**
```
Action: Bir e-ticaret sitesi için güvenli ödeme API'si oluştur
Purpose: Müşteri ödeme bilgilerini güvenli bir şekilde işlemek
Expectation: RESTful API, JWT token doğrulama ve hata yönetimi içeren kod
```

**Framework Örneği - T-R-A-C-E:**
```
Task: Banking uygulaması için web API oluşturma
Request: Müşteri doğrulama, hesap kontrolü endpoint'leri
Actions: RESTful API, C# ASP.NET Core kullan
Context: Güvenli ve ölçeklenebilir olmalı, JWT kullan
Example: POST /api/customers/validate endpoint örneği
```

### 3️⃣ Türkçe Prompt Kullanımı

```powershell
# Türkçe SQL prompt örneklerini inceleyin
notepad Prompts\SQL-Sample-Turkish.txt
notepad Prompts\Instructions-Sample-Turkish.txt
```

**Türkçe Prompt Örneği:**
```
Sen bir C# geliştiricisisin. Aşağıdaki gereksinimlere göre bir Entity Framework kod oluştur:
- Müşteri bilgilerini tutan Customer sınıfı
- CRUD operasyonları için repository pattern
- Validation kuralları ekle
- Async metotlar kullan
```

### 4️⃣ GitHub Copilot Komutları

**Workspace Seviyesi Komutlar:**
```
@workspace explain this project
@workspace what are the dependencies required for running this project?
@workspace how to run the application?
@workspace create unit tests for this class
```

**Dosya Seviyesi Komutlar:**
```
@workspace /explain #file:Program.cs
@workspace /doc #file:CustomerService.cs
@workspace /tests #file:PaymentController.cs
```

## 💡 En İyi Uygulamalar

### ✅ Etkili Prompt Yazma

1. **Açık ve Net Olun**
   - ❌ "Kod yaz"
   - ✅ "ASP.NET Core ile RESTful API oluştur, JWT authentication kullan"

2. **Bağlam Sağlayın**
   - Proje detaylarını belirtin
   - Kullanılan teknolojileri söyleyin
   - Güvenlik gereksinimlerini ekleyin

3. **Format Belirtin**
   - Kod yapısını açıklayın
   - Dosya organizasyonunu belirtin
   - Dokümantasyon formatını söyleyin

### ✅ Framework Seçimi

| Durum | Önerilen Framework | Neden |
|-------|-------------------|--------|
| Basit görevler | A-P-E | Hızlı ve etkili |
| Rol tabanlı | R-T-F | Net rol tanımı |
| Kompleks projeler | T-R-A-C-E | Detaylı bağlam |
| Hedef odaklı | T-A-G | Sonuç odaklı |

## 📋 Pratik Egzersizler

### 🏃‍♂️ Başlangıç Seviyesi

1. **A-P-E Framework ile Basit API:**
```
Action: Bir TODO list API'si oluştur
Purpose: Görevleri CRUD operasyonları ile yönetmek
Expectation: ASP.NET Core, Entity Framework, Swagger dokümantasyonu
```

2. **R-T-F Framework ile Veritabanı:**
```
Role: Senior .NET geliştiricisi
Task: Entity Framework Code First yaklaşımı ile veritabanı modeli oluştur
Format: Migration dosyaları ve DbContext sınıfı içeren proje
```

### 🏃‍♂️ Orta Seviye

1. **T-R-A-C-E Framework ile Mikroservis:**
```
Task: E-ticaret için ürün katalog mikroservisi
Request: Ürün listeleme, filtreleme, arama API'leri
Actions: ASP.NET Core, Redis cache, MongoDB kullan
Context: Docker container, Kubernetes deployment
Example: GET /api/products?category=electronics&sort=price
```

### 🏃‍♂️ İleri Seviye

1. **Kapsamlı İş Uygulaması:**
```powershell
# Çok katmanlı mimari için prompt örneği
notepad Prompts\Various-Samples.txt
```

## 🔍 Dosya İnceleme Rehberi

### 📊 Öncelik Sırası

1. **İlk İncelenmesi Gerekenler:**
   - `Prompts\Frameworks.txt` - Temel framework'ler
   - `mimari.txt` - Sistem mimarisi
   - `Notes.txt` - Praktik örnekler

2. **Derinlemesine İnceleme:**
   - `Prompts\SQL-Sample-Turkish.txt` - SQL promptları
   - `Prompts\Instructions-Sample-Turkish.txt` - Türkçe talimatlar
   - `Prompts\Various-Samples.txt` - Çeşitli senaryolar

## 🎮 İnteraktif Öğrenme

### Adım 1: Framework Seçimi
```powershell
# Bir framework seçin ve test edin
Get-Content "Prompts\Frameworks.txt" | Select-String "R-T-F"
```

### Adım 2: Prompt Oluşturma
1. Seçtiğiniz framework'ü kullanın
2. Kendi prompt'unuzu yazın
3. GitHub Copilot ile test edin

### Adım 3: Sonuçları Değerlendirme
- Kod kalitesini kontrol edin
- Gereksinimler karşılandı mı?
- Güvenlik açıkları var mı?

## 🏆 Başarı Kriterleri

Bu demoyu tamamladığınızda şunları yapabilmelisiniz:

- ✅ 5+ farklı prompt framework kullanabilme
- ✅ Etkili Türkçe promptlar yazabilme  
- ✅ GitHub Copilot komutlarını kullanabilme
- ✅ Kod kalitesini prompt ile artırabilme
- ✅ Güvenli kod yazdırma teknikleri

## 🤝 Katkı ve Geri Bildirim

Bu demo sürekli geliştirilmektedir. Yeni örnekler, framework'ler ve en iyi uygulamalar eklenmektedir.

### 💬 Öneriler
- Yeni prompt örnekleri
- Framework geliştirmeleri
- Türkçe içerik önerileri
- Pratik egzersiz fikirleri

## 📚 Ek Kaynaklar

- [GitHub Copilot Documentation](https://docs.github.com/en/copilot)
- [Prompt Engineering Best Practices](https://help.openai.com/en/articles/6654000-best-practices-for-prompt-engineering-with-openai-api)
- [.NET Core Development Guidelines](https://docs.microsoft.com/en-us/dotnet/core/)
- [ASP.NET Core Security](https://docs.microsoft.com/en-us/aspnet/core/security/)

---

**💡 Önemli Not:** Bu demo, GitHub Copilot ile daha etkili çalışmak için prompt engineering tekniklerini öğretmeyi amaçlamaktadır. Her dosyayı sırayla inceleyerek pratik yapın ve kendi prompt tarzınızı geliştirin.

**🎯 Hedef:** Prompt engineering konusunda uzmanlaşarak, GitHub Copilot ile daha verimli kod geliştirmek!

**Yardım:**  
- [Copilot Belgeleri](https://docs.github.com/en/copilot)
- [GitHub Destek](https://support.github.com/)

---

## 🤝 Katkı ve Kaynaklar

**Katkıda Bulunmak İçin:**
- Fork'layın, değişiklik yapın, PR gönderin

**Ek Kaynaklar:**
- [Copilot Prompt Engineering Guide](https://docs.github.com/en/copilot)
- [Awesome Copilot Prompts](https://github.com/ztjhz/awesome-copilot-prompts)

---

> 💬 **Hemen deneyin!** Her bölümdeki örnek prompt'ları Copilot'a yazın ve sonuçları gözlemleyin. Öğrenme yolculuğunuzda başarılar! 🚀