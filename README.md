# BSDateConverter

A .NET Standard 2.0 library for converting between Bikram Sambat (BS) and Gregorian (AD) calendar dates.

## Features

- Convert Bikram Sambat dates to Gregorian dates
- Convert Gregorian dates to Bikram Sambat dates
- Supports BS years 1975-2099 (AD 1975-2043)
- Embedded date mapping data for accurate conversions

## Installation

```bash
dotnet add package BSDateConverter
```

Or add the BSDateConverter package to your project or reference the library directly.

## Usage

```csharp
using BSDateConverter;

// Convert BS to AD
string bsDate = "2086-06-05";
DateTime adDate = DateConverter.ConvertBSToAD(bsDate);
Console.WriteLine($"BS {bsDate} converts to AD {adDate:yyyy-MM-dd}");

// Convert AD to BS
string bsBack = DateConverter.ConvertADToBS(adDate);
Console.WriteLine($"AD {adDate:yyyy-MM-dd} converts back to BS {bsBack}");
```

## Output Example

```
BS 2086-06-05 converts to AD 2029-09-21
AD 2029-09-21 converts back to BS 2086-06-05
```

## API Reference

### ConvertBSToAD(string bsDate)
Converts a Bikram Sambat date to Gregorian DateTime.
- **Parameter**: `bsDate` - BS date in "YYYY-MM-DD" format
- **Returns**: `DateTime` - Corresponding Gregorian date

### ConvertADToBS(DateTime adDate)
Converts a Gregorian DateTime to Bikram Sambat date string.
- **Parameter**: `adDate` - Gregorian DateTime
- **Returns**: `string` - BS date in "YYYY-MM-DD" format

## Author

Avishek Dahal (AVIDA)

## License

This project is available for use in .NET applications requiring Nepali calendar functionality.