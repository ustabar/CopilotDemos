#include <iostream>
#include <cmath> // cmath kütüphanesini NaN için kullanıyoruz

/**
 * @brief The Calculator class provides basic arithmetic operations.
 */
/**
 * @brief Hesap makinesi sınıfı.
 * 
 * Bu sınıf, matematiksel işlemleri gerçekleştirmek için kullanılır.
 * Toplama, çıkarma, çarpma ve bölme işlemlerini destekler.
 */
class Calculator {
public:
    /**
     * @brief İki sayıyı toplar.
     * @param num1 İlk sayı.
     * @param num2 İkinci sayı.
     * @return İki sayının toplamı.
     */
    double add(double num1, double num2) {
        double added_result = num1 + num2;
        return added_result;
    }

    /**
     * @brief İki sayıyı çıkarır.
     * @param num1 İlk sayı.
     * @param num2 İkinci sayı.
     * @return İki sayının farkı.
     */
    double subtract(double num1, double num2) {
        double subtracted_result = num1 - num2;
        return subtracted_result;
    }

    /**
     * @brief İki sayıyı çarpar.
     * @param num1 İlk sayı.
     * @param num2 İkinci sayı.
     * @return İki sayının çarpımı.
     */
    double multiply(double num1, double num2) {
        double multiplied_result = num1 * num2;
        return multiplied_result;
    }

    /**
     * @brief İki sayıyı böler.
     * @param num1 Bölünen.
     * @param num2 Bölen.
     * @return İki sayının bölümü.
     * @note Eğer bölen sıfır ise, NaN döner ve bir hata mesajı yazdırır.
     */
    double divide(double num1, double num2) {
        double divided_result = 0;
        if (num2 != 0) {
            divided_result = num1 / num2;
            return divided_result;
        } else {
            std::cerr << "Hata! Sıfıra bölme yapılamaz.\n";
            divided_result = std::numeric_limits<double>::quiet_NaN();
            return divided_result;
        }
    }
};
