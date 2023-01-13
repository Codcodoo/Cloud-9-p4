using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Rigidbody2D player;
    public CircleCollider2D boundCollider;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == this.GetComponentInParent<PolygonCollider2D>())
        {
            if (boundCollider.bounds.Contains(collision.bounds.min) && boundCollider.bounds.Contains(collision.bounds.max))
            {
                Debug.Log("it's fully in boi");
            }
            else
            {
                Debug.Log(collision.bounds.min);
            }
        }

    }
}
