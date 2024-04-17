using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSound : MonoBehaviour
{
    public AudioSource hover;
    public AudioSource click;

    public void HoverSound()
    {
        hover.Play();
    }

    public void ClickSound()
    {
        click.Play();
    }

}
