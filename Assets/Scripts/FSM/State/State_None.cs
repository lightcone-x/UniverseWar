using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_None : BaseState
{
    public State_None(SpaceShip spaceShip)
    {
        base.spaceShip = spaceShip;
    }


    public override void OnEnter() 
    {
        spaceShip.rigi.angularDrag = 1;
    }

    public override void OnFixedUpdate() 
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 force = spaceShip.transform.forward * spaceShip.MainEngine;
            Vector3 force1 = spaceShip.transform.forward * spaceShip.MainEngine;

            spaceShip.rigi.AddForceAtPosition(force, spaceShip.flame_Effects["main_engine"].transform.position); // 受力
            spaceShip.rigi.AddForceAtPosition(force1, spaceShip.flame_Effects["main_engine1"].transform.position);
        }
    }

    public override void OnExit() 
    { 

    }
}
