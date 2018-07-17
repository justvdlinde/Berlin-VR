using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

    public Color color = Color.blue;

	void OnColorChange (HSBColor color) {
        this.color = color.ToColor();
	}

    public static ColorManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public Color GetCurrentColor()
    {
        return this.color;
    }
}
