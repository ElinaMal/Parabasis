using TMPro;
using UnityEngine;

public class MasksUI : MonoBehaviour
{
    public GameObject glow;

    public TMP_Text noMasks;

    public GameObject history;
    public TMP_Text historyInfo;
    public GameObject dance;
    public TMP_Text danceInfo;
    public GameObject music;
    public TMP_Text musicInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "JumpMask")
        {
            glow.SetActive(true);
            history.SetActive(true);
            historyInfo.enabled = true;
            noMasks.enabled = false;
        }
        else if (gameObject.name == "DashMask")
        {
            glow.SetActive(true);
            dance.SetActive(true);
            danceInfo.enabled = true;
            noMasks.enabled = false;
        }
        else if (gameObject.name == "StunMask")
        {
            glow.SetActive(true);
            music.SetActive(true);
            musicInfo.enabled = true;
            noMasks.enabled = false;
        }
    }
}
