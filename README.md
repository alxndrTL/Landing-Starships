## Using Reinforcement Learning 🤖 to make rockets land 🚀

​		This project uses artificial intelligence algorithms, and more precisely deep reinforcement learning algorithms, to make an agent learn by itself how to land an orbital class rocket, Starship. The agent, or the algorithm, observes the environment and chooses actions to successfully land the rocket. Before the so-called "training", the agent just got initialized and basically chooses actions at random. As the training continues, the agent gets reward for doing the task we want it to do: landing the rocket. Based on this reward and how he got it, the agent will update the parameters of its neural network in order to make the actions that led to this reward more probable.

<p align="center">
  <img src="https://github.com/Procuste34/Landing-Starships/blob/master/images/LANDING_1.gif" width="800" />
</p>

### What is Starship ?

​		Starship is a fully reusable launch vehicle which is currently being developed by SpaceX. Starship refers to two things : the rocket as a whole (ie. the first stage, named Super Heavy, and the second stage) as well as the second stage itself. In this project, Starship refers to the second stage. This whole next-gen rocket, with its crazy diameter of 9 meters, will be capable of delivering more than 100 tons to Low Earth Orbit, while having a reusable first and second stage. Starships are currently being built in Boca Chica Village, Texas, and, maybe one day, will bring humans to Mars.

