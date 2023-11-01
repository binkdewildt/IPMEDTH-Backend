# IPMEDTH Backend

## Domain Layer

De applicatie heeft een tussenlaag voor de communicatie met de database, dit gebeurt in de “IPMEDTH.Domain” library. Deze bestaat uit repositories, services, models en entities. Voor het aanmaken van een nieuwe tabel, dienen deze nieuw aangemaakt te worden.

### Repositories

Hierin gebeuren de daadwerkelijke interacties met de database, zoals het opslaan of het bijwerken van een entity.

Er is een basis repository, “Repository.cs”, deze bevat al een aantal basis functionaliteiten, bijvoorbeeld het ophalen van entities.

Wanneer er andere functionaliteit aan een bepaalde functie moet worden toegevoegd zal de functie overschreven moeten worden door middel van een “override”.

### Services

Hier gebeurt alle tussenwerk, bijvoorbeeld het bijwerken van bepaalde properties en het omzetten van een model naar een entity.

### Models

De models die in de rest van de applicatie gebruikt kunnen worden.

### Entities

Dit zijn de classes die in de database worden opgeslagen, hier dienen dus ook bepaalde validatie punten aan toegevoegd te worden (bijv. ‘Required’ of ‘MaxLength’).

De desbetreffende repository zorgt voor het opslaan van deze entity.

## Database diagram

Hieronder is de huidige database diagram te vinden.

[A Free Database Designer for Developers and Analysts](https://dbdiagram.io/d/IPMEDTH-6542556a7d8bbd6465478b4c)

## Branches

Wanneer je gaat werken aan nieuwe functionaliteit doe je dit door een nieuwe branch aan te maken. Wanneer deze gemerged wordt met de main branch zal deze automatisch live gaan. **Wel dien je er zeker van te zijn dat de Unit Tests goed runnen!**
