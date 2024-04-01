// 1- Format the code
// 2- Simplify the code
// 3- Add comments to the code

// Chat Window
// 4- can you give me a list of common functions that a calculator might have

// 5- add a square root function and handle any errors

// 6- @workspace /tests generate unit tests for Calculator class in #file:sample-format-code.cpp as a separate file

#include <iostream>
#include <cmath> // Include the cmath library for NaN

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
        else {
            std::cerr << "Error! Division by zero is not allowed.";
            return std::numeric_limits<double>::quiet_NaN();
        }
    }

    double squareRoot(double num) {
        if (num >= 0) {
            return std::sqrt(num);
        }
        else {
            std::cerr << "Error! Cannot calculate square root of a negative number.";
            return std::numeric_limits<double>::quiet_NaN();
        }
    }
};
