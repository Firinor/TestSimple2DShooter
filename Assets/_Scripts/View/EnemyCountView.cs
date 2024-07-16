using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class EnemyCountView : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        var levelData = ServiseLocator.instance.GetService<LevelData>();
        if (levelData != null)
            levelData.EnemyCount.OnValueChange += ChangeText;
        ChangeText(levelData.EnemyCount.Value);
    }

    private void ChangeText(int count)
    {
        text.text = "ENEMIES LEFT: " + count;
    }

    private void OnDestroy()
    {
        var levelData = ServiseLocator.instance.GetService<LevelData>();
        if (levelData != null)
            levelData.EnemyCount.OnValueChange -= ChangeText;
    }
}