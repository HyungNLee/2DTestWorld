# Unity - 2D Test World

#### By Ryan Lee

### Implemented 
* Player movement. Added 'player' script which inherits from 'character' script.
  * 10/21/2018 -> Rewrote Move() in 'character' script to use RigidBody2D and .MovePosition instead of transform.Translate to allow usage of colliders to create boundaries.
  * Added dashing functionality with the hotkey 'Space'.
  * Added enum states to character script.

#### Work in Progress Features
* Add sprites to show idle stance of player in direction of player's last movement.

###### Notes
* [SerializeField] -> above a variable allows the variable to be private but still show up in the Unity editor.
* Update functions from parent scripts are able to be overrwritten and then called in the child script to allow ordering of functions. 
  * For example, the Move() from parent 'character' script needs the direction variable value from GetInput() from child 'player' script.
* Use 'protected' access level for variables to allow the variable to be private but also be accessed by children scripts.
* Turn Gravity to 0 in Rigidbody Components.

