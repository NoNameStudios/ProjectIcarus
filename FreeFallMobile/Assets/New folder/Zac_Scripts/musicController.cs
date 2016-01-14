using UnityEngine;
using System.Collections;

/*..........................................................*/
// ****************Script Programmer******************//
//****************************************************// 
// ******************//Zac Bogner//*******************//
/*..........................................................*/

public class musicController : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] gameMusic = new AudioClip[3];
    public float musicTimer = 0.0f;
    public bool playingOpen = false;
    public bool playingMain = false;
    public bool playingEnd = false;
    public bool mute = false;

    public bool gameOver = false;
    public GameObject gM;
    ZacGMScript mC;

    void Start()
    {
        audio.PlayOneShot(gameMusic[0]);
        if(audio.isPlaying && musicTimer >= 78 && playingOpen)
        {
            audio.Stop();
            playingMain = true;
        }
    }

    public void Update()
    {
        musicTimer += Time.deltaTime;
        if (audio.isPlaying && musicTimer >= 78 && playingOpen)
        {
            audio.Stop();
            playingOpen = false;
            audio.PlayOneShot(gameMusic[1]);
            playingMain = true;
        }
        if (!audio.isPlaying && musicTimer >= 220 && !playingMain)
        {
            playingMain = false;
            audio.Stop();
            audio.PlayOneShot(gameMusic[2]);
            playingMain = true;
        }
        if (mute)
        {
            audio.Stop();
        }
        if (ZacGMScript.gameOver == true && !playingEnd)
        {
            playingEnd = true;
            audio.Stop();
            audio.PlayOneShot(gameMusic[3]);
        }
    }
}

// 0 = gameStart Main Menu Music
// 1 = Main In Game Music 1
// 2 = Main In Game Music 2
// 3 = gameEnd GameOver Music and Credits 
