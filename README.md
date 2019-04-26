# tictactoe-server
A .NET back end server for playing tic-tac-toe


# Tasks List

## General tasks:
1) Create Github Repo [done]
2) Deploy the game in a server so that it can be played online [partially done].
3) Don't use more than 5 hours in development (good aesthetics, symbol selection, partial time tracking, code efficiency and bug fixing are to be sacrificed in order to attempt to obtain a working product) [done].

## Backend (the current repo)
1) Create the basic game api
	- [done] NewUser(userName) // oversimplified user creation
	- [done] NewGame(userId, userId, p1_symbol) // Creates a new game in the database. P2 will always be the computer for now.
	- [done] Move(gameId, playerId, x, y) // validates and performs movement, returns result. It's a game updater.
	- [done] GetGame(gameId) // returns an existing game
	- [not done] GetGames (userId) // Returns the list of games for this user (optional so far)
2) Create AI
	- [done] AI will execute upon calling the Move() web service if player2 is either null or matches the computer.
	- [done] First it's needed to check if there are any available moves. If so, check which is the best possible move or at least ramdomize a movement for the computer.
	- [done] Persist the computer movement along with the user's and return the current board status.
3) [not done] Polish AI capabilities
4) [not done] Add logging compatibility
 
## Frontend (https://github.com/hauptkonto/tictactoe-client/tree/develop):
1) Create an angular app that calls the back en service
	- [done] Create the app
	- [done] Add a service that calls the api
	- [done] Add an oversimplified user component
	- [done] Add a board component
2) The player must be able to choose the symbol to be used ("X" or "O")
	- [not done] Add a simple symbol choosing component
3) The option to create a new game or resume an old one must be available.
	- [not done] Add a component that lets the user put the gameId to resume an old game
4) Time tracking must be available.
	- [not done] show a timer in the upper corner but keep track of time in the back end.

## Persistence (SQL): 
1) [done] SQL query for creating the Users and Games tables:
	USE [tictactoe]
	GO

	CREATE TABLE Users (
		Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
		Name VARCHAR(512) NOT NULL
	)
	GO

	CREATE TABLE Games (
		Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
		Player1Id UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Users(Id),
		Player2Id UNIQUEIDENTIFIER NULL FOREIGN KEY REFERENCES Users(Id),
		Symbol VARCHAR(1) NOT NULL, -- Symbol to be used by player 1
		StartDateTime DATETIME NOT NULL,
		LastUpdated DATETIME NOT NULL,
		EndDateTime DATETIME NULL,
		Status VARCHAR(255), -- "ongoing", "p1Won", "p2Won", "draw",
		Board VARCHAR(255)
	)
	GO

2) Deploy database, front and back end to AWS [partially done]:
  - I managed to deploy a partially working version with some bugs and not many good practices (which was done to cut the development time as much as possible). However, none of those compoents can communicate with each other (yet). There's some misconfiguration that doesn't allow them to communicate.
  - The links where the app is deployed are:
  FrontEndApp: ec2-18-219-194-195.us-east-2.compute.amazonaws.com
  BackendServer: ec2-18-219-194-195.us-east-2.compute.amazonaws.com:8080 (Must first be started within the server. It's not configured to automatically run as a service. That's work yet to be done).
  Database: mydbinstance.c1fitjihlfrq.us-east-2.rds.amazonaws.com (requires a password that I'm not willing to provide right now)
  - Although the game doesn't work in AWS, it can be deployed and properly played in a local environment.
  
