dotnet restore "../UnitConversion/"
dotnet restore "../UnitConversionTests/"

dotnet build "../UnitConversion/"
dotnet build "../UnitConversionTests/"

dotnet test "../UnitConversionTests/"

dotnet pack "../UnitConversion/project.json" --configuration=release --output="./"