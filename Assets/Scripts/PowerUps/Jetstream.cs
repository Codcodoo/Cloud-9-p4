using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetstream : PowerCore
{
    protected override int Index { get { return 8; } }
    protected override float LoadingTime { get { return +0.1f; } }
    protected override float Recoil { get { return -4000; } }
    protected override int NumOfShots { get { return 9; } }
    protected override float ShotsLag { get { return 0.05f; } }
    protected override float ShotSize { get { return -0.7f; } }
    protected override float ShotForce { get { return -7; } }
    protected override float Acceleration { get { return 3; } }
    //stats: a lot of weak small shots with low recoil  thats start slow and gets faster
    //unique:more contact damage but smaller
}
