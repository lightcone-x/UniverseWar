using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShipStateKey
{
    None,
    RCS,
    SAS,
    SASandRCS,

}

public class BaseState 
{
    public SpaceShip spaceShip;

  


    public ShipStateKey stateKey;

    public virtual void OnEnter() { }
    public virtual void OnFixedUpdate() { }
    public virtual void OnExit() { }
}
