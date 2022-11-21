using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SnowFlake : PowerCore
{
    public GameObject orbitalprefab;
    protected override int Index{get { return 2; }}
    protected override int NumOfShots{get { return -1; }}
    protected override float ShotSize{get { return -1; }}
    //stats : less shots and smaller
    //unique ability : summon orbital

    //synargy with 3,4,5
    //3(agony) static shock around orbital
    //4(crystal) orbital has spikes
    //5 (light) hexagonal prism rainbow
    private void Start()
    {
        Vector3 offset = new Vector3(this.transform.position.x, this.transform.position.y + 15, this.transform.position.z);
        GameObject orbital = Instantiate(orbitalprefab, offset,Quaternion.identity);
        orbital.GetComponent<SpringJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
    }

}
