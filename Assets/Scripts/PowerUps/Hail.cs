using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hail : PowerCore
{
    protected override int Index { get { return 10; } }
    protected override float Dmg { get { return 2; } }
    protected override float LoadingTime { get { return +0.5f; } }
    protected override float Recoil { get { return 1000; } }
    protected override float Acceleration { get { return -0.1f; } }

    //stats: more damage slow load
    //unique:heavier body and shots affected by gravity
}
