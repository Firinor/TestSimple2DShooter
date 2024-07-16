public interface ICanPause
{
    public void SubscribeToPause()
    {
        ServiseLocator.instance.GetService<PauseSystem>().InGameObjects.Add(this);
    }
    public void Pause();
    public void Unsubscribe()
    {
        ServiseLocator.instance.GetService<PauseSystem>().InGameObjects.Remove(this);
    }
}