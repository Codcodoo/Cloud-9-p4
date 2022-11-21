using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Crystal : PowerCore
{
    public GameObject crystalprefab;
    protected override int Index { get { return 4; } }
    protected override float Dmg { get { return -1; } }
    protected override float LoadingTime { get { return -0.1f; } }
    protected override float Recoil { get { return 2000; } }
    protected override float ShotLife { get { return -0.3f; } }
    //stats : less damage more recoil
    //unique ability : summon Crystal at your back

    ////synargy with 5
    private void Start()
    {
        Vector3 offset = new Vector3(this.transform.position.x, this.transform.position.y -1, this.transform.position.z);
        GameObject crystal = Instantiate(crystalprefab, offset,Quaternion.identity,GameObject.FindGameObjectWithTag("Player").transform);
    }

}
