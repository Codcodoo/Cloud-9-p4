using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : PowerCore
{
    protected override int Index { get { return 9; } }
    protected override float Dmg { get { return 1; } }
    protected override float ShotLife { get { return 1f; } }
    protected override float ShotForce { get { return 1; } }
    protected override float Acceleration { get { return 1; } }
    protected override float ShotSizeInc { get { return 1; } }

    //stats : stronger accelrating shots
    //unique ability : shots orbit you
}
