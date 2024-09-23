using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField] AudioSource[] audios;

    public void Play() 
    { 
        int index = Random.Range(0,audios.Length);
        audios[index].Play();
    }
}
