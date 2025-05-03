# Solar System Simulation

* This Unity project simulates the dynamics of a solar system, allowing users to \[briefly describe the main purpose, e.g., visualize planetary motion, experiment with gravitational forces, etc.]. It incorporates \[mention key features, e.g., realistic physics, procedural generation, etc.] to create a dynamic and interactive simulation.

## Table of Contents

* [Technologies Used](#technologies-used)
* [Features](#features)
* [Usage](#usage)
  * [Simulation Controls](#simulation-controls)
* [Technical Details](#technical-details)
  * [Physics Engine](#physics-engine)
  * [Procedural Generation](#procedural-generation)
  * [Data Handling](#data-handling)

## Technologies Used

* Unity
* C#

## Features

* **Planetary Motion:** Simulates the orbital motion of planets based on Newton's laws of gravitation.
* **Realistic Scale (Optional):** Attempts to represent the relative sizes and distances of celestial bodies using a logaritmic scale for better visualization.
* **User Interaction:** Allows users to control time speed and change viewpoint.
* **Procedural Generation:** Procedural generated planets using Perlin Noise and Rigid Noise algorithm.
* **Data Visualization:** Displays orbital paths.

## Usage

### Simulation Controls

* **Set your simulation parameters:**
  * **Days/Second:** this setting controls the simulation speed.
  * **Scale:** this setting controls the scale for an *Astronomical Unit* in Unity wolrd coordinates(e.g. 1 AU=10 Unity units)
  * **Show moons:** this settings controls whether or not the moons should be visible in the simulation.
  * **Show orbit:** this settings controls whether or not the planetary orbit should be visible in the simulation.

* **Hot Keys:**
  * **Back/Exit:** to exit the simulation or to go back to the Settings Menu press **Esc key**.
  * **Selection Menu:** to open the Selection Menu press **Space key**.
  * **Observer controls:** to navigate between celestial object press **Right Arrow** or **Left Arrow**.
  * **Target controls:** to navigate between celestial object press **Up Arrow** or **Down Arrow**.
  * **Fullscreen:** to toggle fullscreen mode press **F11 key**.

* **Selection Menu:**
  1. Open Selection Menu by pressing the *Space key*. This menu has two lists: **Observer List**, **Target List**.
  2. Select a celestial body from each list:
     * If the same celestial body was selected the view point will be above the selected body.
     * If different celestial body were selected the view point will be on the **observer body** and the orientation will be on the **target body**.

## Technical Details

### Physics Engine

* All physics equation are based on Newton's law of universal gravitation.
  * $$F = G \frac{m_1 m_2}{r^2}$$
  * $$F->$$ gravitational atraction force between 2 objects.
  * $$G->$$ gravitational constant that equals to $$~6.67428^-11$$.
  * $$m_1, m_2->$$ the mass of those 2 objects.
  * $$r->$$ the distance between those 2 objects.
    * $$r = 1AU \frac{c_1 - c_2}{s}$$
    * $$1AU~1.49597^11$$ 1AU=the distance between Sun and Earth.
    * $$c_1, c_2->$$ the center of each celestial object in Unity wolrd coordinates.
    * $$s->$$ the scale selected in Settings Menu.
* All the calculation are done for each *Fixed Update*(0.02s).
* After gravitational atraction force is calculated the acceleration is recalculated as $$a = \frac{F}{m}$$.
* The velocity is calculated as $$v = v_0 + a t t_m$$. Where $$v_0$$ is the iniatial velocity for each celestial body, $$t=0.02s$$ and $$t_m$$ is the **time multiplier** selected in the Settings Menu.
* The position is calculated as $$p = p_0 + \frac{t t_m v s}{1 AU}$$.

### Procedural Generation

* If you generate any aspects of the solar system:
    * Explain the algorithms you used (e.g., Perlin noise, random distributions).
    * Describe how you control the parameters of the generation.

### Data Handling

* How did you store and manage data about celestial bodies (e.g., position, velocity, mass)?
* Did you use any specific data structures?
