using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drop : MonoBehaviour
{
    public static float ShotLife = 1;
    public static float accelerate = 0;
    public static float shotsize = 1;
    public static float shotsizeinc = 1;

    public ParticleSystem explodefx;
    private Rigidbody2D rb;
    private Vector3 startsize;
    float timer = 0;
    bool knocked = false;
    Vector2 velStart;
    private GameObject player;

    private SpringJoint2D chain;
    
    void Start()
    {
        this.transform.localScale = new Vector3(shotsize, shotsize, this.transform.localScale.z);
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
        velStart = this.GetComponent<Rigidbody2D>().velocity;
        startsize = this.transform.localScale;
        StartCoroutine(Delete());
        IncreaseShotSize();
        HasChain();
    }
    void FixedUpdate()
    {
        if (!knocked){Acceleration();}
        timer += Time.deltaTime;
        //ChainBoomerang();
        IncreaseShotSize();
    }
    public void IncreaseShotSize()
    {
        this.transform.localScale = Vector3.Lerp(startsize, startsize * shotsizeinc, timer / ShotLife);
    }
    public void Acceleration()
    {
        rb.velocity = Vector2.Lerp(velStart, velStart * accelerate, timer/ShotLife);
        //rb.AddForce(-velStart.normalized)
    }
    IEnumerator Delete()//destroy drop at end of life
    {
        yield return new WaitForSeconds(ShotLife);
        if (!knocked)
        {
            Instantiate(explodefx, this.transform);
            Destroy(gameObject,0.3f);
        }
        else{Destroy(gameObject, ShotLife + 0.3f);}//remain longer if knocked
    }
    void Knock(ContactPoint2D hit)
    {
        knocked = true;
        this.transform.localScale *= 2;
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(hit.normal.normalized * 300);
        Instantiate(explodefx, this.transform);
    }
    public void HasChain()
    {
        if (PowerCore.powerups[1])//chain power up
        {
            rb.mass = 0;
            chain = this.GetComponent<SpringJoint2D>();
            chain.enabled = true;
            chain.connectedBody = player.GetComponent<Rigidbody2D>();
        }
    }
    //public void ChainBoomerang()
    //{
    //    chain.distance = Mathf.Lerp(7, 0, timer / ShotLife);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Cloud")
        {
            //Destroy(gameObject);
        }
        if (collision.collider.tag == "Cannon"&&!knocked){ Knock(collision.GetContact(0));}
    }
}
