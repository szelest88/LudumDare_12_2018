using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    bool next = false;
    public TMPro.TextMeshPro tmp;
    public GameObject barLabels;
    public GameObject sigilLabels;
    
	// Use this for initialization
	void Start () {
        tmp = GameObject.Find("PlotTextDisplay").GetComponent<TMPro.TextMeshPro>();
        next = false;
        StartCoroutine(Tutorial(gameObject));
	}
	
	IEnumerator Tutorial(GameObject tutorial)
    {
        sigilLabels.SetActive(false);
        barLabels.SetActive(false);
        tmp.text = "YOU ARE THE ELDER ONE!!! GUIDE US WITH YOUR WISDOM! WE'RE LAST OF YOUR FOLLOWERS BUT I'M SURE THOU SHALT LEED US TO GLORY GREAT DARK ONE. WE SHALL FOLLOW YOUR EVERY WHIM AND BRING FORTH TIME OF END!!!";

        yield return new WaitUntil(() => next);
        next = false;

        sigilLabels.SetActive(true);

        tmp.text = "WE SHALL LOOK UPON YOUR SIGILS AND OBEY EVERY COMAND.";

        yield return new WaitUntil(() => next);
        next = false;
        sigilLabels.SetActive(false);
        barLabels.SetActive(true);

        tmp.text = "REMEMBER THAT ACTIONS TAKEN BY OUR BROTHERS HAVE CONSEQUENCES. TRY TO LEAD BALANCED CULT OR YOUR ONLY CHANCE FOR RESSURECTION MIGHT FALL APART";

        yield return new WaitUntil(() => next);
        next = false;

        tmp.text = "TO ACHIEVE THAT CULT NEED TO OBTAIN SACCRIFICIAL VIRGIN, POWERFULL RELIC AND AN ALTAR TO PERFORM RITUAL";

        tutorial.SetActive(false);
        GameObject.Find("Audio").GetComponent<MusicController>().TutorialEnd();
        GameController.Instance.GameStart();

        

        yield return null;


    }

    public void Continue()
    {
        next = true;
    }
}
