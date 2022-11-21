using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StaticShock : PowerCore
{
    protected override int Index{get { return 3; }}
    protected override float LoadingTime{get { return 0.1f; }}
    protected override float Recoil{get { return -2000; }}
    protected override float ShotForce{get { return 2; }}

    //stats : less recoil faster shot
    //unique ability : hit radius around you when damaged (agony)

    ////synargy with 4,5
    //4(spike) trigger shock when spike hits
    //5(light) second light beam comes fro spike
    public void Agony()
    {
        Collider2D[] enemysClose = Physics2D.OverlapCircleAll(this.transform.position, 3);
        foreach (Collider2D e in enemysClose)
        {
            //e.GetComponent<Enemy>().Hurt();

            //Vector2 edir = e.transform.position - this.transform.position;
            //edir.Normalize();
            //edir *= 500;
            //e.GetComponent<Rigidbody2D>().AddForce(edir);

            //screenshake
            //draw lightning explotion
            //draw shockwave
        }
    }
}

