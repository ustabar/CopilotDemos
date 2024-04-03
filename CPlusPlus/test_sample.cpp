#include <cassert>
#include "sample.cpp"

void test_calculator() {
    Calculator calculator;

    // Test addition
    assert(calculator.add(2.5, 3.5) == 6.0);

    // Test subtraction
    assert(calculator.subtract(5.0, 2.0) == 3.0);

    // Test multiplication
    assert(calculator.multiply(2.0, 3.0) == 6.0);

    // Test division
    assert(calculator.divide(10.0, 2.0) == 5.0);
    assert(calculator.divide(10.0, 0.0) != calculator.divide(10.0, 0.0)); // Check for NaN

    // Test square root
    assert(calculator.squareRoot(9.0) == 3.0);
    assert(calculator.squareRoot(-9.0) != calculator.squareRoot(-9.0)); // Check for NaN

    // Test factorial
    assert(calculator.factorial(5.0) == 120.0);
    assert(calculator.factorial(-5.0) != calculator.factorial(-5.0)); // Check for NaN
}

int main() {
    test_calculator();
    return 0;
}