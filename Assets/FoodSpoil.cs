using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpoil : MonoBehaviour
{

    public float spoilTime;
    public float spoilLimit;
    public float spoilSpeed;

    public Material[] spoilMat = new Material[10];
    private Color[] spoilColor = new Color[10];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spoilMat.Length; i++)
        {
            spoilColor[i] = spoilMat[i].color;
        }
        StartCoroutine(spoilColorChange());
    }

    IEnumerator spoilColorChange()
    {
        while(spoilTime < spoilLimit)
        {
            for (int i = 0; i < spoilMat.Length; i++)
            {
                Debug.Log("\n" + this.name + " is spoiling in : " + (spoilLimit - spoilTime));
                spoilTime += spoilSpeed * Time.deltaTime;
                spoilMat[i].SetColor("_Color", new Vector4((spoilColor[i].r - spoilTime / 255), (spoilColor[i].g - spoilTime / 255), (spoilColor[i].b - spoilTime / 255), 1));
            }
            yield return null;
        }
        spoilTime = 0;
        Destroy(this.gameObject);
    }
}
