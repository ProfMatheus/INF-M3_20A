using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void PlayStarlight()
    {
        MusicBox.instance.Stop();
        MusicBox.instance.Play("StarlightZone");
    }

    public void PlaySally()
    {
        MusicBox.instance.Stop();
        MusicBox.instance.Play("CatchUpSally");
    }
}
