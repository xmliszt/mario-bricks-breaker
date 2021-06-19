using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickOnHit : MonoBehaviour
{
    public BrickScriptableObject brickType;
    public ParticleSystem breakDebris;

    private int maxHit;

    // Start is called before the first frame update
    void Start()
    {
        maxHit = brickType.maxHit;
        GetComponent<SpriteRenderer>().sprite = brickType.brickImage;
        GetComponent<SpriteRenderer>().color = brickType.color;
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mario"))
        {
            Debug.Log("Hit Left: " + maxHit);
            maxHit--;
            if (maxHit <= 0)
            {
                Instantiate(breakDebris, gameObject.transform.position, breakDebris.transform.rotation);
                breakDebris.Play();
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                StartCoroutine(destroyObject());
            }
        }
    }

    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
