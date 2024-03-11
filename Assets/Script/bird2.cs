using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird2 : MonoBehaviour
{

    public Transform pivote;
    public Transform pajaroAntes;
    public float range;
    public float velocidad = 10;
    bool drag = true;
    Rigidbody2D rb;
    Vector3 dist;
    bool desanimado = false;

    Animator animator;
    Animation anim;
    Transform pajaro;
    // Start is called before the first frame update
    void Start()
    {
        pajaro = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        //animator.SetTrigger("subir");
    }

    // Update is called once per frame
    void Update()
    {
        //print(pajaroAntes.position);
        if (Math.Abs(pajaroAntes.position.x) < 10 && desanimado == false)
        {
            desanimado = true;
            print("no anima");
            animator.SetTrigger("subir");
            StartCoroutine(EsperarYContinuar());
        }
    }

    void OnMouseDrag()
    {
        if (drag)
        {
            //print("Hola");
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dist = pos - pivote.position;

            dist.z = 0;
            if (dist.magnitude > range)
            {
                dist = dist.normalized * range;
            }
            transform.position = dist + pivote.position;
            print(transform.position);
        }
    }

    private void OnMouseUp()
    {
        if (drag) { drag = false; }
        //print(drag);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -dist.normalized * velocidad * dist.magnitude / range;
    }

    IEnumerator EsperarYContinuar()
    {
        yield return new WaitForSeconds(1f + 0.5f); // Espera 3 segundos
        animator.enabled = false;
    }
}
