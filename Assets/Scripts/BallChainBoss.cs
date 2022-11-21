using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChainBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;//the swinging weapon

    HingeJoint2D chain;
    JointMotor2D mot;

    Rigidbody2D ballrb;//ball rigidbody
    Rigidbody2D bodyrb;//body rigidbody

    public Vector2 bodypos;//base position of the body
    public Vector2 bodyposrange;//body position when in attack range
    public Vector2 ballonplat;//height of the ball above the platform by default(size of the chain)
    public float hp=5;//health points
    public float swingforce=100;//the force of the side swings
    public float spikeforce=100;//the force of the shooting spikes
    public float swingamount = 3;//how many swing for the set
    float count=0;//swings so far this set
    public float swinginc=1;//increasing multiplayer for swing force

    float anchory=0;
    public float timer=0;

    bool right = true;//next swing is right
    bool left = false;

    bool pool = false;//initiate pullback to regain height and prepere to shoot

    bool shootball = false;

    bool swing = false;//time for swing phase
    public GameObject[] spikes = new GameObject[15];//all the shooting spikes

    public ParticleSystem hailfx;
    JointAngleLimits2D lim;

    void Start()
    {
        //when in center of the arena the ball drops right over your head and shoot 100 spikes around you missing only you
        //he then swings right, faster left, fastest right and slides a bit down where you can shoot him while dodging the third swing
        //he then shoots spikes while you dodge under platform and then pulls ball back, kicking himself back up and then shoots downwords
        //breaks the platform into two pieces and starts swinging again.
        //on the third he goes faster but then fourth under platform and fifth is the right time to attack
        ballrb = ball.GetComponent<Rigidbody2D>();
        bodyrb = this.GetComponent<Rigidbody2D>();
        swing = true;
        chain = this.GetComponent<HingeJoint2D>();
        mot = chain.motor;
    }

    // Update is called once per frame
    void Update()
    {
        Swing();
        if (pool)
        {
            timer += Time.deltaTime;
            anchory = Mathf.SmoothStep(0, 10, timer);
            chain.anchor = new Vector2(0, anchory);
            StartCoroutine(DelayShootBall());
        }
        if (shootball)
        {
            ShootBall();
        }
    }
    void Swing()
    {
        //add force to the ball in one direction and then at peak add double the force, and triple the force at the third
        //tweak chain length that changes ball height between swings and after a set of swings increase the basic swing force
        if (swing)
        {
            timer += Time.deltaTime;
            if (count < swingamount)//if still have swings
            {
                if (right){SwingRight();}//rigt
                if(left){SwingLeft();}//left
                if (count == 3 || count == 5)//fourht and sixth swings are low
                {   
                    
                    anchory = Mathf.SmoothStep(0, -14, timer*3) ;
                    chain.anchor = new Vector2(0, anchory);
                }
                if (count == 4 || count == 6)//bring height back
                {
                   
                    anchory = Mathf.SmoothStep(-14, 0, timer *3);
                    //Debug.Log(anchory);
                    chain.anchor = new Vector2(0, anchory);

                }

                if (count+1==swingamount)//drop body right on time for finel swing
                {
                    //screenshake
                    //under the platform is crashed
                    //this.transform.position = bodyposrange;
                    //chain.anchor = new Vector2(chain.anchor.x, chain.anchor.y + 5);
                }
            }
            else
            {
                this.transform.position = bodypos;
                swingamount += 2;
                swingforce += 20;
                swinginc += 1;
                count = 0;
                swing = false;
                chain.useMotor = false;
                timer = 0;
               StartCoroutine(DelayShootSpikes());
                Debug.Log("prepere next set");
                pool = true;
            }
        }

    }
    //void ShootSpikes()
    //{
    //}
    void ShootBall()
    {
        timer += Time.deltaTime;
        anchory = Mathf.SmoothStep(10, -5, timer * 3);
        chain.anchor = new Vector2(0, anchory);
        //mot.motorSpeed = 0;
        //chain.motor = mot;
        //ball.transform.position = new Vector2(0, 10);
        //ballrb.AddForce(Vector2.down * swingforce);
        //if (ball.transform.position.y<ballonplat.y)
        //{
        //    ball.transform.position = ballonplat;
        //    //chain length correction
        //    swing = true;
        //    chain.useMotor = true;
        //}

    }
    void SwingRight()
    {
        //ballrb.AddForce(Vector2.right * swingforce * swinginc);
        mot.motorSpeed = swingforce*swinginc;
        chain.motor = mot;
        if (chain.jointAngle>=chain.limits.max)
        {
            right = false;
            StartCoroutine(HoldLimit(true));
        }
       
    }
    void SwingLeft()
    {
        mot.motorSpeed = -swingforce *swinginc;
        chain.motor = mot;
        if (chain.jointAngle <= chain.limits.min)
        {
            left = false;
            StartCoroutine(HoldLimit(false));
        }
    }

    IEnumerator DelayShootBall()
    {
        lim.max = 0;
        lim.min = 0;
        chain.limits = lim;
        yield return new WaitForSeconds(2);
        timer = 0;
        pool = false;
        shootball=true;
    }
    IEnumerator DelayShootSpikes()
    {
        yield return new WaitForSeconds(2);
        //ShootSpikes();
    }
    IEnumerator HoldLimit(bool holdright)
    {
        if (holdright)
        {
            Instantiate(hailfx, ball.transform.position, Quaternion.Euler(0,0,0));
        }
        if (!holdright)
        {
            Instantiate(hailfx, ball.transform.position, Quaternion.Euler(0, 0, 180));
        }
        yield return new WaitForSeconds(1f);
        if (holdright){left = true;}
        else{right = true;}
        swinginc++;
        count++;
        timer = 0;
    }
}
