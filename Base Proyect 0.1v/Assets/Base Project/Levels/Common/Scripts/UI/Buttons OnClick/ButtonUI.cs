using UnityEngine;
using Managers;

public class ButtonUI : MonoBehaviour
{
    public float reduceAmount = 1.0f;

    private Vector3 startSize;

    private void Awake()
    {
        startSize = transform.localScale;
    }

    /// <summary>
    /// Reduce the button scale
    /// </summary>
    public void PressDownAnimation()
    {
        transform.localScale -= startSize * reduceAmount;
    }

    /// <summary>
    /// Set the buttom scale to start size
    /// </summary>
    public void PressUpAnimation()
    {
        transform.localScale = startSize ;
    }
}