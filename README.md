
# 🕒 HR Scheduling & Biometric Attendance System

Un système de pointage biométrique complet avec gestion des employés, planification des horaires et contrôle des accès. Développé en **C# WinForms** avec une architecture en **couches classiques**.

## 📁 Structure du projet

```
📦 HRSchedulingSystem
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

## 🧱 Architecture

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

    style UI fill:#cce5ff,stroke:#3399ff,stroke-width:2px
    style Services fill:#e6ffe6,stroke:#33cc33,stroke-width:2px
    style Models fill:#fff3cd,stroke:#ffcc00,stroke-width:2px
    style DAL fill:#f8d7da,stroke:#dc3545,stroke-width:2px
```

## ✅ Fonctionnalités

- 📌 Pointage biométrique via **SDK ZKTeco**
- 👨‍💼 Gestion des employés, services, départements, sociétés
- 🗓️ Planification d’horaires avec **deux shifts par jour**
- 📊 Export de rapports en **PDF/Excel**

## 🛠️ Technologies utilisées

- 💻 WinForms (.NET Framework)
- 🛢️ SQL Server (ou SQLite)
- 🧰 SDK ZKTeco (CZKEM)
- 📦 Dapper (accès base de données léger)
- 📄 ClosedXML, QuestPDF (exports Excel et PDF)

## 🚀 Lancement

1. Ouvrir la solution dans **Visual Studio**.
2. Configurer la chaîne de connexion SQL dans `DatabaseHelper.cs`.
3. S'assurer que les DLLs du SDK **ZKTeco** sont présentes (`zkemkeeper.dll`).
4. Exécuter le projet (`F5`).

## 📷 Capture d'écran

> *(Ajouter ici une ou deux images montrant l'application en fonctionnement)*

## 🤝 Auteurs

- **Mostafa** 
- Projet de fin d’études – ESTG - 2025

## ⚖️ Licence

Ce projet est privé pour usage académique uniquement.  
