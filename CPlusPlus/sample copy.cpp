#include <iostream>
#include <cmath>

/**
 * @brief Hesap makinesi sınıfı.
 */
class Calculator {
public:
    // Mevcut fonksiyonlar...

    /**
     * @brief Bir sayının üssünü hesaplar.
     * @param base Taban sayı.
     * @param exponent Üs sayısı.
     * @return Üs hesap sonucu.
     */
    double power(double base, double exponent) {
        return std::pow(base, exponent);
    }

    /**
     * @brief İki sayının modülünü hesaplar.
     * @param num1 İlk sayı.
     * @param num2 İkinci sayı.
     * @return Modül hesap sonucu.
     */
    double modulus(double num1, double num2) {
        return std::fmod(num1, num2);
    }

    /**
     * @brief Bir sayının sinüsünü hesaplar.
     * @param num Sayı.
     * @return Sinüs hesap sonucu.
     */
    double sin(double num) {
        return std::sin(num);
    }

    /**
     * @brief Bir sayının kosinüsünü hesaplar.
     * @param num Sayı.
     * @return Kosinüs hesap sonucu.
     */
    double cos(double num) {
        return std::cos(num);
    }

    /**
     * @brief Bir sayının tanjantını hesaplar.
     * @param num Sayı.
     * @return Tanjant hesap sonucu.
     */
    double tan(double num) {
        return std::tan(num);
    }

    /**
     * @brief Bir sayının logaritmasını hesaplar.
     * @param num Sayı.
     * @return Logaritma hesap sonucu.
     */
    double log(double num) {
        if (num <= 0) {
            std::cerr << "Hata! Negatif olmayan bir sayının logaritması tanımlı değildir.";
            return std::numeric_limits<double>::quiet_NaN();
        }
        return std::log(num);
    }

    /**
     * @brief Bir sayının faktöriyelini hesaplar.
     * @param num Sayı.
     * @return Faktöriyel hesap sonucu.
     */
    double factorial(double num) {
        if (num < 0 || floor(num) != num) {
            std::cerr << "Hata! Negatif bir sayının veya tam sayı olmayan bir sayının faktöriyeli tanımlı değildir.";
            return std::numeric_limits<double>::quiet_NaN();
        }
        double result = 1;
        for (int i = 1; i <= num; i++) {
            result *= i;
        }
        return result;
    }
};