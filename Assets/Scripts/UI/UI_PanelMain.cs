using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PanelMain : MonoBehaviour
{

    public SpaceShip spaceShip;

    public Toggle SAS_Toggle;
    public Toggle RCS_Toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSAS(bool boo)
    {
        spaceShip.shipMachine.SAS = SAS_Toggle.isOn;
    }

    public void OnClickRCS(bool boo)
    {
        spaceShip.shipMachine.RCS = RCS_Toggle.isOn;
    }
}
