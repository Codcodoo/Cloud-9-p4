using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Breeze : PowerCore
{
    protected override int Index { get { return 0; } }
    protected override float Dmg { get { return 1; } }
    protected override float LoadingTime { get { return -0.1f; } }
    protected override float Recoil { get { return 0; } }
    protected override float ShotLife { get { return 1f; } }
    protected override float ShotForce { get { return 5; } }
    protected override int NumOfShots { get { return 0; } }
    protected override float ShotsLag { get { return 0; } }
    protected override float Acceleration { get { return -1; } }
    protected override float ShotSize { get { return 0; } }
    protected override float ShotSizeInc { get { return 1; } }
}

    //stats : returns back (boomerang)
    //unique ability : pentrate enemies

    //synargy with 1,2,3,4,5
    //1(chain) shots pull to you
    //2(orbital) orbital can hit shots
    //3(agony) if the shot hit you trigger shock with no self damage
    //4(spike) hitting shot with spike explodes shot to 2 and shoots to both sides of you
    //5(light)leave paddle behind you that damages enemy
    //6(blizzard)
