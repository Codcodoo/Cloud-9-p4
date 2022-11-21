using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Waterspout : PowerCore
{
    protected override int Index{get { return 1; }}
    protected override float Dmg {get { return 1; }}
    protected override float LoadingTime{get { return 0.5f; }}
    protected override float Recoil{get { return 3000; }}
    protected override float ShotLife{get { return 1; }}
    protected override float ShotSize{get { return 1; }}
    protected override float ShotSizeInc{get { return -0.3f; }}
    //stats : bigger stronger  with less range and stay
    //unique ability : shot remain on a chain

    //synargy with 2,3,4,5
    //2(orbital) orbital cuts of the chain
    //3(agony) shots connected to you do shock too
    //4(spike) chain damgages
    //5(light) light throuh shot is scatterd around
}
