## Développement .NET C# | TP Noté - Programmation ContactManager

**Enseignant :** Maxence LAURENT

**Années :** 2022 - 2023

**Sujet :** ISIMA_Développement-Dotnet-Csharp_2022-2023 -TP-Noté.pdf

**Résumé :** Réaliser une application qui fait une gestion de contacts. L'application est en trois grandes parties : le socle applicatif, la gestion de la persistance des données et la protection par chiffrage de ces données.

**GitFlow:** J'ai travaillé et versionné mon travail avec la technologie Git et l'outil GitHub. J'ai réalisé des `Issues` afin de cadrer mon travail.

---

-> présentation de ma solution
--> ma solution a quatre projets : 
    1. cryptage
    2. serialisaiton
    3. socleapplicatif (le main)
    4. utilities (rangement des objects Dossier, Contact, NoeudGeneral et autres)
-> de mes choix techniques
-> des problèmes que j'ai rencontré (trouver la documentation, choix de la SDD)
-> résolution des problèmes

---

## Socle applicatif

### Description

Structure de données et gestion basique

### Points réalisés

Tous les points initiaux du sujet ont été réalisé ainsi que les points pour aller plus loin. Ma solution nommée `Utilities` contient ainsi :

* un modèle de données pour gérer des objets `Contact` et leurs rangements dans une structure hiérarchique d'objet `Dossier`

* un affichage pour toute la structure

* une gestion des dossiers et des contacts

* la gestion du format d'adresse mail

* la possibilité de créer des éléments dans un parent choisi

### Points intéréssants

-> screenshoot de mon switch dans ma fonction main

-> screenshoot de ma commande help

---

## Sérialisation

### Description

Gestion de la persistance par sérialisation binaire et XML

### Points réalisés

-> utilisation d'un patron de conception



---

## Chiffrage

### Description

Protection du contenu par chiffrage

-> chiffrage avec AES, choix personnel

