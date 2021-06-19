using UnityEngine;

[CreateAssetMenu(fileName = "newBrick", menuName = "ScriptableObjects/Bricks", order = 0)]
public class BrickScriptableObject : ScriptableObject
{
    public Sprite brickImage;
    public Color color;
    public int maxHit = 1;
}
