using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{

    [Header("按下何键时 此特效显示")]
    public KeyCode key;

    public GameObject glow;
    
    // Start is called before the first frame update
    void Start()
    {
        glow = transform.Find("Afterburner").gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        glow.SetActive(Input.GetKey(key));
    }
}
