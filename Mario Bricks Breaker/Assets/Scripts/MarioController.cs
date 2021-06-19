using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    public ParticleSystem sparks;
    public ParticleSystem explosion;
    public PanelController_1 player1;
    public PanelController_2 player2;
    public GameConstants constants;

    private SoundManager sm;
    private GameManager gm;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
        sm = FindObjectOfType<SoundManager>();
        gameObject.transform.localScale = constants.marioOriginalSize;
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
            explosion.gameObject.SetActive(true);
            explosion.transform.position = transform.position;
            explosion.Play();
            sm.PlayExplosion();
            StartCoroutine(hideExplosion());
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
            explosion.gameObject.SetActive(true);
            explosion.transform.position = transform.position;
            explosion.Play();
            sm.PlayExplosion();
            StartCoroutine(hideExplosion());
        }
        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Brick"))
        {
            sparks.transform.position = transform.position;
            sparks.Play();
            sm.PlaySpark();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            gm.AddScore1(constants.coinValue);
            gm.AddScore2(constants.coinValue);
        }
        if (collision.CompareTag("Speed"))
        {
            rb.velocity *= constants.velocityMultiplier;
        }
        if (collision.CompareTag("Shrink"))
        {
            gameObject.transform.localScale *= constants.scaleMultiplier;
            StartCoroutine(restoreSize());
        }
    }

    IEnumerator hideExplosion ()
    {
        yield return new WaitForSeconds(1);
        explosion.gameObject.SetActive(false);
    }

    IEnumerator restoreSize()
    {
        yield return new WaitForSeconds(constants.shrinkEffectDuration);
        gameObject.transform.localScale = constants.marioOriginalSize;
    }
}
