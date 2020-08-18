## Using Reinforcement Learning to make rockets land

#project description, overall

This project uses artificial intelligence algorithms, and more precisely reinforcement learning algorithms, to make an agent learn by itself how to land an orbital class rocket, Starship. The agent is the algorithm which can observe the environment and choose actions to complete some task, here, landing the rocket. Before the so-called "training", the agent just go initialized and basically chooses actions at random. However, as the training continues, the agent gets reward for doing the task we want it to do : again, landing the rocket. Based on this reward and how he got it, the agent will update its parameters in order to choose actions that led to this reward more probable.

### What is Starship ?

Starship is a fully reusable launch vehicle which is currently being developed by SpaceX. Starship refers to two things : the rocket as a whole (ie the first stage, named Super Heavy, and the second stage) as well as the second stage itself. In this project, Starship refers to the second stage. This whole next-gen rocket, with its crazy diameter of 9 meters, will be capable of delivering more than 100 tons to Low Earth Orbit, while having a reusable first and second stage. Starships are currently being built in Boca Chica Village, Texas.

The second stage of the rocket, Starship, will perform a special reentry profile to slow down enough as shown below (it will be coming from orbit so will have a high speed w.r.t the air surrounding it) : it will keep during its descent a high Angle Of Attack (60°) and then will fall like a sky diver, belly first. A few seconds before touchdown, it will executes a maneuver to bring it from belly flop to tail down.
