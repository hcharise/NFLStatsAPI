# NFLStatsAPI

This network-connected command-line program allows the fetching, deserializing, and displaying of statistics from NFL games in the 2020 season. The system connects to an API, retrieves JSON data, and presents the information in various formats.
The second iteration of this project, [NFLStatsGUI](https://github.com/hcharise/NFLStatsGUI), has simplified functionality but an improved user experience.

This project was completed by Hannah Ashton in March 2025 for Syracuse CSE 681 Software Modeling with Professor Gregory Wagner.

## Overall Structure

The overall structure consists of various classes and their interactions. Below is a high-level breakdown of the classes and their interactions.

<img width="500" alt="image" src="https://github.com/user-attachments/assets/2612fcaa-a205-4e53-a58f-ec688cb5d41d"/>

### Data Structures

The data structures used to store the data are designed around the structure of the JSON file containing the original statistics. The classes and objects are directly influenced by the structure of the data to ensure smooth deserialization and access.

1. **TeamMatchUpsThisSeason**: A list representing different matchups (games) for that team from the 2020 NFL season, as provided by the API.
2. **MatchUpStats**: Each game in the season is represented by a `MatchUpStats` object that holds general statistics for the game, such as the date, home team, visiting team, etc.
3. **TeamStatsThisMatchUp**: Each `MatchUpStats` object contains two `TeamStatsThisMatchUp` objects, one for the home team and one for the away team. These objects contain game-specific statistics for the respective teams, such as passing yards, penalties, and scores.

### Program Flow

1. **Program** (Entry point)
   - Initializes dependencies.
   - Triggers data loading.
   - Starts the command-line menu.

2. **JsonHandler**
   - Uses a queue to asynchronously fetch 32 JSON files via network.
   - Deserializes JSON into structured data objects.

3. **TeamHandler**
   - Acts as a manager to access team and game statistics.
   - Interacts with deserialized data (in TeamMatchUpsThisSeason, MatchUpStats, and TeamStatsThisMatchUp) and provides stats to the menu.

4. **MenuHandler**
   - Presents options to the user:
     - View all team records.
     - View one team's stats across the season.
     - View one team's stats in one game.
   - Handles invalid input and guides users accordingly.
  
## Network Connectivity

Network connectivity is a crucial part of this system for fetching data from an external API. The system uses the `System.Net.Http` namespace to establish an HTTP connection to the API endpoint.

The URL for the API is constructed based on the team's number and game number, directing the system to the appropriate JSON file. This file is then read, deserialized, and stored in the relevant data structures.

API URL: [https://sports.snoozle.net/search/nfl/index.jsp?](https://sports.snoozle.net/search/nfl/index.jsp?)

## Asynchronous/Multicore Computing

To increase efficiency, the system uses asynchronous programming to fetch and format data, speeding the retrieval of the data from all 32 teams.

<img width="800" src="https://github.com/user-attachments/assets/2c681abe-6bd9-49b6-9620-8ecc5ed1710b"/>


## 📦 Features

- **Loads data from 32 team JSON files** (fetched via network).
- **Deserializes and structures the data** for quick and flexible access.
- **Menu-driven interaction** to:
  - View the season record of all teams.
  - View detailed stats for all games of a selected team.
  - View specific matchup stats for a team in a specific game.
- **Robust error handling** to gracefully manage invalid input.
<img width="900" alt="image" src="https://github.com/user-attachments/assets/77f094b3-dd0e-4571-8228-f5faf00ab2d1" />
<img width="600" src="https://github.com/user-attachments/assets/549c9524-2ec8-48c7-a920-10afc3a6e846"/>

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/NFLStatsGUI.git
   ```
2. Open the project in Visual Studio.

3. Build and run the project.


