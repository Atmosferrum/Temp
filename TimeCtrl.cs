using UnityEngine;

public class TimeCtrl : MonoBehaviour
{
    public bool pause = false; //Switch Pause
    public bool slowMo = false; //Switch SlowMo 

    //GET Current TimeScales
    public float timeScale()
    {
        float ts = 1;

        ts = !pause ? (ts = !slowMo ? 1f : .25f) : 0f;

        return ts;
    }

    void Update()
    {
        Time.timeScale = timeScale();
    }
}
