using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DisplayPainting : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private TextAsset jsonFile;

    void Awake()
    {
        PaintingInfo info = JsonUtility.FromJson<PaintingInfo>(jsonFile.text);

        Transform frame = transform.Find("Frame");
        SpriteRenderer spriteRend = transform.Find("Painting").gameObject.GetComponent<SpriteRenderer>();

        // Set sprite
        spriteRend.sprite = sprite;

        // Set frame width
        float spriteWidth = Math.Max(spriteRend.bounds.size.x, spriteRend.bounds.size.z);
        float spriteFactor = 0.0145f;
        float frameWidth = spriteWidth / spriteFactor;
        frame.localScale = new Vector3(frame.localScale.x, frameWidth, frame.localScale.z);
    }
}

[System.Serializable]
public class PaintingInfo
{
    public string title, artist, year, description;

    public PaintingInfo(string _title, string _artist, string _year, string _description)
    {
        title = _title;
        artist = _artist;
        year = _year;
        description = _description;
    }
}
