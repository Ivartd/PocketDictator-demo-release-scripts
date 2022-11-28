using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SawRotation : Rotation
{
    public SpriteRenderer sr;
    public Sprite bloodySawSprite; //new sprite of saw after collision with character

    //[SerializeField] private float speed = 2f;

    public void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        base.Rotating();
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sr.sprite = bloodySawSprite;
        }
    }

}
