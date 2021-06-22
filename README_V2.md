# 50.033 Game Design Lab 4 Handout

---

<center>
by Li Yuxuan 1003607
<h3>
<a href="https://github.com/xmliszt/mario-defense">GitHub Repo</a>
</h3>
<h3>
<a href="https://youtu.be/_-3c9zwn9xI">Gameplay Video</a>
</h3>
</center>

---

[TOC]

## Game Design

- Title: **Mario Ping Pong V2**
- Multiplayer 1v1
- Ping pong game where the player controls the panel to bounce Mario to hit each other.
- Concept: Player uses keyboard to control left and right movement of the panel and press Space to fire Mario. Mario will bounce off the surface. Once Mario go over the panel and hits the end, the other player will gain one point. Whoever gets to 10 points first wins the game.
- Special game objects

| Game Object | Description |
| -------- | -------- |
| ![](https://i.imgur.com/JGbZ2wP.png)    | Player controls the panel left or right, and shoot off Mario|
| ![](https://i.imgur.com/suiDtVg.png) | Breakable bricks. On hit will break into debris. Purpose is to obstruct the player. |
| ![](https://i.imgur.com/YRiBOWj.png) | Rotating coin. Purpose is to accelrate the game by increasing both player's score. |
| ![](https://i.imgur.com/GqUxqlh.png) | High speed booster. Mario will have higher velocity when consumed this |
| ![](https://i.imgur.com/aOdFxXN.png) | Shrinker. Mario will shrink in size when consumed this |

## Features

### Texture Sheet Animation

![](https://i.imgur.com/ScASH99.png)

The fire seen on both sides are done by using Texture Sheet Animation in Particle System. The texture sheet used is as follows:

![](https://i.imgur.com/QPD3SUb.jpg)

### Audio Mixer

![](https://i.imgur.com/4pizsG0.png)

Audio Mixer is added to add SFX to audio in the game. SFX includes the sounds when Mario hits the wall and Mario hits the boundary and explodes. Duck Volume is applied to the Background Audio and SFX sends effects to the Background group.

### Scriptable Objects

![](https://i.imgur.com/175Gb8j.png)

![](https://i.imgur.com/FSWT7kC.png)

Two scriptable objects to control properties of the breakable bricks aforementioned as well as other game constants. 

### Breakable Prefabs

![](https://i.imgur.com/dPrCKH7.png)

The breakable bricks will break into debris upon hit by Mario.

### Object Pooling

![](https://i.imgur.com/LrCzeP2.png)

Object pooling is used to pre-instantiate all consumable items (Coin, High speed Booster, Shrinker), and it is scripted in such a way that it provides a nice interface to work with:

![](https://i.imgur.com/VxfNnO9.png)

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPooler : MonoBehaviour
{
    public enum ItemType
    {
        coin = 0,
        highSpeed = 1,
        shrink = 2,
    }

    [System.Serializable]
    public class Pool {
        public ItemType type;
        public GameObject poolItem;
        public int capacity; // size of the pool
    }

    public List<Pool> pools;
    public Dictionary<ItemType, Queue<GameObject>> poolerRepository;
    void Awake()
    {
        poolerRepository = new Dictionary<ItemType, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> itemPool = new Queue<GameObject>();
            for (int i = 0; i < pool.capacity; i ++)
            {
                GameObject item = Instantiate(pool.poolItem);
                item.SetActive(false);
                itemPool.Enqueue(item);
            }
            poolerRepository.Add(pool.type, itemPool);
        }
    }

    public GameObject SpawnItem(ItemType tag, Vector3 position, Quaternion rotation)
    {
        Queue<GameObject> pool = poolerRepository[tag];
        GameObject item = pool.Dequeue();
        item.transform.position = position;
        item.transform.rotation = rotation;
        return item;
    }

    public void RecycleItem(ItemType tag, GameObject gameObject)
    {
        poolerRepository[tag].Enqueue(gameObject);
    }
}

```