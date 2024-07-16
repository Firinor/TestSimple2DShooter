using System.Collections.Generic;

public class PauseSystem
{
    public List<ICanPause> InGameObjects = new();

    public void GameToPause()
    {
        foreach(var gameObject in InGameObjects)
        {
            gameObject.Pause();
        }
    }
}