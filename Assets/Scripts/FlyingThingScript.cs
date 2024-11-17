using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingThingScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D flyingthingBody;
    public LogicScript logic;

    public float flapStrength;

    public bool birdIsAlive = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            flyingthingBody.velocity = Vector2.up * flapStrength;
            animator.SetTrigger("Flap");
        }

        if (birdIsAlive)
        {
            transform.eulerAngles = new Vector3 (0f, 180f, flyingthingBody.velocity.y * -1f);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
