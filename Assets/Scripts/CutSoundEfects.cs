using UnityEngine;

public class CutSoundEfects : MonoBehaviour
{
    private AudioSource efect;
    public AudioClip cutGoodSound;
    public AudioClip cutBadSound;
    void Start()
    {
        efect = GetComponent<AudioSource>();
    }

   public void CutBad(){
        efect.PlayOneShot(cutBadSound);
   }

    public void CutGood(){
        efect.PlayOneShot(cutGoodSound);
   }
}
