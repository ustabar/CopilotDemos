#include <iostream>
#include <cmath>

class Calculator {
public:
    double add(double num1, double num2) {
        return num1 + num2;
    }

    double subtract(double num1, double num2) {
        return num1 - num2;
    }

    double multiply(double num1, double num2) {
        return num1 * num2;
    }

    double divide(double num1, double num2) {
        if (num2 != 0) {
            return num1 / num2;
        }
        std::cerr << "Hata! Sıfıra bölme yapılamaz.";
        return std::numeric_limits<double>::quiet_NaN();
    }

    double squareRoot(double num) {
        if (num >= 0) {
            return std::sqrt(num);
        }
        std::cerr << "Hata! Negatif bir sayının karekökü tanımlı değildir.";
        return std::numeric_limits<double>::quiet_NaN();
    }

    double factorial(double num) {
        if (num >= 0) {
            double result = 1;
            for (int i = 1; i <= num; i++) {
                result *= i;
            }
            return result;
        }
        std::cerr << "Hata! Negatif bir sayının faktöriyeli hesaplanamaz.";
        return std::numeric_limits<double>::quiet_NaN();
    }
};
