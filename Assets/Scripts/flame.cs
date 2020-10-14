using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{
    public SpaceShip ship;

    [Header("按下何键时 此特效显示")]
    public KeyCode key;

    [Header("RCS模式下是否喷火")]
    public bool RCSisflame;

    [Header("SAS模式下是否喷火")]
    public bool SASisflame;

    [Header("SASandRCS模式下是否喷火")]
    public bool SASandRCSisflame;

    [Header("None模式下是否喷火")]
    public bool Noneisflame;

    public GameObject glow;
    
    // Start is called before the first frame update
    void Start()
    {
        glow = transform.Find("Afterburner").gameObject;
    }

    bool CheckIsFlame()
    {
        switch (ship.shipMachine.curState)
        {
            case ShipStateKey.None: return Noneisflame; break;

            case ShipStateKey.RCS: return RCSisflame; break;

            case ShipStateKey.SAS: return SASisflame; break;

            case ShipStateKey.SASandRCS: return SASandRCSisflame; break;
        }
        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(key))
        {
            if (CheckIsFlame())
                glow.SetActive(true);
        }
        else
        {
            glow.SetActive(false);
        }

        
    }
}
