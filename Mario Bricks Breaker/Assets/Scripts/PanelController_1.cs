using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController_1 : MonoBehaviour
{
    public GameObject initPosition;
    public Rigidbody2D mario;
    public float moveSpeed;
    public float leftBound;
    public float rightBound;
    public float shootForce;

    private GameManager gm;
    private float horizontalInput;
    private bool isMain;
    private bool inPlay;

    private void Start()
    {
        isMain = true;
        if (isMain) mario.transform.position = initPosition.transform.position;
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.IsGameStarted())
        {
            horizontalInput = Input.GetAxis("Horizontal");

            if (isMain && !inPlay) mario.transform.position = initPosition.transform.position;
            transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * moveSpeed);

            if (transform.position.y < leftBound)
            {
                transform.position = new Vector3(transform.position.x, leftBound, 0);
            }
            else if (transform.position.y > rightBound)
            {
                transform.position = new Vector3(transform.position.x, rightBound, 0);
            }
            if (Input.GetKeyDown(KeyCode.Space) && !inPlay && isMain)
            {
                mario.AddForceAtPosition(Vector2.right * shootForce, new Vector2(mario.transform.position.x + 0.1f, mario.transform.position.y), ForceMode2D.Impulse);
                inPlay = true;
                FindObjectOfType<SoundManager>().PlayShoot();
            }
        }
    }
    public void SetMain()
    {
        isMain = true;
    }

    public void NotMain()
    {
        isMain = false;
    }

    public void NotInPlay()
    {
        inPlay = false;
    }
}
