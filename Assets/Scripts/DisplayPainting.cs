using System;
using UnityEngine;
using TMPro;

public class DisplayPainting : MonoBehaviour
{
    private static CursorAppearance _cursorAppearance;
    private static Color _activatedDescColor, _deactivatedDescColor;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private TextAsset _jsonFile;
    private SpriteRenderer _spriteRend;
    private GameObject _description;
    private bool _isDescriptionActivated;

    private void Awake()
    {
        SetSprite();
        SetFrameWidth();
        SetText();
        SetActivationColors();
        ActivateDescription(false);
        GetCursorAppearanceScript();
    }

    private void OnMouseEnter()
    {
        _cursorAppearance.ChangeCursorAppearance(CursorAppearance.CursorState.CLICKABLE_TARGET);
    }

    private void OnMouseOver()
    {
        if (UserInput.Click)
        {
            SwitchDescriptionActivation();
            UserInput.Click = false;
        }
    }

    private void OnMouseExit()
    {
        _cursorAppearance.ChangeCursorAppearance(CursorAppearance.CursorState.DEFAULT);
    }

    public void SwitchDescriptionActivation()
    {
        ActivateDescription(!_isDescriptionActivated);
    }

    private void ActivateDescription(bool activated)
    {
        if (_isDescriptionActivated = activated)
        {
            _spriteRend.color = _activatedDescColor;
            _description.SetActive(true);
        }
        else
        {
            _spriteRend.color = _deactivatedDescColor;
            _description.SetActive(false);
        }
    }

    private void SetSprite()
    {
        _spriteRend = transform.Find("Painting").gameObject.GetComponent<SpriteRenderer>();
        _spriteRend.sprite = _sprite;
    }

    private void SetFrameWidth()
    {
        float spriteWidth = Math.Max(_spriteRend.bounds.size.x, _spriteRend.bounds.size.z);
        float spriteFactor = 0.0145f;
        float frameWidth = spriteWidth / spriteFactor;
        Transform frame = transform.Find("Frame");
        frame.localScale = new Vector3(frame.localScale.x, frameWidth, frame.localScale.z);
    }

    private void SetText()
    {
        PaintingInfo info = JsonUtility.FromJson<PaintingInfo>(_jsonFile.text);
        Transform infoCanvas = transform.Find("Canvas");
        TextMeshProUGUI descriptionText;

        TextMeshProUGUI labelText = infoCanvas.Find("Label").GetComponent<TextMeshProUGUI>();
        labelText.text = "\"" + info.title + "\"\n" + info.artist + "\n" + info.year;

        _description = infoCanvas.Find("Description").gameObject;
        descriptionText = _description.GetComponent<TextMeshProUGUI>();
        descriptionText.text = info.description;
    }

    private void SetActivationColors()
    {
        _activatedDescColor = new Color(0.11f, 0.09f, 0.09f, 1f); // #1C1717
        _deactivatedDescColor = new Color(1f, 1f, 1f, 1f); // #FFF
    }

    private void GetCursorAppearanceScript()
    {
        _cursorAppearance = GameObject.Find("Cursors").GetComponent<CursorAppearance>();
    }
}
