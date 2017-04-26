using System;
using UnityEngine;
public class NDPrefs : ScriptableObject
{
    private static NDPrefs instance;
    private static readonly Color[] defaultColors = new Color[]
        {
            Color.grey,
            new Color(0.545098066f, 0.670588255f, 0.9411765f),
            new Color(0.243137255f, 0.7607843f, 0.6901961f),
            new Color(0.431372553f, 0.7607843f, 0.243137255f),
            new Color(1f, 0.8745098f, 0.1882353f),
            new Color(1f, 0.5529412f, 0.1882353f),
            new Color(0.7607843f, 0.243137255f, 0.2509804f),
            new Color(0.545098066f, 0.243137255f, 0.7607843f)
        };
    private static readonly string[] defaultColorNames = new string[]
        {
            "Default",
            "Blue",
            "Cyan",
            "Green",
            "Yellow",
            "Orange",
            "Red",
            "Purple"
        };
    [SerializeField]
    private Color[] colors = new Color[]
        {
            Color.grey,
            new Color(0.545098066f, 0.670588255f, 0.9411765f),
            new Color(0.243137255f, 0.7607843f, 0.6901961f),
            new Color(0.431372553f, 0.7607843f, 0.243137255f),
            new Color(1f, 0.8745098f, 0.1882353f),
            new Color(1f, 0.5529412f, 0.1882353f),
            new Color(0.7607843f, 0.243137255f, 0.2509804f),
            new Color(0.545098066f, 0.243137255f, 0.7607843f),
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey,
            Color.grey
        };
    [SerializeField]
    private string[] colorNames = new string[]
        {
            "Default",
            "Blue",
            "Cyan",
            "Green",
            "Yellow",
            "Orange",
            "Red",
            "Purple",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
        };
    private static Color[] minimapColors;
    public static NDPrefs Instance
    {
        get
        {
            if (NDPrefs.instance == null)
            {
                NDPrefs.instance = (Resources.Load("PlayMakerPrefs") as NDPrefs);
                if (NDPrefs.instance == null)
                {
                    NDPrefs.instance = ScriptableObject.CreateInstance<NDPrefs>();
                }
            }
            return NDPrefs.instance;
        }
    }
    public static Color[] Colors
    {
        get
        {
            return NDPrefs.Instance.colors;
        }
        set
        {
            NDPrefs.Instance.colors = value;
        }
    }
    public static string[] ColorNames
    {
        get
        {
            return NDPrefs.Instance.colorNames;
        }
        set
        {
            NDPrefs.Instance.colorNames = value;
        }
    }
    public static Color[] MinimapColors
    {
        get
        {
            if (NDPrefs.minimapColors == null)
            {
                NDPrefs.UpdateMinimapColors();
            }
            return NDPrefs.minimapColors;
        }
    }
    public void ResetDefaultColors()
    {
        for (int i = 0; i < NDPrefs.defaultColors.Length; i++)
        {
            this.colors[i] = NDPrefs.defaultColors[i];
            this.colorNames[i] = NDPrefs.defaultColorNames[i];
        }
    }
    public static void SaveChanges()
    {
        NDPrefs.UpdateMinimapColors();
    }
    private static void UpdateMinimapColors()
    {
        NDPrefs.minimapColors = new Color[NDPrefs.Colors.Length];
        for (int i = 0; i < NDPrefs.Colors.Length; i++)
        {
            Color color = NDPrefs.Colors[i];
            NDPrefs.minimapColors[i] = new Color(color.r, color.g, color.b, 0.5f);
        }
    }
}
