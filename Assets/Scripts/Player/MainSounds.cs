using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSounds : MonoBehaviour {
    public AudioClip clip;
    public float volume = 5;

    void Start() {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }
    void Update() {}
}
