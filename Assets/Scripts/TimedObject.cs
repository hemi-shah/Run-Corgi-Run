using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    public float SecondsOnScreen = 1f;
    // Start is called before the first frame update
    public void Start()
    {
        // start the countdown to going away
        StartCoroutine(CountdownUntilDeath());
    }

    IEnumerator CountdownUntilDeath()
    {
        // wait some seconds
        yield return new WaitForSeconds(SecondsOnScreen);
        
        Destroy(gameObject);
    }
}
