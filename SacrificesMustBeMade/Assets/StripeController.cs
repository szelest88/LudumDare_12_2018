using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StripeController : MonoBehaviour {
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
    public Color color;

    // maps 0...1 to R..G...R
    Vector3 getColor(float val)
    {
        float r = Mathf.Abs(0.5f - val) * 2;
        float g = Mathf.Abs(val - 0.5f)*2;
        if (val < 0.5f)
            g = 1;
        else if (val >= 0.5f)
            r = 1;

        return new Vector3(r,g,0);

    }
    void UpdateStripe()
    {

        for (int i = 0; i < value; i++)
        {
            Color targetColor;
            targetColor.r = getColor(value*0.1f).x*255;
            targetColor.g = getColor(value * 0.1f).y*255;
            targetColor.b = getColor(value * 0.1f).z*255;
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