​		If you want daily updates about the development of Starship, I highly suggest you to follow NASASpaceflight on [Youtube](https://www.youtube.com/channel/UCSUu1lih2RifWkKtDOJdsBA) and [Twitter](https://twitter.com/NASASpaceflight) as well as take a look at [LabPadre's livestream of the Boca Chica site](https://www.youtube.com/watch?v=5QbM7Vsz3kg).

​		The second stage of the rocket, Starship, will perform a special reentry profile to slow down enough as shown below (it will be coming from orbit so will have a high speed w.r.t the air surrounding it) : it will keep a high Angle Of Attack (60°) during its descent and then will fall like a sky diver, belly first. A few seconds before touchdown, it will executes a maneuver to bring it from belly flop to tail down to actually land vertical, on its landing legs. This is the part of the landing we're recreating here.

<p align="center">
  <img src="https://i.imgur.com/ts7LfUQ.png" width=700/>
</p>


### What is Reinforcement Learning ?

​		Reinforcement learning is a subfield of AI that enables autonomous agents to learn by trial and error. RL allows agents to interact with an environment (here, the physical environment with the rocket, the landing platform etc...) and learn from this interaction. The learning is done with rewards, which tell the agent what task we want it to perform. In this case, the agent receives a reward of +1 for successfully landing the rocket, upright at almost no speed. If it fails, then it receives no rewards. Based on the rewards it receives, the agent will then deduce which actions are good (for example, firing the main engine near the landing pad to slow down) and which actions are bad (for example, firing the side thrusters when the rocket is perfectly upright). One last thing : the agent, in order to perform the right actions at the right time, must know where is the rocket, what is its orientation, its speed and more. We thus give him, at each timestep (each time he must take an action), an observation of the environment. In this project, the agent is given at each timestep 11 observations, going from position, speed to rotation of the vehicle.

​		The adjective "deep" refers to the fact that the algorithm used here uses "deep" neural networks, ie. neural networks with multiple hidden units. This "deepness" allows the agent to learn complex relationship between the state the agent sees and the reward he receives.

​		This learning is done, in this case, using the [PPO](https://openai.com/blog/openai-baselines-ppo/) algorithm, developed by [OpenAI](https://openai.com/), and implemented by the Unity team in Python. Learn more about the deep RL implementation in the Technical Details section.

<p align="center">
  <img src="https://github.com/Procuste34/Landing-Starships/blob/master/images/TRAINING.gif" width="500" />
</p>

## How to reproduce this ?

- ### Installation details

The Unity project of this experiment is located inside the LandingStarshipsProject folder of the repo.

To run the model and see the rockets land in action, you have to install Unity ML-Agents toolkit on your machine. [Link to the installation ](https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Installation.md) (it should take a few minutes)

​		To train the model (from scratch or using the pre-trained model, the RocketLanding.nn file), you also need to install the Unity ML-Agents toolkit. You can then follow [this guide](https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Training-ML-Agents.md) to start your training. The doc is really useful. Note also that I would suggest you to use the SN20 Unity project to train, as the LandingStarshipsProject Unity project is really made to create videos and cool clips (it has a map, particle effects, animations...).

Of course, you can message me if you have trouble with that, or if you have a question. I'm more likely to respond on [Twitter](https://twitter.com/AlexandreTL2).

- ### Where to learn RL

If you're willing to learn more about RL, here are some guidance and resources for you to start with.

​		To experiment with Deep RL, you could technically go straight to the implementation, avoid the theory and still get some good results. But of course, learning the theory first is essential if you want to understand (or should I say have a better intuition) your RL algorithm and tweak it appropriately. So first, for the RL side, I would highly suggest you to start with [Reinforcement Learning : An Introduction, by Sutton & Barto](http://www.incompleteideas.net/book/the-book-2nd.html), which covers the basics concepts of RL. Also, if you're more into learning by videos, then [David Silver's series of video on Youtube](https://www.youtube.com/playlist?list=PLqYmG7hTraZDM-OYHWgPebj2MfCFzFObQ) essentially covers the same stuff as in the book.

​		Now, RL is really great but to implement it on "real-worldish" problems usually requires using deep learning ie. deep neural networks. This is called Deep RL. Learning Deep RL if you know RL isn't hard, though you need to know about supervised learning (things like gradient descent, neural network basics, backprop... for that Andrew Ng's course on Coursera is really good for a first look into these subjects). Then, I would say that you can go with the [OpenAI Spinning up in Deep RL](https://spinningup.openai.com/en/latest/), as well as the [Deep RL Bootcamp](https://sites.google.com/view/deep-rl-bootcamp/lectures) organized by UC Berkeley.

​		**If you're French**, or if you're at ease with the French language, I'm currently posting [a course on Youtube about all that stuff](https://www.youtube.com/playlist?list=PLO5NqTx3Y6W45lAObwpMGF_rcH02HLf4I) : standard RL, basic supervised learning concepts and Deep RL. At this date, I've mostly covered (not finished yet but soon) the whole standard RL part. I would highly advise you to take a look at it ! [Link to the course](https://www.youtube.com/playlist?list=PLO5NqTx3Y6W45lAObwpMGF_rcH02HLf4I)



## Discussion and Technical Details

- ### About the physical simulation and the landing

  ​		In reality, to achieve a landing, Starship will essentially be able to control the throttle level of its 3 engines, the gimbal of these engines, the RCS side thrusters and the position of its body flaps and top fins.

  ​		In the simulation I created, the atmosphere was not considered and thus the agent doesn't get to control the position of the flaps. Furthermore, I chose to provide to the agent only one throttle level, firstly because then the RL problem was a discrete action problem, and also because from a physical point of view, achieving landing with the full throttle is optimal (more on that later). Apart from that, the agent lands the Starship using TVC (engine gimballing) with a 7° angle in every direction (that number comes from what the Merlin engine is capable of on the Falcon 9's first stage). The agent can of course turn off and on the 3 main engines, as well as a total of 4 RCS thrusters, to help stabilize the orientation of the rocket. With the combination of TVC and RCS, the agent can thus control the roll and pitch of the rocket (the yaw control is neglected)
  
  [GIF GIMBALLING MOTOR ET RCS ZOOM]

  ​		At the start of the simulation, the rocket spawns at an altitude of about 5 km, with a random initial velocity and in the belly flop position (again, with a bit of random initialization). The center of mass of the rocket is set at about 2/3 from the top of the rocket. A landing is considered successful if the speed of the rocket at touchdown is less than 5m/s and the rocket stands upright.

  ​    	Interestingly, no matter the reward function used, the agents always converged on one special (and very efficient) landing profile : the suicide burn, or, as SpaceX calls it, the hoverslam. This kind of maneuver, well know of KSP players, is simple : fire the main engine to slow down at the very last moment. As pointed out by Scott Manley ([@DJSnM](https://twitter.com/DJSnM)) in his [video](https://www.youtube.com/watch?v=T3_Voh7NgDE), this maneuver, while being dangerous, is the most optimal one to land considering the fuel it requires. For those wondering, yes the reward function only rewards the agent of successfully landing (regardless of the fuel it used for landing), but the overall learning algorithm tries to maximize the reward per timestep. So for example, during 100k timesteps, if you use a safe landing method, then you will be able to achieve less landings than if you used the hoverslam technique, because it is way more fuel as well as time efficient.

  ​		The first limitation of this simulation is of course that it doesn't take into account the atmosphere. It follows that precise trajectories and speeds are not followed. Also, another limitation is that the agent is able to turn off and on the 3 main engines instantly (1) and for an unlimited number of times (2), same for the RCS. This does not really reflects reality as the main engines are complex machines which (1) doesn't start instantly and (2) can't restart for a large number of times.

<p align="center">
  <img src="https://github.com/Procuste34/Landing-Starships/blob/master/images/BELLYFLOP.gif" width="800" />
</p>

- ### About the Deep Reinforcement Learning implementation

  ​		The Reinforcement Learning problem associated with the Starship landing is a continuous state space and discrete action space problem. As stated above, the agent receives at each timestep 11 observations which are floating point values associated with the position, rotation and speed of the rocket. The agent then acts and chose, again at each timestep, among 162 (= 2x3^4) possible actions. While the number of actions seems large, the agent only controls the main engines throttle level (2 actions: on or off), the main engine TVC on the X (3 actions: -7°, +7° or no TVC) and Z axis (3 actions: -7°, +7° or no TVC) and finally the roll RCS (3 actions: negative, positive, no RCS) and the pitch RCS (3 actions: negative, positive, no RCS).

  ​		The reward function, as stated above, is very simple as the agent only get a reward of +1 for achieving a successful landing. However, having such a simple reward function is critical at the beginning of the training : executing random actions (what the agent does at the beginning) have a very low probability (1 in 8e441, which is a 8 followed by a good number of 0's) of leading to a positive reward (the agent can't learn anything if during all his training he saw no rewards). Having the agent actually reach the landing state is thus crucial to "get in on tracks". To do that, I used a combination of 2 techniques : curriculum learning and imitation learning. Curriculum essentially make the agent learn a simpler task than the task we finally want it to perform. For example, instead of spawning the rocket at an altitude of 5 km, the rocket is spawned at only 500 m. This makes the agent much more closer to the landing state, giving him more chance to reach it and observe a reward. Imitation learning is essentially providing examples to the agent about what to do in order to achieve its goal. For that, I actually recorder myself landing the rocket, which was still possible at low altitude with no rocket orientation (don't even try to land it yourself on the final levels, that's just impossible, or should I say, very very very hard). This technique is often considered as sub-optimal because we influence the learning of the agent, providing him examples which may not be optimal. However, in this case, I wouldn't call it imitation learning as it was just used for the very beginning of the training and then discarded after some fixed amount of timesteps (the agent trained using my demonstrations during 0.0025% of its training). The agent was then able to learn the optimal sequence of actions to perform, with no influence of my demonstrations.

  ​		So at the beginning, the agent was guided by human demonstrations so that it experienced the positive reward. We can kind of see this as an exploration strategy : instead of exploring using completely random actions, the agent explores the environment with actions that are overall close to actions which lead to a reward. This and the curriculum seems to be a good strategy in settings like these, ie. where the reward function is very sparse. Of course, this type of imitation learning cannot be used in every environment as well as curriculum learning, indeed, it may be difficult for some tasks to be reached for simpler tasks.

  ​		In order to get agent that are able to generalize well to different conditions, random initialization was used intensely during all the training. This had the positive of effect of making the agents more robust to variations in changes of initial condition. A direct effect of this could be observed during the training, where the altitude was incrementally increased (from 500m to 5km). At each increase (eg. from 900m to 1.5km), I could observe that the performance of the agent didn't drop by very much (less than expected considering the fact that the spawning altitude was considerably changed).

  ​		Practically, the project is made in Unity, which has a nice toolkit called [Unity ML Agents](https://github.com/Unity-Technologies/ml-agents), which makes it possible to interact with an agent in Unity from Python. That is very useful as Python is a very famous language for ML and RL. Also, it supports parallel training of multiple agents in a single environment, which speeds up considerably the training. That's why you can see 32 Starships landing next to each other. The algorithm used, PPO, was a plain out-of-the-box algorithm, I didn't tweak it to match perfectly what I wanted to do. That is something that's worth pointing out. More on that in the Results section.

<p align="center">
  <img src="https://github.com/Procuste34/Landing-Starships/blob/master/images/LANDING_2.gif" width="800" />
</p>

- ### Could Reinforcement Learning be used by SpaceX ?

  ​		Currently, SpaceX doesn't use Reinforcement Learning as a control method to land its rocket. Nor does their rocket uses ML as a control technique. Indeed, classic optimal control algorithms (stuff like PID, MPC from control theory) are much more robust and predictable than ML algorithms, and particularly deep RL algorithms like PPO. One reason for that is that we let the algorithm learn what it wants to learn, as long as what it learns helps it get more reward. This approach, while allowing the algorithm to reach optimal performance, limits our view of what the algorithm learns, and thus our ability of what to expect from this algorithm under a certain circumstance. 

  ​		Furthermore, a big caveat of RL is its need of a large amount of interaction with the environment to get good performance. Worse than that is the fact that at the beginning of the training, the agent executes actions at random : we don't want the controller of the first Starship landing on Mars to execute actions randomly. Something that however can be done is train the agent in the simulation (something similar to mine, although MUCH more closer to reality that mine is) and then put the agent in the real world, where it could fine-tune its model (finish his training).

  ​	RL is not yet ready for practical use, and so it's far less for such tasks. However, I'm sure that we're only a few breakthrough papers away from seeing RL being able to scale to real world problems. And then, we'll talk about Starship landing using RL.


- ### Has there been other work similar to this ?

  ​		Of course, and these have inspired me in the making of this one (as well as the test campaign on SN5 for sure). The first well known work is the example environment of the gym library by OpenAI, the Lunar Lander. The goal of this environment is to control a lander to make it land on the Moon. However, the environment can be considered to be simpler than what is used here as there is less action, the agent only needs to worry about 2 dimensions and has to control the lander on a much smaller height. That's why there is no special need for exploration strategies on this environment.
  
  <p align="center">
    <img src="https://leimao.github.io/images/article/2017-05-04-REINFORCE-Policy-Gradient/lunarlander.png" width=700/>
  </p>

  ​		I have found a work similar to what I've done in Unity, this time landing the Falcon 9's first stage. The work is done by [u/SwissArmyApple](https://www.reddit.com/user/SwissArmyApple/). He also uses PPO as the training algorithm, and told me that he used a dense reward function.

- ### Boca Chica landscape and 3D models

  ​		The 3D models of the Boca Chica landscape as well as the Starship model was made in Blender by me. The landscape includes the famous SpaceX launch and [build](https://twitter.com/AlexandreTL2/status/1294345416964820994) sites located in Boca Chica Village, Texas. It was interesting modelling Starhopper, the tank farm, the Highbay, the Midbay, the Windbreak, SN5, SN6 and of course ... Bluezilla ! Special thanks to [@NASASpaceflight](https://twitter.com/NASASpaceflight), [@cnunezimages](https://twitter.com/cnunezimages) and [@RGVaerialphotos](https://twitter.com/RGVaerialphotos) for making available precious pictures of SpaceX site in Boca Chica !

  ​		Also, the engine sound as well as the RCS sound you can hear on the demo is procedurally generated. Thanks to [Joe Strout](https://www.gamasutra.com/blogs/author/JoeStrout/1001725/) for sharing this "library".

<p align="center">
  <img src="https://github.com/Procuste34/Landing-Starships/blob/master/images/real_render.png" width=500/>
</p>

## Results

​		The total number of parameters in the neural network is about 40k. The algorithm trained for a total of about 200 millions timesteps, which, on my (Intel i7 processor) machine, took about 20 hours. A trained agent has a mean reward of about 0.98, meaning that after training, the agent lands Starship successfully ~98% of the time. I could have stopped training way before 20 hours and still get good performance (>95%) but of course, that performance, even the 98% one, isn't acceptable for practical use. With more training and good hyperparameter tuning, I do believe that performance could go way higher but again, the "black box" effect makes the practical use of RL critical for this task.

[PHOTO PERFS?]

​		For comparison, [DeepMind](https://deepmind.com/)'s famous implementation of Deep Q-learning (DQN) on Atari games uses less than 10K parameters, and trained for a total of 10 millions steps with a CNN neural network (ie. the agent see screenshots of the game, as we humans do). Two reasons can explain the big difference of steps required to learn : first, well, I made this project on my own during a few weeks. Second, the algorithm used by Google DeepMind, called DQN, is fundamentally different than PPO (it's still deep reinforcement learning though). DQN has the advantage of being very data efficient : it can actually learn from the experience generated at anytime during the training. Conversely, PPO throw data away as soon as it has made an update with it : it can't use data from past trajectories.

​		The main difficulty while making this project was getting the right reward function. I tried at the beginning a denser reward function, which could tell the agent how do the task (ie. distance to the pad, orientation of the rocket, collision speed...) but these were very hard to use as the agent maximized them in weird ways. For example, if you penalize the agent for colliding with the ground too fast, then it wont collide at all and thus get no negative reward. In general, you want a reward function that tell the agent what to do, and not how to do it, so that the agent do whatever it wants to actually achieve what you want it to do. The best reward function is thus a reward function that is maximized if and only if the agent performs the task you want it to do.

​		Before testing curriculum learning and imitation learning as exploration strategies, I tried implementing an ICM - Intrinsic Curiosity Module - which creates some kind of intrinsic curiosity that encourages the agent to explore the environment. However, ICM didn't show great results.

​		Concerning hyperparameters, I used a three-layers neural network (2 hidden layers of 128 units), a learning rate of 3.0E-4 and a batch size of 64 (and then increased it later at 128). For more information, please see the configuration files.

​		The algorithm used was used "as is" and didn't get tweaked. Also, the hyperparameters were almost the default ones, and I didn't really got the modify them to get results in the first place. This is something very important as this shows the ease of use of PPO. However, more hyperparameter tuning was required (and still is) to make the learning more stable. 

