![image](https://github.com/user-attachments/assets/587c8a25-ff65-4b5a-83c5-653e1685db06)


# ShadowCaster
## ⚡ Overview
ShadowCaster is a lightweight and dynamic object-to-object mapper designed to map data between types seamlessly using reflection. It supports flexible mapping strategies and customizable property transformations.

### 🚀 Features
🔄 Dynamic Object Mapping: Easily map properties from one object to another.\
🏷️ Case-Sensitive Property Mapping: Transform property names to uppercase, lowercase, or leave them unchanged.\
🛠️ Flexible Mapping Strategies:
ByProp: Direct object property-to-property mapping.
KeyValue: Property mapping from a key-value dictionary.

### 📦 Installation
Just clone or include the ShadowCaster class in your project. No external dependencies are required.

## 📖 Usage
### 🔷 1. Mapping Between Objects (ByProp)
```
var tiger = new Tiger("Simba", 3, "Yellow");
var caster = new Caster();
var lion = caster.AsDestination<Lion>(tiger, ShadowType.ByProp);

Console.WriteLine($"Lion Name: {lion.Name}, Age: {lion.Age}, Color: {lion.Color}");
```
### 🔷 2. Mapping from a Dictionary (KeyValue)
```
var sourceDict = new Dictionary<string, object?>
{
    { "Name", "Simba" },
    { "Age", 3 },
    { "Color", "Yellow" }
};

var caster = new Caster();
var lion = caster.AsDestination<Lion>(sourceDict, ShadowType.KeyValue);

Console.WriteLine($"Lion Name: {lion.Name}, Age: {lion.Age}, Color: {lion.Color}");
```
### ⚙️ API Documentation
```🔹 Caster.AsDestination<TDestination>()```
Executes the mapping process from the source object to create a new instance of the destination type.
```
Parameters
source (object): Source object to map from.
shadowType (ShadowType, optional): Mapping strategy. Default is ByProp.
characterCasing (CharacterCasing, optional): Specifies character casing rules (Normal, Lower, or Upper). Default is Normal.
Returns
Mapped destination object of type TDestination.
```
### 🗂 Enumerations
🔹 ShadowType Defines mapping strategies:
```
 ByProp: Maps properties between objects.
 KeyValue: Maps properties from a key-value dictionary.
```
🔹CharacterCasing
Defines character casing rules:
```
Normal: Keeps property names unchanged. 
Lower: Converts property names to lowercase.
Upper: Converts property names to uppercase.
```
### ⚠️ Error Handling
```
Throws InvalidOperationException for unsupported source types.
Throws InvalidCastException when the source object is null or incompatible.
```
### 👨‍💻 Contributing
Feel free to submit issues or create pull requests to enhance ShadowCaster.
