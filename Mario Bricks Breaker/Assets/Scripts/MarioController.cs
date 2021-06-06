using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    public ParticleSystem sparks;
    public ParticleSystem explosion;
    public PanelController_1 player1;
    public PanelController_2 player2;

    private SoundManager sm;
    private GameManager gm;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
        sm = FindObjectOfType<SoundManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bottom1"))
        {
            player2.NotMain();
            player1.SetMain();
            player1.NotInPlay();
            player2.NotInPlay();
            gm.AddScore2(1);
            rb.velocity = Vector2.zero;
            rb.rotation = 0;
            explosion.transform.position = transform.position;
            explosion.Play();
            sm.PlayExplosion();
        }
        if (collision.collider.CompareTag("Bottom2"))
        {
            player1.NotMain();
            player2.SetMain();
            player1.NotInPlay();
            player2.NotInPlay();
            gm.AddScore1(1);
            rb.velocity = Vector2.zero;
            rb.rotation = 0;
            explosion.transform.position = transform.position;
            explosion.Play();
            sm.PlayExplosion();
        }
        if (collision.collider.CompareTag("Wall"))
        {
            sparks.transform.position = transform.position;
            sparks.Play();
            sm.PlaySpark();
        }
    }
}
