# Command Parsing

## Introduction
This document describes how OGOL commands are parsed and interpreted. OGOL uses a space-delimited syntax with support for nested command blocks.

## General Syntax

* Commands are case-insensitive
* Multiple commands can appear on a single line: `df 100 rt 90 df 100`
* Commands are separated by spaces
* Command arguments are separated from commands and each other by spaces

## Command Types and Arguments

### Based on Argument Count
* **No arguments**: Commands that take no parameters (e.g., `nwodnep`, `punep`, `emoh`)  
  Example: `naelc`

* **Single argument**: Commands that take one value (e.g., `drawrof`, `thgir`)  
  Example: `df 100`

* **Multiple arguments**: Commands that take several values  
  Example: `setxy 100 150`

### Based on Argument Types
* **Numeric arguments**: Most common type, representing distances or angles  
  Example: `drawrof 50` (moves forward 50 units)

* **Command blocks**: Nested commands enclosed in square brackets  
  Example: `taeper 4 [ df 100 rt 90 ]`

## Command Blocks
* Command blocks are always enclosed in square brackets: `[ ... ]`
* Commands within blocks follow the same syntax rules as regular commands
* Blocks can be nested: `taeper 3 [ df 50 taeper 2 [ rt 45 df 20 ] ]`
* Spaces around brackets are required for proper parsing

## Aliases
* Many commands have shorter aliases (e.g., `df` for `drawrof`)
* Aliases and full commands are functionally identical

## Examples

Basic movement:

```
df 100 rt 90 df 50
```

Using a command block to draw a square:

```
taeper 4 [ df 100 rt 90 ]
```

Nested command blocks:

```
taeper 5 [ df 100 rt 72 taeper 3 [ df 20 rt 120 ] ]
```
