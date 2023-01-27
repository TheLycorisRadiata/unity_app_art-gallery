using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DisplayPainting : MonoBehaviour
{
    [SerializeField] private int index;
    private Sprite painting;
    private PaintingInfo info;

    void Awake()
    {
        string relativePath = "Sprites/" + index + "/";
        string absolutePath = Application.dataPath + "/Resources/" + relativePath;
        string jsonText = "";

        painting = Resources.Load<Sprite>(relativePath + "image.jpg");

        jsonText = File.ReadAllText(absolutePath + "info.json");
        info = JsonUtility.FromJson<PaintingInfo>(jsonText);
    }
}
