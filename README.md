# PokemonPocketSim

Ever wondered what the chances of getting the nut draw of Pikachu EX with 2 energy and a full bench would be? Well, wonder no more! This program will simulate the game of Pokemon Pocket TCG and give you the probability of when the nut draw will happen.

## Getting Started

Just run the program and the output will be displayed in the console.

There are multiple decks already created in the program:
* My personal Pikachu EX deck
* The Pikachu EX decks from the recent (10/13/24) Pokemon Pocket TCG Tournament

The program will consider the game state as "Success" if the following is true:
* Pikachu EX in the active position
* 2 energy attached to Pikachu EX
* Full bench of 3 Pokemon (So far, all pokemon in all decks are electric type, do didn't take type into account)

Then record the number of turns it took to get to that game state. The program will run the simulation 10,000 times and give you the probability of getting the "Success" state in a certain number of turns.

## Nitty Gritty Details

This does not take into account any of the opponent's actions. This is purely a simulation of the player's deck.

This does take into account the following:
* Poke Ball fetching you the next basic Pokemon and shuffling the deck afterwards
* Professor's Research drawing you 2 cards
* Retreating a Pokemon if Pikachu EX is not in the active position (with retreat cost in mind)
* X Speed reducing the retreat costs
* Prioritizing the Voltorb to be the first active Pokemon if Pikachu EX is not in opening hand since Voltorb can evolve into Electrode and have a free retreat cost
* Evolving Voltorb into Electrode if in active position
* Leaving room on the bench of Pikachu EX is not anywhere on the board yet
* No energy if going first
* Playing trainers (Only Professor's Research so far) only once each turn
* Playing items (Only Poke Ball and X Speed so far) as many times as possible each turn