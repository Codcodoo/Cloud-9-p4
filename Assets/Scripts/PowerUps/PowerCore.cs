using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerCore : MonoBehaviour
{
    public static bool[] powerups = new bool[11];
    protected GameObject player;
    protected Player ps;//playerscript

    protected abstract int Index { get; } //item index
    protected virtual float Dmg { get { return 0; } } //damage
    protected virtual float LoadingTime { get { return 0; } } //load time
    protected virtual float Recoil { get { return 0; } } // recoil force
    protected virtual float ShotLife { get { return 0; } } //shot life time    
    protected virtual float ShotForce { get { return 0; } } //shot speed
    protected virtual int NumOfShots { get { return 0; } } //number of bullets in shot
    protected virtual float ShotsLag { get { return 0; } } //intervals between bullets in one shot
    protected virtual float Acceleration { get { return 0; } } // accelerate n shit
    protected virtual float ShotSize { get { return 0; } } // intial shot size
    protected virtual float ShotSizeInc { get { return 0; } } // shot size over time

    protected virtual float hp { get { return 0; } }//health points test
    protected virtual float spread { get { return 0; } }//bullet spread test

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.ps = player.GetComponent<Player>();
        Initiate();
    }
    public void Initiate()
    {
        powerups[this.Index] = true;         //Index
        this.ps.Loadtime += this.LoadingTime;//LoadingTime
        this.ps.recoil += this.Recoil;       //Recoil
        this.ps.shotspeed += this.ShotForce; //ShotSpeed
        this.ps.Shellsize += this.NumOfShots;//NumOfShots
        this.ps.ShotsLag += this.ShotsLag;   //TimeBetweenShots
        Drop.ShotLife += this.ShotLife;      //ShotLife
        Drop.accelerate += this.Acceleration;//Acceleration
        Drop.shotsize += this.ShotSize;      //ShotSize
        Drop.shotsizeinc += this.ShotSizeInc;//ShotSizeInc
    }

    //InitPowers();
    //SetLoad();
    //SetRecoil();
    //SetShotLife();
    //SetShotForce();
    //SetHowManyShots();
    //SetTimeBetweenShots();
    //SetAcceleration();
    //SetShotSize();
    //SetShotSizeInc();

    //public void InitPowers(){powerups[this.Index] = true;}
    //public void SetLoad(){this.playerScript.loadingtime += this.LoadingTime;}
    //public void SetRecoil(){this.playerScript.recoil += this.Recoil;}
    //public void SetShotLife(){Drop.ShotLife += this.ShotLife;}
    //public void SetShotForce(){this.playerScript.shotforce += this.ShotForce;}
    //public void SetHowManyShots(){this.playerScript.NumOfShots += this.NumOfShots;}
    //public void SetTimeBetweenShots(){this.playerScript.TimeBetweenShots += this.TimeBetweenShots;}
    //public void SetAcceleration(){Drop.accelerate += this.Acceleration;}
    //public void SetShotSize(){Drop.shotsize += this.ShotSize;}
    //public void SetShotSizeInc(){Drop.shotsizeinc += this.ShotSizeInc;}
}
