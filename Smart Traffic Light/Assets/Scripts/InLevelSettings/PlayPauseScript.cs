using UnityEngine;

public class PlayPauseScript : MonoBehaviour
{
    public void Play() => Time.timeScale = 1;

    public void Pause() => Time.timeScale = 0;
}
