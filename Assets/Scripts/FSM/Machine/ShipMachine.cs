using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMachine
{
    private bool sas;
    private bool rcs;
    public bool SAS { get { return sas; } set {  sas = value; OnSCSRCS_Changed(); } }
    public bool RCS { get { return rcs; } set {  rcs = value; OnSCSRCS_Changed(); } }

    public Dictionary<ShipStateKey, BaseState> shipStates;

    public ShipStateKey curState = ShipStateKey.None;

    public SpaceShip spaceShip;

    public ShipMachine(SpaceShip spaceShip)
    {
        this.spaceShip = spaceShip;
        Init();
    }

    public void Init()
    {
        shipStates = new Dictionary<ShipStateKey, BaseState>()
        {
            {ShipStateKey.SAS,new State_SAS(spaceShip)},
            {ShipStateKey.RCS,new State_RCS(spaceShip) },
            {ShipStateKey.None,new State_None(spaceShip) },
            {ShipStateKey.SASandRCS,new State_SASandRCS(spaceShip) }
        };
        ChangedState(ShipStateKey.None);
    }

    public void OnFixedUpdate()
    {
        shipStates[curState].OnFixedUpdate();
    }

    public void ChangedState(ShipStateKey shipStateKey)
    {


        if (curState == shipStateKey)
            return;
        Debug.LogWarning("当前状态:" + shipStateKey.ToString());
        shipStates[curState].OnExit();
        curState = shipStateKey;
        shipStates[curState].OnEnter();
    }

    public void OnSCSRCS_Changed()
    {
        if (!sas && !rcs) ChangedState(ShipStateKey.None);
        else if (!sas && rcs) ChangedState(ShipStateKey.RCS);
        else if(sas && !rcs) ChangedState(ShipStateKey.SAS);
        else if(sas && rcs) ChangedState(ShipStateKey.SASandRCS);

    }



}
