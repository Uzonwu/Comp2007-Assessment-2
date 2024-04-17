using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] GameObject TorchLight;
    private bool TorchLightActive = false;

    public AudioSource flick;
    // Start is called before the first frame update
    void Start()
    {
        TorchLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (TorchLightActive == false)
            {
                TorchLight.gameObject.SetActive(true);
                TorchLightActive = true;
                PlayFlick();
            }
            else
            {
                TorchLight.gameObject.SetActive(false);
                TorchLightActive = false;
                PlayFlick();
            }
        }
    }

    public void PlayFlick()
    {
        flick.Play();
    }
}
