
# HR Scheduling & Biometric Attendance System

Un système de pointage biométrique complet avec gestion des employés, planification des horaires et contrôle des accès. Développé en **C# WinForms** avec une architecture en **couches classiques**.

## Structure du projet

```
    HRSchedulingSystem
├── Data/
│   └── DatabaseHelper.cs         # Connexion et exécution des requêtes SQL
├── Models/
│   ├── BiometricModels.cs        # Modèles liés aux logs biométriques
│   └── DatabaseModels.cs         # Entités : Employé, Société, Shift, etc.
├── Services/
│   ├── AbsenceService.cs
│   ├── DepartementService.cs
│   ├── EmployeeService.cs
│   ├── PointeuseManager.cs       # Gestion des appareils ZKTeco
│   ├── ProgrammeService.cs       # Gestion des programmes horaires
│   ├── ServiceService.cs
│   ├── ShiftService.cs
│   ├── SocieteService.cs
│   └── ZktecoService.cs          # Intégration SDK CZKEM
├── Forms/
│   └── (Toutes les interfaces WinForms)
├── MainForm.cs                   # Fenêtre principale
└── Program.cs                    # Point d'entrée de l'application
```

## Architecture

Le projet suit une architecture en **couches classiques** :

```mermaid
graph TD
    UI["🖥️ Forms"]
    Services["⚙️ Services"]
    Models["📦 Models"]
    DAL["🗃️ Base de données"]

    UI --> Services
    Services --> Models
    Services --> DAL
    Models --> DAL
```

## Diagramme de classe

<img width="808" height="751" alt="image" src="https://github.com/user-attachments/assets/92e9ce28-40b6-479a-856f-f0fc6285cd86" />


## Fonctionnalités

- 📌 Pointage biométrique via **SDK ZKTeco**
- 👨‍💼 Gestion des employés, services, départements, sociétés
- 🗓️ Planification d’horaires avec **deux shifts par jour**
- 📊 Export de rapports en **PDF/Excel**

## Technologies utilisées

- 💻 WinForms (.NET 8.0)
- 🛢️ SQL Server 
- 🧰 SDK ZKTeco (CZKEM)
- 📦 Dapper (accès base de données léger)
- 📄 ClosedXML (exports Excel)

## Lancement

1. Ouvrir la solution dans **Visual Studio**.
2. Configurer la chaîne de connexion SQL dans `DatabaseHelper.cs`.
3. S'assurer que les DLLs du SDK **ZKTeco** sont présentes (`zkemkeeper.dll`).

## Capture d'écran

- 💻 Main Form:
![i1](https://github.com/user-attachments/assets/c8738ef0-5004-44d7-a144-ffa8e22b99c0)
- 💻 Collecting Attendance Form:
![i11](https://github.com/user-attachments/assets/304c00a4-5e09-411f-b52e-11405463f17b)


## 🤝 Auteurs

- **Mostafa** 
- Projet de fin d’études – ESTG - 2025
