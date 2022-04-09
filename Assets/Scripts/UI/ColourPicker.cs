using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System;
using TMPro;

namespace TSGameDev.UI
{
    public class ColourPicker : MonoBehaviour
    {
        #region Private Variables

        [SerializeField] UnityEvent<Color> OnColourSelect;
        [SerializeField] UnityEvent<Color> OnColourPreview;

        RectTransform Rect;
        Texture2D Colourtexture;
        Color colour;

        #endregion

        #region Get-Setters

        public Vector2 mousePos { set; private get; }
        public InputAction.CallbackContext CallbackContext { private get; set; }

        #endregion

        // Start is called before the first frame update
        void Awake()
        {
            Rect = GetComponent<RectTransform>();
            Colourtexture = GetComponent<Image>().mainTexture as Texture2D;
        }

        // Update is called once per frame
        void Update()
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(Rect, mousePos))
            {
                Vector2 Delta;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, mousePos, null, out Delta);

                float width = Rect.rect.width;
                float height = Rect.rect.height;
                Delta += new Vector2(width * 0.5f, height * 0.5f);

                float x = Mathf.Clamp(Delta.x / width, 0f, 1f);
                float y = Mathf.Clamp(Delta.y / height, 0f, 1f);

                int texX = Mathf.RoundToInt(x * Colourtexture.width);
                int texY = Mathf.RoundToInt(y * Colourtexture.height);

                colour = Colourtexture.GetPixel(texX, texY);

                OnColourPreview?.Invoke(colour);

                if (CallbackContext.performed)
                {
                    OnColourSelect?.Invoke(colour);
                }
            }
        }
    }
}
