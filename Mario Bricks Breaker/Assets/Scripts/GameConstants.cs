using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    // General
    public Vector3 marioOriginalSize = new Vector3(0.7f, 0.7f, 0.7f);
    public Vector4 spawnBoundary;
    public int winScore = 10;
    public float panelMoveSpeed = 10;
    public float panelShootForce = 8;
    public float itemSpawnMaxInterval = 8;
    public float itemSpawnMinInterval = 3;

    // Coin
    public int coinValue = 1;

    // High Speed
    public float velocityMultiplier = 1.5f;
    public float velocityEffectDuration = 5;

    // Shrink
    public float scaleMultiplier = 0.6f;
    public float shrinkEffectDuration = 5;
}
