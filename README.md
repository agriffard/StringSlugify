# StringSlugify

Lightweight string slugifier for .NET. Converts text into URL-friendly slugs.

## Install

```bash
dotnet add package StringSlugify
```

## Usage

```csharp
using StringSlugify;

Console.WriteLine("Café crème au lait!".ToSlug()); // "cafe-creme-au-lait"
```

## Features
- Removes accents/diacritics
- Lowercases invariant
- Collapses spaces/dashes to single `-`
- Trims leading/trailing `-`
- No external dependencies

## Target Frameworks
- `netstandard2.0`
- `net8.0`

## Build and Pack

```bash
dotnet build -c Release
# Package is produced during build because GeneratePackageOnBuild=true
# Find the .nupkg and .snupkg under: src/StringSlugify/bin/Release
```

## License
MIT
