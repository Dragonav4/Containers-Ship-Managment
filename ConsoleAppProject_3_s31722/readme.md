# Container & Ship Management System ⚓

## Overview
This project is a **console application** designed to manage containers and load them onto **container ships**. You can create different types of containers (liquid, gas, refrigerated), load cargo into them, and place these containers onto ships, taking into account weight, dimensions, and capacity limits.

---

## **Features** 🚀

### **🔹 Multiple Container Types**
- **LiquidContainer** (L) — supports both hazardous and non-hazardous liquid cargo.
- **GasContainer** (G) — stores gaseous cargo under pressure.
- **RefrigeratedContainer** (C) — maintains specific temperature requirements and product types.

### **🔹 Hazard & Overfill Checks**
- ⚠️ An exception is thrown if the cargo exceeds the container’s `MaxPayload`.
- If a container holds hazardous cargo, its loading capacity is restricted to 50% (as per the [IHazardNotifier](#project-structure) implementation).
- Automatic blockage of illegal operations.

### **🔹 ContainerShip Management**
- ⛴️ Each ship has limits on:
    - Number of containers (`MaxContainers`)
    - Total weight (`MaxWeight`)
    - Speed (`MaxSpeed`)
- Ability to **load**, **remove**, **replace**, and **transfer** containers between ships.

### **🔹 Console Interface**
- A user-friendly console interface provides:
    1. Container creation
    2. Ship creation
    3. Loading containers onto a ship
    4. Displaying ship and container information

### **🔹 Error Handling**
- 🛑 Exceptions are thrown when attempting to exceed cargo or capacity limits.
- Optionally, `IHazardNotifier` reports any dangerous events (e.g., when loading hazardous materials).

---

## **How to Run**
1. **Clone** the repository or download the project files.
2. Open the project in your IDE (e.g., JetBrains Rider or Visual Studio).
3. Ensure **.NET** (or a compatible C# environment) is properly configured.
4. Run the project (for instance, Rider → “Run” or `dotnet run` command).
5. The console will display a menu with options to add containers, add ships, load containers onto ships, etc.

---

## **Sample Console Flow**
A sample console session might look like this:

--- Container & Ship Management ---

     1. Add a container
     2. Add a ship
     3. Load a container onto a ship
     4. Display ship information 
     5. Exit

    Choose an option: 1
* Select container type:

      1. Liquid Container
      2. Gas Container
      3. Refrigerated Container 
* Your choice: 2

      * Max payload (kg): 5000 
      * Tare weight (kg): 1000
      * Depth (cm): 100
      * Width (cm): 200
      * Height (cm): 150
      * Pressure (atm): 10

      Container KON-G-1 created successfully!

---
### **Programming Language**
- .NET (application logic)

### **Development Environment**
- JetBrains Rider
---
## **License**
This project is licensed under the MIT License