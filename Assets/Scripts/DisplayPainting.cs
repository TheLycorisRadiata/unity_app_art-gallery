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

        // Scale the sprite down
        Vector3 desiredScale = new Vector3(1.4f, 1.4f, 1f);
        spriteRend.transform.localScale = desiredScale;

        // Set frame size
        float spriteWidth = spriteRend.bounds.size.x;
        float frameWidth = 1.6f;
        float diff = spriteWidth - frameWidth;
        Debug.Log(diff);
        frame.localScale = new Vector3(frame.localScale.x, frame.localScale.y + diff, frame.localScale.z);
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
