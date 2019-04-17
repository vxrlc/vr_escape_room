using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{

    [RequireComponent(typeof(Interactable))]

    public class KeySound : MonoBehaviour
    {

        public AudioSource keyAudio;
        private Interactable interactable;

        // Start is called before the first frame update
        void Awake()
        {
            keyAudio.GetComponent<AudioSource>();

            this.interactable.GetComponent<Interactable>();
        }
        // stops the audio if the hand touches the key
        private void OnHandHoverBegin(Hand hand)
        {
            keyAudio.Stop();
        }

    }
}
