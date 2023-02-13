using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class DisplayPainting : MonoBehaviour
{
    private static CursorAppearance cursorAppearance;
    private static Color activatedDescColor, deactivatedDescColor;
    [SerializeField] private Sprite sprite;
    [SerializeField] private TextAsset jsonFile;
    private SpriteRenderer spriteRend;
    private GameObject goDescription;
    private bool isDescriptionActivated;

    void Awake()
    {
        PaintingInfo info = JsonUtility.FromJson<PaintingInfo>(jsonFile.text);
        Transform infoCanvas = transform.Find("Canvas");
        TextMeshProUGUI labelText, descriptionText;

        float spriteWidth, spriteFactor, frameWidth;

        Transform frame = transform.Find("Frame");
        spriteRend = transform.Find("Painting").gameObject.GetComponent<SpriteRenderer>();

        // Set sprite
        spriteRend.sprite = sprite;

        // Set frame width
        spriteWidth = Math.Max(spriteRend.bounds.size.x, spriteRend.bounds.size.z);
        spriteFactor = 0.0145f;
        frameWidth = spriteWidth / spriteFactor;
        frame.localScale = new Vector3(frame.localScale.x, frameWidth, frame.localScale.z);

        // Set label text
        labelText = infoCanvas.Find("Label").GetComponent<TextMeshProUGUI>();
        labelText.text = "\"" + info.title + "\"\n" + info.artist + "\n" + info.year;

        // Set description text
        goDescription = infoCanvas.Find("Description").gameObject;
        descriptionText = goDescription.GetComponent<TextMeshProUGUI>();
        descriptionText.text = info.description;
        // Set the colors
        activatedDescColor = new Color(0.11f, 0.09f, 0.09f, 1f); // #1C1717
        deactivatedDescColor = new Color(1f, 1f, 1f, 1f); // #FFF
        // Deactivate it
        isDescriptionActivated = false;
        DescriptionActivation(isDescriptionActivated);

        // Cursor
        cursorAppearance = GameObject.Find("App Manager").GetComponent<CursorAppearance>();
    }

    private void DescriptionActivation(bool activate)
    {
        if (activate)
        {
            spriteRend.color = activatedDescColor;
            goDescription.SetActive(true);
        }
        else
        {
            spriteRend.color = deactivatedDescColor;
            goDescription.SetActive(false);
        }
    }

    public void SwitchDescriptionActivation()
    {
        isDescriptionActivated = !isDescriptionActivated;
        DescriptionActivation(isDescriptionActivated);
    }

    private void OnMouseEnter()
    {
        cursorAppearance.ChangeCursorAppearance(CursorAppearance.CursorState.CLICKABLE_TARGET);
    }

    private void OnMouseOver()
    {
        if (UserInput.click)
        {
            SwitchDescriptionActivation();
            UserInput.click = false;
        }
    }

    private void OnMouseExit()
    {
        cursorAppearance.ChangeCursorAppearance(CursorAppearance.CursorState.DEFAULT);
    }
}
