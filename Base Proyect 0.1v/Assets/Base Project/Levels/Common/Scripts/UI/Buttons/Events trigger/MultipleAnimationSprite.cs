using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class MultipleAnimationSprite : TriggerEvent
    {
        public List<Sprite> spritesList;

        private Image image;
        private int currentIndex;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public override void Callback()
        {
            image.sprite = spritesList[currentIndex];

            currentIndex++;

            if (currentIndex >= spritesList.Count) currentIndex = 0;
        }
    }
}