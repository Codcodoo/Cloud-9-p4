using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downpour : PowerCore
{
    protected override int Index { get { return 7; } }
    protected override float LoadingTime { get { return +0.2f; } }
    protected override float Recoil { get { return -3000; } }
    protected override int NumOfShots { get { return 3; } }
    protected override float ShotsLag { get { return 0f; } }
    //stats: more shots with less lag and recoil
    //unique:splash expoltion on hit heavier body
}
