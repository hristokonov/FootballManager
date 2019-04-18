PROJECT NAME: Football Manager
==============================

TEAM NAME: TEAM Sharp
=====================

TEAM LEADER: Hristo
===================

TEAM MEMBERS: Peter
===================

Project Information
===================

Creating a Football Manager which is console application that simulates footbal games.
The applications has features that allows to create players,teams,stadiums,
managers,leagues and play matches in the leagues.




Database
========

We are using database to save the data of this console application.
Our database consist of 7 tables.There are two types of relation in the database
One-To-One and One-to-Many.The tables are Positions,Managers,Players,Teams,Leagues,
Stadiums and Matches.One-To-One relation is between tables Teams and Managers.
All the rest relations between the tables are One-to-Many.Table Matches has Many-to-One relation with 
table Leagues and has two One-to-Many relation with table Teams and Many-to-One with table Stadiums.
Initially when creating the database we have added to it positions,stadiums,leagues,teams to one league(Primer),
players to the teams,managers to the teams.

![DB_Diagram](https://imgur.com/a/py6U0gj)

Commands
========
- createleague-Creates new league;
- createmanager-Creates new manager;
- creatematches-Creates all teh mathces in a certain league;
- createplayer-Creates new players which are available for buying;
- createstadium-Creates new stadiums;
- createteam-Creates new teams with a budget;
- deletematches-Delete all matches in the table matches in the database.
  This is done so we can run the league matches again.
- retireplayer-This makes one player unavailable for use.It is flagged as deleted.
- addteamleague-This adds team to certain league and resets all the team data,
  such as goals scored,goals conceded,points and goaldifference.
- buyplayer-Team buys a player from the pool of players that doesn't have a team.
  The transaction will be complete if the team have enough money to buy the player.
- firemanager-Teams fire their manager.
- hiremanager-Teams hire a new manager.
- playallmatches-This command plays all matches in a league,after they are created.
  The result is depending on the ratings of all the football players in the team.
- resetteamsdata-Resets all the team data,such as goals scored,goals conceded,points and goaldifference.
- exportplayerstopdf-This command exports all players to PDF file orderby player rating.
- showallleaguematches-Shows all matches in the league.
- showplayers-Shows all the players.
- showplayerstobuy-Shows only players availeble for buying,not players in a team or retired players.
- showtable-Shows the league table,with rankings,goals scored,goals conceded and goaldifference.
- showteam-Shows the team information,such as owner,remaining budget and etc.
- showteamplayers-Shows all the players of a certain team.
- showallleagues-Show all leagues in the database.

Future Development
==================

Our plan for the web application is to further enhance this football manager.
We will replace the manager wit users which can create their teams,buy players,
create their own stadiums.There will be also admin account which will create the leagues,
create players.

Link to Trello
==============
https://trello.com/b/kLZZFJso/sports-ranking
https://BurndownForTrello.com/share/afqs4j91pl




