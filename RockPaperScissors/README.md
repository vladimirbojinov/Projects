# Rock Paper Scissors
This is a two players games where they choose one of these options **rock, paper and scissors**.  

# About the project
The project is writen entirely in C# and the game is **console based**.  
The project aim to recreate the game but with only one player, the second player is the computer.  
Then the player have to choose one of three optons to beat the computer.

# How does the code work
First the computer choses one of the three options.  
Then a cycle is started which ends when the player writes `stop`.  
After that the player is being asked to choose one of the options.
The valid inputs of the player are:  

 `Rock, rock, r`  
 `Paper, paper, p`  
 `Scissors, scissors, s` 

Then a series of checks that are based on the table below makes shure who is the winner at the end.
   
| Player | Computer | Results |
| --- | --- | --- |
| Rock | Scissors | Win |
| Paper | Rock | Win |
| Scissors | Paper | Win |
| Rock | Paper | Lose |
| Paper | Scissors | Lose |
| Scissors | Rock | Lose |
| Rock | Rock | Draw|
| Paper | Paper | Draw |
| Scissors | Scissors | Draw |

# Picture of the game
![image](https://github.com/vladimirbojinov/Projects/assets/133802678/fa6571c5-b1c7-4168-a65a-31706fdf63fd)


| [Link to the source code](Program.cs)
