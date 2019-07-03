using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomColor : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	public Color[] colors;
    //Fod 0 do 100 jesli 0 to zawsze widoczne
    [Range(0.0f, 100.0f)]
    public int invisibleProbability = 30;
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        Generate();
	}

    //Generuj losowy kolor lub ukryj obiekt
	public void Generate(){
		if (invisibleProbability > 0 && Random.Range (0, 100) < invisibleProbability) {
            spriteRenderer.color = Color.clear;
			return;
		}
		int colorSelected = Random.Range (0, colors.Length);
		if (colors.Length > 0) {
            spriteRenderer.color = colors[colorSelected];
		}
	}
	
	void Update () {
	
	}
}
