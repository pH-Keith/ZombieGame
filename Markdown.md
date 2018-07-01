# RoguelikeRPG

* António Louro - a21702439

## Phase Implemented
I have implemented up to phase 2, although there are some inconsistent bugs with the movement.


## The solution
I created a GameLoop that would handle the looping of the program, the GameManager would then handle all of the turn handling and etc.
In each grid there are tiles and in each tile there is always 1 agent. This agent is either "empty" by using the variable "exist" or he has something, he will always store data on the backend but the renderer is dedicated to differentiating these tiles using the variable "exist" like said before. It will also know what to print thanks to a function in Agent which gives its string in not only id in hex but also the specified type of user. Via coloring easily distinguishing between them.

### Architecture

The project is separated by 9 files, all of which have their own uses without much overlapping, all of them are classes and none of them are interfaces. As i decided to work with the agents without any hierarchy which in the end did complicate some parts and bloat the class in the end.
### Algorithms
UML of the Program:

`![](image1.png)`
Fluxogram of the gameLoop:
`![](image2.png)`
## User guide

The controls are shown at the left when describing the area, however you use Q W E A Z X C D for all 8 cardinal directions. Pay attention to the bottom where it says which Agent is being controlled to not get confused!

## Conclusions
This work really showed me to be a lot more careful on how to handle big classes and data management. Iv spent most of the time debugging a few issues because of one small mistake which pilled on, due to me not understanding it. For example earlier on while making the programing i was stupidly accidentally creating pointers to objects of the same class, instead of what was intended, most of the times i just wanted do a copy of said object but instead i created pointers. Only later did i find a solution to this problem via trial and error. Another big lesson i took is that even when working alone git can actually be quite helpful, i suffered in this work for not using it. At one point after doing a lot of code and not testing it i accidentally broke something else and i could not undo to said point where it used to work. Making me waste even more time than i wanted, making me annoyed that if i had pushed a stable build to git i could download it and see what i had done wrong.
Another thing iv learned is that using methods to change values is a lot cleaner than using said variables in public, it created a problem in my code specially when it came to its coordinates and states.

## References

* <a name="ref1">\[1\]</a> Pereira, A. (2017). C e Algoritmos, 2ª edição. Sílabo.
* <a name="ref2">\[2\]</a> https://stackoverflow.com/questions/273313/randomize-a-listt
 * <a name="ref2">\[3\]</a> https://stackoverflow.com/questions/4690480/int-to-hex-string-in-c-sharp

