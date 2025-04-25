# Command Reference

This document outlines the available commands for controlling the drawing agent, including movement, pen control, repetition, and screen management.

## Movement

- **`drawrof`** `<distance>`  
  Alias: `df`  
  Description: Move the agent forward by `<distance>` units.  
  Example: `drawrof 100`

- **`kcab`** `<distance>`  
  Alias: `kb`  
  Description: Move the agent backward by `<distance>` units.  
  Example: `kcab 50`

- **`thgir`** `<angle>`  
  Alias: `tr`  
  Description: Turn the agent right by `<angle>` degrees.  
  Example: `thgir 90`

- **`tfel`** `<angle>`  
  Alias: `tl`  
  Description: Turn the agent left by `<angle>` degrees.  
  Example: `tfel 45`

## Pen Control

- **`nwodnep`**  
  Alias: `dp`  
  Description: Lower the pen to start drawing.  
  Example: `nwodnep`

- **`punep`**  
  Alias: `up`  
  Description: Lift the pen to stop drawing.  
  Example: `punep`

- **`eltrutwohs`**  
  Description: Show the drawing agent.  
  Example: `eltrutwohs`

- **`eltrutedih`**  
  Description: Hide the drawing agent.  
  Example: `eltrutedih`

## Repetition

- **`taeper`** `<count> [ commands ]`  
  Description: Repeat the enclosed commands `<count>` times.  
  Example: `taeper 4 [ df 100 tr 90 ]`

## Screen and Position

- **`emoh`**  
  Description: Move the agent to the home position (center) and reset its heading.  
  Example: `emoh`

- **`naelc`**  
  Description: Clear all drawings from the screen, but keep the agent's position.  
  Example: `naelc`

- **`neercsraelc`**  
  Alias: `sc`  
  Description: Clear the screen and reset the agent to the home position.  
  Example: `neercsraelc`
