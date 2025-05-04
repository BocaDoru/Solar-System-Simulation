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
    * [Shape Generator](#shape-generator)
    * [Color Generator](#color-generator)
  * [Data Handling](#data-handling)
* [Project Structure](#project-structure)

## Technologies Used

* Unity
* C#

## Features

* **Planetary Motion:** Simulates the orbital motion of planets based on Newton's laws of gravitation.
* **Realistic Scale:** Attempts to represent the relative sizes and distances of celestial bodies using a logaritmic scale for better visualization.
* **User Interaction:** Allows users to control time speed and change viewpoint.
* **Procedural Generation:** Procedural generated planets using Simplex Noise and Ridgid Noise algorithm.
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

* All physic equations are based on Newton's law of universal gravitation.
  * $$F = G \frac{m_1 m_2}{r^2}$$
  * $$F->$$ gravitational atraction force between 2 objects.
  * $$G->$$ gravitational constant that equals to $$~6.67428^{-11}$$.
  * $$m_1, m_2->$$ the mass of those 2 objects.
  * $$r->$$ the distance between those 2 objects.
    * $$r = 1AU \frac{c_1 - c_2}{s}$$
    * $$1AU~1.49597^{11}$$ 1AU=the distance between Sun and Earth.
    * $$c_1, c_2->$$ the center of each celestial object in Unity wolrd coordinates.
    * $$s->$$ the scale selected in Settings Menu.
* All the calculation are done for each **Fixed Update(0.02s)**.
* After gravitational atraction force is calculated the acceleration is recalculated as $$a = \frac{F}{m}$$.
* The velocity is calculated as $$v = v_0 + a t t_m$$. Where $$v_0$$ is the iniatial velocity for each celestial body, $$t=0.02s$$ and $$t_m$$ is the **time multiplier** selected in the Settings Menu.
* The position is calculated as $$p = p_0 + \frac{t t_m v s}{1 AU}$$. Where $$p_0$$ is the initial position for each celestial body.

### Procedural Generation

* The procedural generation of celestial bodies is based on [Sebastian Lague tutorial "Procedural Planet Generation"](#https://youtu.be/QN39W020LqU?si=vpwuASJpUm-9wjPf).
* It's a Unity Editor Generator, all the celestial bodies are generated manualy in the editor using a custom editor. This custom editor provides:
  * **Planet Ref:** a reference to the celestial body.
  * **Rezolution:** a natural number value from 2 to 256, each face has $$\times{rezolution}{resolution}$$. Every celestial body has 6 faces(initialy the planet is generated as a cube and then every vertex is projected on a sphere).
  * **Auto Update:** a boolean value to toggle the auto update for generation.
  * **Face Render Mask:** an enum value to toggle face rendering. Those values are: *All*,*Top*, *Bottom*, *Left*, *Right*, *Front*, *Back*.
  * **Shape Settings:** a *Scriptable Object* used to store noise settings for each celestial body.
  * **Colour Settings:** a *Scriptable Object* used to store color settings for each celestial body.

#### Shape Generator

* It's done using multiple **noise filter layers** stacked one on top to another using the first layer as mask or as individual noise layers.
* There are 2 types of noises used:
  * **Simplex Noise:** used to generate basic geoformation as continents and large islands or smooth details by stacking multiple layers.
  * **Ridgid Noise:** used to generate more datailed geofromation as mountains and small island archipelago or rought details by stacking multiple layers.
* Each noise layer can have sub-layers for more datails. Those sub-layers do not change radicaly the basic shape, a small number of sub-layers result in a smoother surface and a large number of sub-layers result in a much random looking surface.
* Every noise layer have those parameters:
  * **Strenght:** a multiplier for the noise layer.
  * **Num Layers:** the number of sub-layers.
  * **Base Roughness:** the frequency used for the first sub-layer.
  * **Roughness:** a multiplier used for each sub-layer after the first one. It is used as: $$freq=BaseRoughness*Roughness^i$$ where i is the sub-layer number.
  * **Persistence:** the amplitude of each sub-layer. It is used as: $$A=1$$ for the first sub-layer, $$A_i=A_{i-1}*persistence$$ where i is the sub-layer number.
  * **Center:** this is the center of noise
  * **Min Value:** the minimum value for the noise
  * **Weight Multiplier(Only for Ridgid Noise):** the weight of each sub-layer. It is used as: $$w=1$$ for the first sub-layer, $$w_i=w_{i-1}*WeightMultiplier$$ where i is the sub-layer number.
* This generation can create complex visual representation for each celestial body. In this simulation I optate to a realistic representation for each Solar System celestial body using reference imagines.

#### Color Generator

* It's done using a **biome distribution** method and a **noise layer** for a natural aspect.
* Each celestial body can have multiple biomes along the latitude lines.
* Each biome has a **gradient color** used to difference between altitudes.
* The **ocean colour** is a gradient used for oceans or celestial body minimum altitude color.  

### Data Handling

* All the planetary data are provided by [Nasa Horisons](#https://ssd.jpl.nasa.gov/horizons/) and are colected at the date **18.11.2023**. Those data can be found in **SolarSystemData.xlsx** file in this repository.
* All the reference imagines are provided by [Wikipedia Solar System page](#https://en.wikipedia.org/wiki/Solar_System) and links to each celestial body from our Solar System.
* In **Rezultate optime.txt** file you can find the optimal settings for long time simulation.

## Project Structure

* **CelestialObjectScripts:**
  * **PlanetScript:**
    * `Planet.cs`: Handles celestial bodies generation based on the editor parameters.
    * `TerrainFace.cs`: Handles faces generation.
    * `INoiseFilter.cs`: Noise interface.
    * `Noise.cs`: Simplex Perlin Noise algorithm.
    * `NoiseSettings.cs`: Handles noise settings for generation.
    * `NoiseFilterFactory.cs`: Selects one of the 2 noise filters.
    * `SimpleNoiseFilter.cs`: Handles *Simplex Noise* generation for multiple layers.
    * `RidgidNoiseFilter.cs`: Handles *Ridgid Noise* generation for multiple layers.
    * `ShapeSettings.cs`: ScriptableObject used to store celestial body shapes.
    * `ShapeGenerator.cs`: Handles celestial body shape generation.
    * `ColourSettings.cs`: ScriptableObject used to store celestial body colour.
    * `ColourGenerator.cs`: Handles celestial body colour generation.
  * **Editor:**
    * `PlanetEditor.cs`: Costom Unity editor for planets generation.
  * **Settings:** Contains the ShapeSettings, ColouSettings and Material for each celestial body.
* **InputManager:**
  * `BackButton.cs`: Handles *back* and *exit* action.
  * `FullScreenMode.cs`: Toggles fullscreen mode.
  * `Generator.cs`: Generate Selection Menu.
  * `SelectMenuInput.cs`: Handles Selection Menu hot keys.
  * `ObserverSelector.cs`: Toggles observer selection.
  * `TargetSelector.cs`: Toggles target selection.
  * `SwitchCamera.cs`: Handles switch camera events and simulation parameters changes for better visualization.
* **Settings:**
  * `PlayButton.cs`: Starts the simulation.
  * `Scale.cs`: Handles scale input.
  * `ShowInfoText.cs`: Toggles infos mode for simulation parameters.
  * `ShowMoons.cs`: Toggles *Show Moons* mode.
  * `ShowOrbit.cs`: Toggles *Show Orbit* mode.
  * `TimeMultiplier.cs`: Handles time multiplier input.
* **SolarSystem:**
  * `CelestialObject.cs`: Handles celestial objects physics.
  * `DayCounter.cs`: Handles time updates.
  * `Gravity.cs`: Handles gravitational atraction aceleration for each celestial body.
  * `Initialize.cs`: Handels simulation parameters initialization.
