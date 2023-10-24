[![.NET](https://github.com/konak/am.kon.packages.common.json/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/konak/am.kon.packages.common.json/actions/workflows/dotnet.yml)

# JsonCommonExtensions

A utility class providing common JSON serialization and deserialization extensions.

## Usage

### Serialization
```csharp
var myObject = new { Name = "John", Age = 30 };
string jsonString = myObject.ToJson();
```

### Deserialization
```csharp
string jsonString = "{\"name\":\"John\",\"age\":30}";
var myObject = jsonString.ToObject<dynamic>();
```

### Custom Serialization Options
```csharp
var options = new JsonSerializerOptions { WriteIndented = true };
JsonCommonExtensions.Configure(options);
string jsonString = myObject.ToJson(options);
```

### Configuration
Use the JsonCommonExtensions.Configure method to set custom serialization options.
```csharp
var options = new JsonSerializerOptions { WriteIndented = true };
JsonCommonExtensions.Configure(options);
```

This README provides a brief description, usage examples, and configuration instructions for your class.
