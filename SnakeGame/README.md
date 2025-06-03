# About the game
The game is the classic snake game and it goal is to eat food and expand without colliding in the snake body or the walls

# About the project
The project aims to recreate this classic game   
The whole project is based on the console and its written entirely on C#

# How Does the Code Work?
This verision of the game is using multiple classes:  
- *Program* is runing the *GameEngine*  
- *GameEngine* this is the main logic of the program  
- *Player* it stores where each snake part is located at  
- *PlayerField* this is the game field where the snake is located at
## Program
Its main purpose is to start the whole game  
First it shows the controls of the game and it waits for the user to press any button to start the game  
Then the game is started and if the player looses it sends a message and it gives option if we want to restart  
## GameEngine
The methods in it are 
- Run
- PreventReverseDirection
- GenerateFood
- MenuConsolePrint
- MoveLogic
- IsKeyValid
### Run
This is the main method in this class and runs the whole game   
It starts with clearing any prevoius messages then it generates the playerfield, the snake and food for the snake  
Then an infinite loop is started until the player looses the game which does:
- it check if the player pressed anything and if he did it registers it and clears anything else because if the player is holding a key it overloads it and stops regestering key presses until its clear
- it calls **PreventReverseDirection**
- it calls **MoveLogic** and checks if the move was done if not it ends the cycle
- after that it updates the screen and menu
- at the end there is a pause so the snake wont be going too fast
### PreventReverseDirection
This method role is to prevent ilegal moves which are 180 degree turns  
Its working by checking if this key can be reversed then it checks if that move was ilegal and corrects it by giving the reverse key so an iligal move wont happen  
### GenerateFood
This method is generating food for the snake  
Its working by using the Random class and then it generates a random position in the field and if that position contains snake it continues to do so until there is no snake at that position
### MenuConsolePrint
Prints on the console the menu beneath the game  
Its working by printing the points and separating symbols in a way that is the same width as the gamefield width
### MoveLogic
This method is resposible for the movement of the snake and it returns if the move was successful  
This method works by:
- checks in which direction the snake is moving
- using the **directionMap** the new position of the snake is calculated
- checks if the new position of the snake is a collision in the snake
- it checks if the position contains food and if its true:
  - it generates new food
  - grand the player points
  - if the points could be devided by 10 it increase the speed of the snake until certain speed is hit and after that its skiped because the game will be unplayable because of the snake speed
- cheks if the position is between the borders and if true:
  - it moves the snake and prints the new location of the snake body
  - if false it returns that the move was unsuccessful
### IsKeyValid
This method checks if the key is valid  
This method works by checking if the key is in **validKeys** which contains all the valid keys
## Player
The purpose of this class is to store the location of each body piece of the snake and calculate how the body is changed after each move by using the **Move** method  
Its main structure is a Queue and the first element of the collection is the Tail and the last is the Head  
### Move
When its called it registers where the head and the tail will be located at
It works by first checking if the snake has eaten and if it has it should not decrese the snake body after that it stores the new location of the Head and Tail
## PlayerField
The purpose of this class is to store all the data where everything is at
The main structre is a 2D array
### Fill
Its filling the field with the chosen background and border chars
### ConsolePrint
Its printing the 2D array
### ChangeAt
This method is overloaded and its working either with Tuple or with given row and col and it changes at the choosen position
### GetFieldRows and GetFieldCols
Their main purpose is for readability and also to minimize the risk of an error because the original syntaxis is GetLength(0/1) and it could lead to an error when typing it
