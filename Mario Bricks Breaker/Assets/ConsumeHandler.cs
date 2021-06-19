using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeHandler : MonoBehaviour
{
    public BoosterPooler.ItemType type;
    public GameConstants constants;
    private BoosterPooler pooler;

    private void Start()
    {
        pooler = FindObjectOfType<BoosterPooler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {
            pooler.RecycleItem(type, gameObject);
            Destroy(gameObject);
        }
    }
}
