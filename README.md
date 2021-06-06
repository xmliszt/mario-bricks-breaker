# 50.033 Game Design Lab 3 Handout

---

<center>
by Li Yuxuan 1003607
<h1>
<a href="https://xmliszt.itch.io/mario-ping-pong">Play It Here!</a>
</h1>
<h3>
<a href="https://github.com/xmliszt/mario-defense">GitHub Repo</a>
</h3>
<h3>
<a href="https://youtu.be/CIUBoWbPxrQ">Gameplay Video</a>
</h3>
</center>

---

## Lab Competition

I would like to take part in the competition. :D

## Game Design

- Title: **Mario Ping Pong**
- Multiplayer 1v1
- Ping pong game where the player controls the panel to bounce Mario to hit each other.
- Concept: Player uses keyboard to control left and right movement of the panel and press Space to fire Mario. Mario will bounce off the surface. Once Mario go over the panel and hits the end, the other player will gain one point. Whoever gets to 10 points first wins the game.
- Special game objects

| Game Object | Description |
| -------- | -------- |
| ![](https://i.imgur.com/JGbZ2wP.png)    | Player controls the panel left or right, and shoot off Mario|
| ![](https://i.imgur.com/bEm4uRK.png)    | The central bouncing obstacle will appear once in a while to add variation to the game|

## Features

### Parallax Scrolling Background

The background of cyberpunk-style city is scrolled with parallax effect. In this game, the camera is not moving, hence the implementation of parallax is slightly different from the lab. In this case, each background is initialized to be repeated one time, and their positions are reset once the center go over the left bound of the camera view.

### Normal Map for Rusted Pipe

![](https://i.imgur.com/GNNt1hq.png)

![](https://i.imgur.com/QRT5gdJ.png)

Custom normal map is added to the pipe to make it appear rusted. 

### Shaders - Hologram and Glowing Mario

![](https://i.imgur.com/1Pc1I0T.png)

Hologram glowing Mario

![](https://i.imgur.com/DhkBoDF.png)

Hologram Texture

![](https://i.imgur.com/TgJSQHU.png)

Mario glowing shirts texture

I used Photoshop to edit the above 2 textures and imported into Unity. Using Shader Graph, I managed to achieve a Hologram effect on Mario. Together with "bloom" in URP, Mario's shirts start glowing.

![](https://i.imgur.com/01WFVt3.png)



### Universal Rendering Pipeline

![](https://i.imgur.com/kNLxksU.png)

The above are the post-processing profiles added in the game to achieve the retro effect. Point lights are added to the fire, Mario, panels and sparks at different layers to achieve the final light effects. 2D renderer is used to render the different lights. 

![](https://i.imgur.com/m4wz1Jt.png)

From the hierarchy can see that many lights are added.

### Particle Systems


![](https://i.imgur.com/kwpQ6rY.png)

![](https://i.imgur.com/P558aCN.png)

![](https://i.imgur.com/4Y5j4hS.png)

There are three particle systems designed to mimic fire, sparks and explosion. For the fire, a custom texture of fire is used:
![](https://i.imgur.com/Ii6j5rC.jpg)
