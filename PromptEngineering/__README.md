# GitHub Copilot Prompt Engineering Demo

Bu demo klasörü, GitHub Copilot ile etkili prompt yazma tekniklerini ve çeşitli prompt çerçevelerini (framework) göstermektedir.

## 📁 Demo İçeriği

Bu klasör aşağıdaki dosyaları içermektedir:

### Prompt Framework'leri
- **`PrompFW.txt`** - 12 farklı prompt çerçevesi (R-T-F, T-A-G, R-I-S-E, vb.)
- **`PromptFW-2.txt`** - P-P-F-O çerçevesi ve NextJS geliştirme odaklı prompt şablonları
- **`mimari.txt`** - 16 farklı prompt mimarisi özeti

### Özel Prompt Örnekleri
- **`PromptUnitTest.txt`** - Birim test yazımı için detaylı prompt örnekleri
- **`Prompt-TR.txt`** - Türkçe SQL sorgu yazdırma için özel prompt
- **`ornek.txt`** - T-R-E-F çerçevesi kullanarak banking API örneği

### Kullanım Kılavuzları
- **`Notes.txt`** - Çeşitli araştırma, satış, geliştirme ve tasarım promptları
- **`GhCopUsage.txt`** - GitHub Copilot kullanım örnekleri ve komutları
- **`.github/prompts/sample.prompt.md`** - Flutter chat uygulaması için örnek prompt
- **`.github/copilot-instructions.md`** - GitHub Copilot talimatları

## 🚀 Demo Nasıl Çalıştırılır

### 1. Prompt Framework'lerini Öğrenmek

```bash
# Framework'leri inceleyin
notepad PrompFW.txt
notepad PromptFW-2.txt
```

**En Popüler Framework'ler:**
- **R-T-F**: Role (Rol), Task (Görev), Format (Format)
- **T-A-G**: Task (Görev), Action (Eylem), Goal (Hedef)
- **T-R-A-C-E**: Task, Request, Actions, Context, Example
- **P-P-F-O**: Prompt, Plan, Format, Output

### 2. Birim Test Prompt'larını Denemek

```bash
# Birim test örneklerini inceleyin
notepad PromptUnitTest.txt
```

**Örnek Kullanım:**
GitHub Copilot'a şu prompt'u verin:
```
Calculator sınıfının birim testini oluştur. 
Bu sınıf, çeşitli matematiksel işlemleri sağlar ve çeşitli hatalar döndürebilir 
(örneğin, sıfıra bölme hatası, negatif sayının karekökü hatası). 
Test senaryolarında bu hataların doğru şartlarda döndürüldüğünü doğrula.
```

### 3. SQL Prompt'unu Kullanmak

```bash
# Türkçe SQL prompt'unu inceleyin
notepad Prompt-TR.txt
```

**Kullanım:** Bu dosyadaki prompt'u GitHub Copilot'a vererek Türkçe SQL sorguları yazdırabilirsiniz.

### 4. GitHub Copilot Komutlarını Denemek

```bash
# Copilot kullanım örneklerini inceleyin
notepad GhCopUsage.txt
```

**Örnek Komutlar:**
```
@workspace explain this project
@workspace what are the dependencies required for running the xxx.Api.Activity project?
@workspace /explain #file:Program.cs
```

## 📚 Framework Örnekleri

### R-T-F Framework Örneği
```
Role: Sen bir profesyonel trip planner'sın
Task: Avrupa'ya yapılacak bir gezi için detaylı to-do listesi oluştur
Format: Madde madde (bullet points) formatında sun
```

### T-R-A-C-E Framework Örneği
```
Task: Banking uygulaması için web API oluşturma
Request: Müşteri doğrulama, hesap kontrolü endpoint'leri
Actions: RESTful API, C# ASP.NET Core kullan
Context: Güvenli ve ölçeklenebilir olmalı
Example: POST /api/customers/validate endpoint örneği
```

## 💡 En İyi Uygulamalar

### 1. Prompt Yazarken Dikkat Edilmesi Gerekenler
- **Açık ve net olun**: Belirsizliklerden kaçının
- **Bağlam sağlayın**: Proje detaylarını verin
- **Örnekler kullanın**: Beklentinizi net gösterin
- **Format belirtin**: Çıktının nasıl olmasını istediğinizi söyleyin

### 2. GitHub Copilot ile Çalışırken
- `@workspace` komutunu proje geneli sorular için kullanın
- `#file:` ile belirli dosyalara referans verin
- Inline chat ile seçili kod için yardım alın
- `/explain`, `/doc` gibi komutları kullanın

### 3. Kod Güvenliği
- Açık şifrelerden kaçının
- Hard-coded değerlerden uzak durun
- Güvenli kodlama uygulamalarını takip edin

## 🎯 Pratik Öneriler

1. **Başlangıç**: `PrompFW.txt` dosyasındaki basit framework'lerle başlayın
2. **Uygulama**: `ornek.txt` dosyasındaki T-R-E-F örneğini deneyin
3. **Gelişim**: `PromptUnitTest.txt` dosyasındaki detaylı prompt'ları kullanın
4. **Uzmanlaşma**: Kendi prompt şablonlarınızı oluşturun

## 📞 Ek Kaynaklar

- GitHub Copilot Documentation
- Prompt Engineering Best Practices
- .NET Core Development Guidelines

---

**Not:** Bu demo klasörü, GitHub Copilot ile daha etkili çalışmak için prompt engineering tekniklerini öğretmeyi amaçlamaktadır. Her dosyayı sırayla inceleyerek pratik yapın.