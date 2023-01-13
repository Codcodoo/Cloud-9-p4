using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public GameObject drop;//shot projectile
    public LoadAmmo bar;//charge bar
    public GameManager gm;//game manager
    private Vector2 dir;//direction vector
    private GameObject center;//rotation pivot
    private Rigidbody2D rb;//player rb
    
    public AudioSource shotsfx;//gun sound
    public ParticleSystem cloudfx;//effect when on cloud
    public ParticleSystem shootfx;//effect on fire

    public float shotspeed = 10;//shot power
    public float recoil = 1000;//recoil force
    public float Loadtime = 0.5f;//loading time
    public float ShotsLag =0;//intervals between bullets in one shot
    public int Shellsize = 1; //number of bullets in one shot
    public float speed = 200;// wasd move speed
    public float ammomax = 1;//max amount of ammo
    public float ammo;//current ammo

    bool loaded = true;//loading time is over
    bool frozen = false;//player resisting recoil
    bool incloud = false;//if on cloud
    bool slide = false;//no drag
    bool coyote;//if player will coyote

    //public GameObject hammer;//hammer ability
    //Traverse speeds for keyboard
    //float defTrav = 200;
    //float rightTrav = -200;
    //float leftTrav = 200;
    void Start()
    {
        center = transform.GetChild(0).gameObject;//center is tanks first child
        ammo = ammomax;//reset ammo
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        dir = (center.transform.up).normalized;//direction aiming
        Aim();
        Shoot();
        Freeze();
        Move();
        //Hammer();
    }
    public void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 relPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = relPos - center.transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        center.transform.rotation = Quaternion.Slerp(center.transform.rotation, rot, 15 * Time.deltaTime);
    }
    public void Move()
    {
        if (incloud)//wasd movement
        {
            if (Input.GetKey(KeyCode.W)) { rb.AddForce(new Vector2(0, speed)); }//up
            if (Input.GetKey(KeyCode.S)) { rb.AddForce(new Vector2(0, -speed)); }//down
            if (Input.GetKey(KeyCode.A)) { rb.AddForce(new Vector2(-speed, 0)); }//left
            if (Input.GetKey(KeyCode.D)) { rb.AddForce(new Vector2(speed, 0)); }//right
        }
        else{
            if (Input.GetKey(KeyCode.A)) { rb.AddForce(new Vector2(-speed/2, 0)); }//left in cloud
            if (Input.GetKey(KeyCode.D)) { rb.AddForce(new Vector2(speed/2, 0)); }}//right in cloud
    }
    void Shoot()//shoot
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && loaded && ammo > 0)//shooting
        {StartCoroutine(ShootLag());}
    }
    IEnumerator ShootLag()//shoot shots
    {
        if (!incloud) { ammo--; }
        for (int i = 0; i < Shellsize; i++)
        {
            Vector3 pos = center.transform.position + center.transform.up; 
            Quaternion rot = Quaternion.Euler(0, 0, center.transform.rotation.z + 45); 
            GameObject shot = Instantiate(drop, pos,center.transform.rotation);

            Rigidbody2D shotrb = shot.GetComponent<Rigidbody2D>();
            shotrb.velocity = dir * shotspeed;

            Instantiate(shootfx, center.transform.position+center.transform.up,Quaternion.identity);//fire effect
            Cam.Instance.Shake(1f, 0.2f);//camshake   
            if (!frozen)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(-dir * recoil);
            }
            loaded = false;
            shotsfx.Play();
            yield return new WaitForSeconds(ShotsLag);
        }
        StartCoroutine(Load());
        StartCoroutine(Coyotejump());
    }
    public void Freeze()//Freeze recoil and slide
    {
        if (Input.GetKey(KeyCode.Mouse1)){
            frozen = true;
            slide = true;}
        else{
            slide = false;
            frozen = false;}
    }
    IEnumerator Load()//load gun
    {
        bar.LoadBar();
        yield return new WaitForSeconds(Loadtime);
        loaded = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Hazard")){gm.Restart();}
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            ammo = ammomax;
            incloud = true;
        }   
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")){incloud = false;}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Hazard")) {gm.Restart();}//hpdown
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Cloud")
        {
            cloudfx.Play();
            ammo = ammomax;
            rb.gravityScale = 0;
            if (slide){rb.drag = 0; }//drag in cloud if slide
            else {rb.drag = 3; }//drag in cloud
            incloud = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Cloud"){StartCoroutine(LeaveCloud());}
    }
    IEnumerator LeaveCloud()
    {
        if (coyote)
        {
            Vector2 leavedir = rb.velocity;
            leavedir.Normalize();
            rb.velocity = Vector2.zero;
            rb.AddForce(leavedir * recoil);
            coyote = false;
        }
        cloudfx.Pause();
        rb.drag = 1;//drag in air
        incloud = false;
        yield return new WaitForSeconds(0.15f);
        rb.gravityScale = 3f;// gravity in air
    }
    IEnumerator Coyotejump()
    {
        coyote = true;
        yield return new WaitForSeconds(0.2f);
        coyote = false;
    }
    // public void Hammer()
    //{
    //    if (Input.GetKey(KeyCode.LeftControl)) {hammer.SetActive(true);}//using hammer
    //    else {hammer.SetActive(false); }//not using hammer 
    //}

    //public void AimKeyboard()
    //{
    //    if (Input.GetKey(KeyCode.RightArrow)) // KeyboardAiming
    //    {
    //        if (rightTrav > -600) { rightTrav -= Time.deltaTime * 400; }
    //        leftTrav = defTrav;
    //        center.transform.Rotate(0, 0, rightTrav * Time.deltaTime);
    //    }
    //    else { rightTrav = -defTrav; }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        if (leftTrav < 600) { leftTrav += Time.deltaTime * 400; }
    //        rightTrav = -defTrav;
    //        center.transform.Rotate(0, 0, leftTrav * Time.deltaTime);
    //    }
    //    else { leftTrav = defTrav; }
    //}
}
