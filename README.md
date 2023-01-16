# Simple Spell System

Player README

The game is more of a gymnasium where you can test out custom spells with custom stage ordering and modifiers.
Note: The Split stage will not split if it is the end stage, as the splitting actually happens as it exits the stage.


Controls:
W/S : Move forward or backwards  
Mouse: Turn camera left or right  
Space: Fire current spell  
Escape: Open the spell crafting menu  
Alt+F4: Done!  

Stages:
- List Upwards: Gently increase upward direction
- Turn Up: Immediately increase upward direction
- List Down: Gently increase downward direction
- Split: Split into 3 separate spells. The following effects will apply to each spell individually (modifiers and stages are copied)
- Trail: Leave behind a trail of simple spheres that disappear when the stage has finished.

Modifiers:
- Speed Up: Increases the speed of the projectile, but reduces the amount of time that it will remain active.
- Gravity: Adds a heavy force downward - can be combined with stages to 'smooth' them out.
- +Lightning Dmg: Trades out 50% of current Raw damage for Lightning damage.

# Critical Questions
```
  Analyze your usage of the behavior pattern.
    Which one did you choose? Why
      My code revolved heavily around the Subclass Sandbox pattern - perhaps strangely combined with the Prototype pattern. All stages and modifiers were children of abstract classes that provided both interfaces for the Spell to use as well as base functionality for things such as accessing the current spell. It also allowed for copying, which came in handy for the split Spell stage (Assets/Scripts/Modifiers/Split.cs).

  Analyze your usage of other patterns
    What pattern(s) did you use the most?
      How did you implement it/them?
        Would you do it differently? Justify your answer!

        I used the subclass sandbox and prototype patterns the most, but I also used the observer pattern in order to convey information between systems that otherwise would not be easy to interact between. The best example of this is the Spell Shooter class that lives on the player (Assets/Scripts/SpellShooter.cs), which utilizes the observer pattern to determine when the player wishes to cast a spell.

    What pattern was the most critical to your design?
      How is this pattern the most critical?
      How could you do it differently?

      Certainly the subclass sandbox and prototype patterns. Without them, I don't think my system could be as easily robust as well as simple to implement new functionality.

  What valuable information did you learn for yourself while doing this project?
    What did you find difficult?
      Unfortunately, using a prototype pattern kind of came back to bite me in the fact that every single stage required a chunk of boilerplate code for creating a copy of the spell. Because the parent class couldn't know its own children, I couldn't easily create a copy method that would be inherited.
    What was easy?
      With a simple but robust interface, implementing new Stages and modifiers for abilities wasn't difficult at all.
 ```
