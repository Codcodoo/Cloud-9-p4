using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LightBeam : PowerCore
{
    public GameObject lightprefab;
    protected override int Index{get { return 5; }}
    protected override float Dmg { get { return 1; } }
    protected override float ShotSize{get { return -1; }}
    //stats : less damage wider spread
    //unique ability : summon ray of light aoe

    //synargy with all but 0,1,2,3,4
    private void Start()
    {
        Vector3 offset = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        GameObject beam = Instantiate(lightprefab, offset,Quaternion.identity, GameObject.FindGameObjectWithTag("Cannon").transform);
    }

}
