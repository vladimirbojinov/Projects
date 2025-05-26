# About the game
The game is the classic snake game and it goal is to eat food and expand without colliding in the snake body or the walls

# About the project
The project aims to recreate this classic game   
The whole project is based on the console and its written on C#

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
- it check if the player pressed anything and if he did it registers it and clears anything else because he could holding the key
- it calls **PreventReverseDirection**
- it calls **MoveLogic** and checks if the move was done if not it ends the cycle
- after that it updates the screen and menu
- at the end there is a pause so the snake wont be going too fast
## PreventReverseDirection
This method role is to prevent ilegal moves which are 180 degree turns  
Its working by checking if this key can be reversed then it checks if that move was ilegal and if it is it corrects it
## GenerateFood
This method is generating food for the snake  
Its working by using the Random class and then it generates a random position in the field and if that position contains snake it continues to do so until there is no snake at that position
## MenuConsolePrint
Prints on the console the menu beneath the game  
Its working by printing the points and separating symbols in a way that is the same width as the gamefield width
## MoveLogic
This method is resposible for the movement of the snake and it returns if the move was successful  
This method works by:
- checking in which direction the snake is moving
- using the **directionMap** the new direction of the snake is calculated
- it checks if the new position of the snake is a collision in the snake
- it checks if the position contains food and if its true:
  - it generates new food
  - grand the player points
  - if the points could be devided by 10 it increase the speed of the snake
- it cheks if the position is between the borders and if true:
  - it moves the snake and prints the new location of the snake body
  - if false it returns that the move was unsuccessful
### IsKeyValid
This method checks if the key is valid
This method works by checking if the key is in **validKeys** which contains all the valid keys
