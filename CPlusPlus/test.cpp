#include <iostream> // Standart giriş-çıkış akışını içe aktarır
#include <stdexcept> // İstisna işleme araçlarını sağlar

// Calculator sınıfının tanımı
class Calculator {
public:
    // İki sayıyı toplamak için fonksiyon
    double add(double operand1, double operand2) {
        return operand1 + operand2; // Toplamı döndürür
    }

    // Bir sayıdan diğerini çıkarmak için fonksiyon
    double subtract(double operand1, double operand2) {
        return operand1 - operand2; // Farkı döndürür
    }

    // İki sayıyı çarpmak için fonksiyon
    double multiply(double operand1, double operand2) {
        return operand1 * operand2; // Çarpımı döndürür
    }

    // Bir sayıyı diğerine bölmek için fonksiyon
    double divide(double dividend, double divisor) {
        if (divisor == 0) { // Eğer bölen sıfır ise
            throw std::invalid_argument("Sıfıra bölme izin verilmez."); // Bir istisna fırlatır
        }
        return dividend / divisor; // Bölümü döndürür
    }
};

// Ana fonksiyon
int main() {
    Calculator calc; // Bir Calculator nesnesi oluşturur
    double num1 = 10.0; // Bir sayı tanımlar
    double num2 = 5.0; // Başka bir sayı tanımlar

    try { // Aşağıdaki kodu dener
        double result = calc.divide(num1, num2); // num1'i num2'ye böler
        std::cout << "Bölme sonucu: " << result << std::endl; // Sonucu yazdırır
    } catch (const std::exception& e) { // Eğer bir istisna fırlatılırsa
        std::cerr << "Hata: " << e.what() << std::endl; // Hata mesajını yazdırır
    }

    return 0; // Programın sonu
}