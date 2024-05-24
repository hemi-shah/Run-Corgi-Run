using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour
{
    public GameObject ItemPrefab;
    protected float minimumSecondsUntilCreation = 1f;
    protected float maximumSecondsUntilCreation = 3f;
    
    private bool isWaitingToCreate = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaitingToCreate)
        {
            StartCoroutine(CountdownUntilCreation());
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        isWaitingToCreate = true;
        float secondsToWait = Random.Range(minimumSecondsUntilCreation, maximumSecondsUntilCreation);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        isWaitingToCreate = false;
    }

    protected virtual void Place()
    {
        // pick random place on screen
        // create a bone at spot on screen
        Instantiate(ItemPrefab, SpriteTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
