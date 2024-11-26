# Team 8 - James Li 100876994
I am working alone for this assignment so my contribution is 100%. All the models and code are created by me.

# Design Pattern Improvements

Factory
- With the addition of the flyweight projectiles, the [ammo factory](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/WeaponFramework/Factories/ProjectileFactory.cs) now has the option to spawn [flyweight](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/WeaponFramework/BulletFlyweight.cs) or the [original projectiles](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/WeaponFramework/Bullet.cs) which helps me with showing the performance impact when I'm doing the profiling part
- Originally, had factories for the [Weapons](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/WeaponFramework/Factories/WeaponFactory.cs) and [Alerts](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/WeaponFramework/Factories/AlertFactory.cs)

Observer
- No changes
- Used to [notify](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/UserInterface/HUD/AlertObserver.cs) HUD when [player is out of ammo](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/WeaponFramework/ObserversAndSubjects/WeaponSubject.cs)

Command
- No changes
- Reiterating, it was used to [store equipped weapons](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/WeaponFramework/Commands/EquipCommand.cs) for undoing
- [Stored in a list so that I could limit the undo steps](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/CommandPattern/CommandInvoker.cs)

Singleton
- No changes
- [HUD Manager](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/UserInterface/HUD/HUDManager.cs) and [Item Manager](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/WeaponFramework/ItemManager.cs)
- Useful because I want easy access to them similar to that of static classes, but static classes can't have serializable fields 
- They use serializable fields for me to hold game objects like weapons, attachments, ammo types, and menus for other classes to access

Optimization
- Flyweight bullet takes values from [AmmoType scriptable object](https://github.com/JzmingLi/ShooterFramework/blob/main/Assets/Scripts/WeaponFramework/ScriptableObjects/AmmoType.cs)

DLL
- I created a C# DLL that contains the methods for calculating recoil
- Theoretically this would allow the recoil behaviour to be changed through changing the DLL

Profiling
- Flyweight reduced bullet script memory usage by 8 bytes


# The Scenario
The purpose of the scenario is to provide a demo for a feature-rich, reusable FPS game framework I'm creating for the individual project assignment in GDW 5. 
The framework itself is the focus of the scenario, having features such as a modular weapon system and varying types of ammunition.
The user lacks a concrete goal to accomplish, but the scene will provide item spawners and dummies to allow them to explore the framework’s features.
The final build only has weapon customization, procedural recoil, and shooting and aiming.

![ShooterFramework drawio (4)](https://github.com/user-attachments/assets/b63b5962-a9f8-4ebe-9439-3e0a3b9ea05c)
