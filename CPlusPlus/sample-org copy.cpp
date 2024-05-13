#include <iostream>  // Giriş ve çıkış işlemleri için kütüphane
#include <cmath>  // Matematiksel işlemler için kütüphane

class Calculator {  // Calculator adında bir sınıf oluşturuluyor
public:
    double add(double num1, double num2) {  // İki sayıyı toplayan fonksiyon
        return num1 + num2;  // Toplama işlemini gerçekleştir ve sonucu döndür
    }

    double subtract(double num1, double num2) {  // İki sayıyı çıkaran fonksiyon
        return num1 - num2;  // Çıkarma işlemini gerçekleştir ve sonucu döndür
    }

    double multiply(double num1, double num2) {  // İki sayıyı çarpan fonksiyon
        return num1 * num2;  // Çarpma işlemini gerçekleştir ve sonucu döndür
    }

    double divide(double num1, double num2) {  // İki sayıyı bölen fonksiyon
        if (num2 != 0) {  // Bölme işlemi için paydanın sıfır olmaması gerektiği kontrol ediliyor
            return num1 / num2;  // Bölme işlemini gerçekleştir ve sonucu döndür
        }
        std::cerr << "Error! Division by zero is not allowed.";  // Payda sıfır ise hata mesajı veriliyor
        return std::numeric_limits<double>::quiet_NaN();  // Hata durumunda NaN döndürülüyor
    }

    double squareRoot(double num) {  // Bir sayının karekökünü alan fonksiyon
        if (num >= 0) {  // Karekök işlemi için sayının negatif olmaması gerektiği kontrol ediliyor
            return std::sqrt(num);  // Karekök işlemini gerçekleştir ve sonucu döndür
        }
        std::cerr << "Error! Square root of a negative number is not defined.";  // Sayı negatif ise hata mesajı veriliyor
        return std::numeric_limits<double>::quiet_NaN();  // Hata durumunda NaN döndürülüyor
    }

    double factorial(double num) {  // Bir sayının faktöriyelini hesaplayan fonksiyon
        if (num >= 0) {  // Faktöriyel işlemi için sayının negatif olmaması gerektiği kontrol ediliyor
            double result = 1;  // Sonucu tutacak değişken
            for (int i = 1; i <= num; i++) {  // Faktöriyel hesaplaması için döngü
                result *= i;  // Faktöriyel hesaplaması
            }
            return result;  // Sonucu döndür
        }
        std::cerr << "Error! Factorial of a negative number cannot be calculated.";  // Sayı negatif ise hata mesajı veriliyor
        return std::numeric_limits<double>::quiet_NaN();  // Hata durumunda NaN döndürülüyor
    }
};