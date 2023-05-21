# Rock Paper Scissors
This is a two players games where both players choose **rock, paper and scissors**.  
In this case its a player against a computer and the player is trying to beat the computer.

# About the project
The project is writen entirely in C# and the game is **console based**.  

The valid inputs of the player are:

 - `Rock, rock, r`
 - `Paper, paper, p`
 - `Scissors, scissors, s`

Based on the output on the player and computer this may be the results  
   
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

# How does the code work
There is a series of checks that make shure that the output of the code is correct.  
To make the expirience with the program easyer so you dont wait the program to start again everytime you type your turn, there is a cycle which is waiting the player to type `stop` and then the program will end.

[Link to the code]()
