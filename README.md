## Using Reinforcement Learning to make rockets land

#project description, overall

This project uses artificial intelligence algorithms, and more precisely reinforcement learning algorithms, to make an agent learn by itself how to land an orbital class rocket, Starship. The agent is the algorithm which can observe the environment and choose actions to complete some task, here, landing the rocket. Before the so-called "training", the agent just go initialized and basically chooses actions at random. However, as the training continues, the agent gets reward for doing the task we want it to do : again, landing the rocket. Based on this reward and how he got it, the agent will update its parameters in order to choose actions that led to this reward more probable.

### What is Starship ?

Starship is a fully reusable launch vehicle which is currently being developed by SpaceX. Starship refers to two things : the rocket as a whole (ie the first stage, named Super Heavy, and the second stage) as well as the second stage itself. In this project, Starship refers to the second stage. This whole next-gen rocket, with its crazy diameter of 9 meters, will be capable of delivering more than 100 tons to Low Earth Orbit, while having a reusable first and second stage. Starships are currently being built in Boca Chica Village, Texas, and, maybe one day, will bring humans to Mars.

The second stage of the rocket, Starship, will perform a special reentry profile to slow down enough as shown below (it will be coming from orbit so will have a high speed w.r.t the air surrounding it) : it will keep during its descent a high Angle Of Attack (60°) and then will fall like a sky diver, belly first. A few seconds before touchdown, it will executes a maneuver to bring it from belly flop to tail down to actually land vertical, on its landing legs.



### What is Reinforcement Learning ?

Reinforcement learning is a subfield of AI that enables autonomous agents to learn by trail and error. RL allows agents to interact with an environment (here, the physical environment with the rocket, the landing platform etc...) and learn from this interaction. The learning is done with rewards, which will tell the agent what task we want it to perform. In this case, the agent receives a reward of +1 for successfully landing the rocket, upright at almost no speed. If it fails, then it receives no rewards. Based on the rewards it receives, the agent will then deduce which actions are good to take (for example, firing the main engine near the landing pad to slow down) and which actions are bad (for example, firing the side thrusters when the rocket is perfectly upright). One last thing : the agent, in order to perform the right actions at the right time, must know where is the rocket, what is its orientation, its speed and more. We thus give him, at each timestep (each time he must take an action), an observation of the environment. In this project, the agent is given at each timestep 11 observations, going from position, speed to rotation of the vehicle.



This learning is done, in this case, using the PPO algorithm, developed by OpenAI, and implemented by the Unity team in Python. Learn more about the RL implementation in the Technical Details section.



## Technical Details

- ### About the physical simulation and the landing

  ​	In reality, to achieve a landing, Starship will essentially be able to control the throttle level of its 3 engines, the gimbal of these engines, the RCS side thrusters and the position of its body flap and top fins.

  ​	In the simulation I created, the atmosphere was not considered and thus the agent doesn't get to control the position of the flaps. Furthermore, I chose to only provide to the agent one throttle level, firstly because then the RL problem was a discrete action problem, and also because from physical point of view, achieving landing with the full throttle is optimal (more on that later). Apart from that, the agent lands the Starship using TVC (engine gimballing) with a 7° angle (that number comes from what the Merlin engine is capable of on the Falcon 9's first stage). The agent can of course turn off and on the 3 main engines, as well as a total of 4 RCS thrusters, to help stabilize the orientation of the rocket. With the combination of TVC and RCS, the agent can thus control the roll and pitch of the rocket (the yaw control is neglected)

  ​	At the start of the simulation, the rocket spawns at an altitude of about 5 km, with a random initial velocity and in the belly flop position (again, with a bit of random initialization). The center of mass of rocket is set at about 2/3 from the top of the rocket.

  ​    Interestingly, no matter the reward function used, the agents always converged on one special (and very efficient) landing profile : the suicide burn, or, as SpaceX calls it, the hoverslam. This kind of maneuver, well know of KSP players, is simple : fire the main engine to slow down at the very last moment. As pointed out by Scott Manley (@DJSnM) in his video (https://www.youtube.com/watch?v=T3_Voh7NgDE), this maneuver, while being dangerous, is the most optimal one to land considering the fuel it requires. For those wondering, yes the reward function only rewards the agent of successfully landing (regardless of the fuel it used for landing), but the overall learning algorithm tries to maximize the reward per timestep. So for example, during 100k timesteps, if you use a safe landing method, then you will be able to achieve less landings than if you used the hoverslam technique, because it is way more fuel as well as time efficient.



limitation : engine off et on ilimité



init ?

- ### About the Reinforcement Learning implementation

Detaisl techniques sur 

sparse REWARD ET OUAIS MA GUEULE

curriculum + imitation ?

hyperparams

init random

le landing



le RL





et en vrai ? c'est ça qui est utilisé?



+parler des models fait dans Blender ?

du son ?



other work ?
