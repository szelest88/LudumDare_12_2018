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
    public void SetValueForStat(ResourceType statnum, float val)
    {
        switch (statnum)
        {
            case ResourceType.CULTIST:
                transform.Find("cultistStripe").GetComponent<BarController>().setValue(val);
                break;
            case ResourceType.WEALTH:
                transform.Find("wealthStripe").GetComponent<BarController>().setValue(val);
                break;
            case ResourceType.ZEAL:
                transform.Find("zealStripe").GetComponent<BarController>().setValue(val);
                break;
            case ResourceType.NOTORITY:
                transform.Find("notorityStripe").GetComponent<BarController>().setValue(val);
                break;
        }

    }
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
