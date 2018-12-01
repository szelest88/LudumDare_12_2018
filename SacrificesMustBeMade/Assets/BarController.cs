using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour {
    public Transform ball;
    // Use this for initialization

    public List<GameObject> gameObjects;
    public List<SpriteRenderer> spriteRenderers;

	void Start () {
        Transform firstBall = ball.transform;
        for (int i = 0; i < 10; i++)
        {
            GameObject t = Instantiate(firstBall.gameObject);
            gameObjects.Add(t);
            Color targetColor = color;
            targetColor.a = 255;
            spriteRenderers.Add(t.GetComponent<SpriteRenderer>());
            t.GetComponent<SpriteRenderer>().color = targetColor;
            t.transform.localScale = new Vector3(0.02f, 0.02f, 0);
            t.transform.SetParent(this.transform);
            t.transform.localPosition = new Vector3(-3.5f + i * 0.75f, 0, 0);
        }
        // firstBall.gameObject.SetActive(false);
    }

    [Range(0, 10)]
    public int value;

    /// <summary>
    /// sets the value, normalized to 0..10
    /// </summary>
    /// <param name="value"></param>
    public void setValue(float value)
    {
        this.value = (int)value;
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

        for (int i = 0; i < value; i++)
        {

            Color targetColor;
           // Vector3 normalized = getColor(value * 0.1f) * 255;
            targetColor.r = getColor(value * 0.1f).x;
            targetColor.g = getColor(value * 0.1f).y;
            targetColor.b = getColor(value * 0.1f).z;
            targetColor.a = 255;
            color = targetColor;
            spriteRenderers[i].color = targetColor;
        }
        for(int i = value; i < 10; i++)
        {
            Color targetColor = Color.white;
            targetColor.a = 255;
            spriteRenderers[i].color = targetColor;
        }
    }
	// Update is called once per frame
	void Update () {
        UpdateStripe();
	}
}
