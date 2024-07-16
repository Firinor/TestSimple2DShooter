using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CanvasInjector : MonoBehaviour
{
    private void Awake()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        ServiseLocator.instance.GetService<GameRules>().parent = rectTransform;
        Destroy(this);
    }
}
