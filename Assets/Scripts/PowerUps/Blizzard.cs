using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : PowerCore
{
    protected override int Index { get { return 6; } }
    protected override float LoadingTime { get { return -0.1f; } }
    protected override float Recoil { get { return -3000 ; } }
    protected override int NumOfShots { get { return 3; } }
    protected override float ShotsLag { get { return 0.1f; } }
    protected override float ShotSize { get { return -0.5f; } }

    //stats : more shots less recoil
    //unique ability : every shot splits to two small shots half way,rainfall under you all time
}
