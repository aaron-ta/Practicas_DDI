using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    SerialComm serialComm;
    string data = "";
    public Light PointLight;
    // Start is called before the first frame update
    bool lightF = true;
    private void Awake()
    {
        serialComm = FindObjectOfType<SerialComm>();
        PointLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        data = serialComm.getChar();
        if(serialComm == null){
            Debug.LogError("Serial Comm not found!");
            return;
        }
        if(data != null && data != "."){
            Debug.Log(data);
        }
        
        

        if(data == "O" && lightF == false){
            lightF = true;
            PointLight.enabled = true;
        }
        else if(data == "F" && lightF == true){
            lightF = false;
            PointLight.enabled = false;
        }
        
    }
}
