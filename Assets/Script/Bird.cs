using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public Transform pivote;
    public float range;
    public float velocidad = 10;
    public GameObject explosion;
    bool drag = true;
    Rigidbody2D rb;
    Vector3 dist;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.IsSleeping() && !drag)
        {
            if(explosion != null)
            {
                GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            }
            Destroy(gameObject, 0.1f);
        }
    }

    void OnMouseDrag()
    {
        if (drag)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dist = pos - pivote.position;

            dist.z = 0;
            if (dist.magnitude > range)
            {
                dist = dist.normalized * range;
            }
            transform.position = dist + pivote.position;
        }
    }

    private void OnMouseUp()
    {
        if (drag)
        {
            drag = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = -dist.normalized * velocidad * dist.magnitude / range;
        }
    }
}
