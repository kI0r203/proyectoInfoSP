using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class romper : MonoBehaviour
{
    public float resistenciaMaterial;
    public GameObject explosion;

    public SpriteRenderer spriteRenderer;
    public Sprite semiroto;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > resistenciaMaterial)
        {
            if (explosion != null)
            {
                GameObject go = Instantiate (explosion,transform.position,Quaternion.identity); 
            }
            Destroy(gameObject, 0.1f);
        }
        else if(collision.relativeVelocity.magnitude > (resistenciaMaterial)/2)
        {
            ChangeSprite();
        }
        else
        {
            resistenciaMaterial -= collision.relativeVelocity.magnitude;
        }
    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = semiroto;
    }
}
