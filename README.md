
# RomanNumerals

**RomanNumeral** is a C# class library that facilitates seamless conversion between Roman numerals and numeric values within a single type.

## Features
 - **Conversion Methods**: Easily convert Roman numerals to numeric values (`RomanToNumeric`) and numeric values to Roman numerals (`NumericToRoman`).
 - **Arithmetic Operations**: Supports basic arithmetic operations (`+`, `-`, `*`, `/`) on Roman numeral objects.
 - **Increment and Decrement**: Provides increment (`++`) and decrement (`--`) operators for Roman numeral objects.
 - **Validation**: Validates the correctness of Roman numeral strings and numeric values.
 - **Range Constants**: Includes constants defining minimum and maximum valid numeric and Roman values.
 - **Try Methods**: Methods (`TryRomanToNumeric`, `TryNumericToRoman`) for attempting conversions and handling errors gracefully.
 - **Comparison and Equality**: Implements interfaces for comparison (`IComparable<RomanNumeral>`) and equality (`IEquatable<RomanNumeral>`) operations.

## Usage
1. **Initialization**:
   ```csharp
   RomanNumeral romanNumeralA = new RomanNumeral(123); // Initialize from numeric value
   RomanNumeral romanNumeralB = new RomanNumeral("IV"); // Initialize from Roman numeral string
   ```

2. **Conversion**:
   ### Roman to Numeric:
   To convert a Roman numeral string to a numeric value, use the `RomanToNumeric` method:
   ```csharp
   ushort numericValue = RomanNumeral.RomanToNumeric("XVI"); // Result: 16
   ```

   ### Numeric to Roman:
   To convert a numeric value to a Roman numeral string, use the `NumericToRoman` method:
   ```csharp
   string romanValue = RomanNumeral.NumericToRoman(456); // Result: "CDLVI"
   ```

   These methods provide straightforward conversions between Roman numerals and numeric values, ensuring accuracy and validity within the defined range.

3. **Operators**:
   ```csharp
   RomanNumeral result = romanNumeralA + romanNumeralB; // Addition
   RomanNumeral result = romanNumeralA - romanNumeralB; // Subtraction
   RomanNumeral result = romanNumeralA * romanNumeralB; // Multiplication
   RomanNumeral result = romanNumeralA / romanNumeralB; // Division
   ```

4. **Validation**:
   ```csharp
   bool isValidRoman = RomanNumeral.IsValid("MMXIX"); // Check if a Roman numeral string is valid
   bool isValidNumeric = RomanNumeral.IsValid(3999); // Check if a numeric value is valid
   ```
