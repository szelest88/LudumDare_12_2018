using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsManager : MonoBehaviour {

    public enum ResourceType
    {
        CULTIST,
        WEALTH,
        ZEAL,
        NOTORITY
    }
    // val should be normalized to the range from 0 to 10
    public  void UpdateDisplayedValue(ResourceType statnum, float val)
    {
        switch (statnum)
        {
            case ResourceType.CULTIST:
                transform.Find("cultistBar").GetComponent<BarController>().setValue(val);
                break;
            case ResourceType.WEALTH:
                transform.Find("wealthBar").GetComponent<BarController>().setValue(val);
                break;
            case ResourceType.ZEAL:
                transform.Find("zealBar").GetComponent<BarController>().setValue(val);
                break;
            case ResourceType.NOTORITY:
                transform.Find("notorityBar").GetComponent<BarController>().setValue(val);
                break;
        }

    }

    // val should be normalized to the range from 0 to 10
    public void setSomeTestValues()
    {
        Debug.LogError("TURN THIS OFF!");

        UpdateDisplayedValue(ResourceType.CULTIST, Random.Range(0,11));
        UpdateDisplayedValue(ResourceType.WEALTH, Random.Range(0, 11));
        UpdateDisplayedValue(ResourceType.ZEAL, Random.Range(0, 11));
        UpdateDisplayedValue(ResourceType.NOTORITY, Random.Range(0, 11));
    }
    // Use this for initialization
	void Start () {
    }
    // Update is called once per frame
    void Update () {
		
	}
}
