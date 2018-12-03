using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour {
    public Transform ball, halfBall;

    // Use this for initialization

    public List<GameObject> gameObjects;
    public List<SpriteRenderer> spriteRenderers;

	void Start () {
        Transform firstBall = ball;
        for (int i = 0; i < 10; i++)
        {
            GameObject t = Instantiate(halfBall.gameObject);
            gameObjects.Add(t);
            Color targetColor = color;
            targetColor.a = 255;
            spriteRenderers.Add(t.GetComponent<SpriteRenderer>());
            t.GetComponent<SpriteRenderer>().color = targetColor;
            t.transform.localScale = new Vector3(0.08f, 0.08f, 0);
            t.transform.SetParent(this.transform);
            t.transform.localPosition = new Vector3(-3.5f + i * 0.5f, 0, 0);
        }
        // firstBall.gameObject.SetActive(false);
    }

    [Range(0, 20)]
    public float value;

    /// <summary>
    /// sets the value, normalized to 0..20
    /// </summary>
    /// <param name="value"></param>
    public void setValue(float value)
    {
        this.value = value;
    }

    public Color color;

    // maps 0...1 to R..G...R in 0..1
    Vector3 getColor(float val)
    {
        if (val <= 0.1f)
            val = 0;
        if (val <= 0.25f)
            return new Vector3(1, val * 4, 0); // ok
        if (val <= 0.5f)
            return new Vector3((0.5f-val) * 4f, 1, 0);
        if (val <= 0.75f)
            return new Vector3((val - 0.5f) * 4, 1, 0);
        else
            if (val <= 1.0f)
            return new Vector3(1, 1-(val - 0.75f) * 4, 0);
        else return new Vector3(1, 1, 1);



    }
    void UpdateStripe()
    {
        Color targetColor;

        targetColor.r = getColor(value * 0.05f).x;
        targetColor.g = getColor(value * 0.05f).y;
        targetColor.b = getColor(value * 0.05f).z;
        targetColor.a = 255;
        Color whiteA0 = Color.white;
        whiteA0.a = 255;

        for (int i = 0; i < (int)(value * 0.5); i++)
        {
    
            gameObjects[i].GetComponent<SpriteRenderer>().color = targetColor;
            gameObjects[i].GetComponentsInChildren<SpriteRenderer>()[1].color = targetColor;

        }
        for (int i = (int)(value*0.5); i < 10; i++)
        {
            gameObjects[i].GetComponent<SpriteRenderer>().color = whiteA0;
            gameObjects[i].GetComponentsInChildren<SpriteRenderer>()[1].color = whiteA0;
        }

        if ((int)value % 2 == 1)
        {

            gameObjects[(int)(value*0.5)].GetComponent<SpriteRenderer>().color = targetColor;

        }
    }
	// Update is called once per frame
	void Update () {
        UpdateStripe();
	}
}
