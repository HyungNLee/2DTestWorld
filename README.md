# Unity - 2D Test World

#### By Ryan Lee

### Implemented 
* Player movement. Added 'player' script which inherits from 'character' script.

#### Work in Progress Features
* Add sprites to show idle stance of player in direction of player's last movement.

###### Notes
* [SerializeField] -> above a variable allows the variable to be private but still show up in the Unity editor.
* Update functions from parent scripts are able to be overrwritten and then called in the child script to allow ordering of functions. 
  * For example, the Move() from parent 'character' script needs the direction variable value from GetInput() from child 'player' script.


