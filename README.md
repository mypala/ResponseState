# ResponseState

[🇹🇷 Türkçe](#türkçe) | [🇬🇧 English](#english) 

---

<a id="türkçe"></a>
## 🇹🇷 Türkçe

Clean Architecture (Temiz Mimari) .NET uygulamaları için özel olarak tasarlanmış, .NET API'leri için standart ve temiz bir yanıt durumu (response state) yönetim kütüphanesidir. Başarılı ve hatalı durumları tutarlı bir şekilde ele alarak API yanıtları için standartlaştırılmış sarmalayıcılar (wrapper) sağlar.

### Özellikler

- **Standartlaştırılmış API Yanıt Modelleri**: Tüm API endpoint'leri genelinde tek tip yanıtlar.
- **Clean Architecture Uyumluluğu**: Temiz Mimari sınırları içerisinde sorunsuz çalışacak şekilde tasarlanmıştır.
- **FluentValidation Entegrasyonu**: Doğrulama hatalarını kolayca standart hata yanıtlarına eşleyebilirsiniz.
- **Dahili Logging Abstractions Desteği**: Microsoft.Extensions.Logging ile kutudan çıktığı gibi entegre çalışır.

### Kurulum

Paketi NuGet Paket Yöneticisi üzerinden kurabilirsiniz:

```bash
dotnet add package ResponseState
```

### Kullanım

Servis sonuçlarınızı ve API yanıtlarınızı sarmalamak için sağlanan sınıf ve modelleri kullanın.

```csharp
// Standart bir Application Service kullanım örneği
public async Task<ResponseState<UserDto>> GetUserAsync(int id)
{
    var user = await _userRepository.GetByIdAsync(id);
    
    if (user == null)
    {
        return ResponseState<UserDto>.Fail("Kullanıcı bulunamadı.", Status.NotFound);
    }
    
    return ResponseState<UserDto>.Success(user, Status.Success);
}
```

---

<a id="english"></a>
## 🇬🇧 English

A standard and clean response state management library for .NET APIs, specifically designed for Clean Architecture .NET applications. It provides standardized wrappers for API responses, handling success and error states consistently.

### Features

- **Standardized API Response Models**: Uniform responses across all API endpoints.
- **Clean Architecture Ready**: Designed to work seamlessly within Clean Architecture boundaries.
- **FluentValidation Integration**: Easily map validation failures to standard error responses.
- **Built-in Logging Abstractions Support**: Integrate with Microsoft.Extensions.Logging out of the box.

### Installation

You can install the package via NuGet Package Manager:

```bash
dotnet add package ResponseState
```

### Usage

Use the provided classes and models to wrap your service results and API responses.

```csharp
// Example usage in a standard Application Service
public async Task<ResponseState<UserDto>> GetUserAsync(int id)
{
    var user = await _userRepository.GetByIdAsync(id);
    
    if (user == null)
    {
        return ResponseState<UserDto>.Fail("User not found.", Status.NotFound);
    }
    
    return ResponseState<UserDto>.Success(user, Status.Success);
}
```

### Lisans / License

This project is licensed under the MIT License. / Bu proje MIT Lisansı altında lisanslanmıştır.
