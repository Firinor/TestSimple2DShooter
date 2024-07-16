using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthView : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        var levelData = ServiseLocator.instance.GetService<LevelData>();
        if(levelData != null)
            levelData.PlayerHealth.OnValueChange += ChangeText;
        ChangeText(levelData.PlayerHealth.Value);
    }

    private void ChangeText(int count)
    {
        text.text = "HEALTH: " + count;
    }

    private void OnDestroy()
    {
        var levelData = ServiseLocator.instance.GetService<LevelData>();
        if (levelData != null)
            levelData.PlayerHealth.OnValueChange -= ChangeText;
    }
}
