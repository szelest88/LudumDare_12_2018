using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsManager : MonoBehaviour
{

    public enum ResourceType
    {
        CULTIST,
        WEALTH,
        ZEAL,
        NOTORITY
    }

    // val should be normalized to the range from 0 to 10
    static void setBarControllerInTransform(Transform t, ResourceType statnum, float val)
    {
        switch (statnum)
        {
            case ResourceType.CULTIST:
                t.Find("cultistBar").GetComponent<BarController>().setValue(val);
                break;
            case ResourceType.WEALTH:
                t.Find("wealthBar").GetComponent<BarController>().setValue(val);
                break;
            case ResourceType.ZEAL:
                t.Find("zealBar").GetComponent<BarController>().setValue(val);
                break;
            case ResourceType.NOTORITY:
                t.Find("notorityBar").GetComponent<BarController>().setValue(val);
                break;
        }
    }

    public static void UpdateDisplayedValueStatic(ResourceType statnum, float val)
    {
        setBarControllerInTransform(staticTransform, statnum, val);
    }

    public void UpdateDisplayedValue(ResourceType statnum, float val)
    {
        setBarControllerInTransform(transform, statnum, val);


    }

    static Transform staticTransform;
    // Use this for initialization
    void Start()
    {
        staticTransform = transform;
    }   

}
