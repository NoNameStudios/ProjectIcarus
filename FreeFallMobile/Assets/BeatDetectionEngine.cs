using UnityEngine;
using System.Collections;

public class BeatDetectionEngine : MonoBehaviour 
{
	private float[] spectrumData = new float[1024];
	private AudioSource audioSource = null;

    public GameObject spawner;
    SpawnManager spawnScript;

	public float c1 = 0.0f;
    public float c2 = 0.0f;
    public float c3 = 0.0f;
    public float c4 = 0.0f;
    public float c5 = 0.0f;

    /*PROTOTYPING JUNK*/
    /*public GameObject c1Cube = null;
    public GameObject c2Cube = null;
    public GameObject c3Cube = null;
    public GameObject c4Cube = null;
    public GameObject c5Cube = null;*/

    public float c1Threshold = .5f;
    public float c2Threshold = .2f;
    public float c3Threshold = .2f;
    public float c4Threshold = .2f;
    public float c5Threshold = .2f;

    /* Making a couple of assumptions here:
	 * sample rate of file is 44100 hz, so each channel (left / right) is 22050 hz
	 * each octave begins on C, so Cn - C(n-1) is a power of 2
	 * no song will go too far outside C1-C5. To subdivide, just split sub octaves by index?
     * Like C1sub2 would have indecies 2 and 3.
	 * 
	 * If you want to work in different octaves of C, these values work best:
	 * C1 (64 hz, 2^6) = 2,3,4
     * C2 (128 hz, 2^7) = 5,6,7
	 * C3 (256 hz, 2^8) = 11,12,13
	 * C4 (512 hz, 2^9) = 22,23,24
	 * C5 (1024 hz, 2^10) = 44,45,46,47,48,49 
	 */

    void Start()
	{
		audioSource = this.GetComponent<AudioSource> ();
        if (spawner == null)
            spawner = GameObject.Find("Spawner Manager");

        spawnScript = spawner.GetComponent<SpawnManager>();
	}
	
	void FixedUpdate()
	{
		/*Returns the volume level of different frequencies as a float clamped
		between 0 and 1; each index accounts for 21 hz (22050 / 1024 = ~21).*/
		audioSource.GetSpectrumData (spectrumData, 0, FFTWindow.Hamming);
        //c1 = spectrumData [2] + spectrumData [3] + spectrumData [4];
        //c2 = spectrumData[5] + spectrumData[6] + spectrumData[7];
        // c3 = spectrumData[11] + spectrumData[12] + spectrumData[13];
        // c4 = spectrumData[22] + spectrumData[23] + spectrumData[24];
        // c5 = spectrumData[44] + spectrumData[45] + spectrumData[46] + spectrumData[47] + spectrumData[48] + spectrumData[49];
        c1 = spectrumData[2];
        c2 = spectrumData[3];
        c3 = spectrumData[4]+ spectrumData[5];
        c4 = spectrumData[6] + spectrumData[7];
        c5 = spectrumData[11] + spectrumData[12] + spectrumData[13] + spectrumData[22] + spectrumData[23] + spectrumData[24];
    }

	void Update()
	{
        
        if (c1 > c1Threshold)
        {
            // c1Cube.GetComponent<MeshRenderer>().material.color = Color.red;
            spawnScript.Spawn(0);
        }
        else
        {
           // c1Cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        if (c2 > c2Threshold)
        {
            // c2Cube.GetComponent<MeshRenderer>().material.color = Color.blue;
            spawnScript.Spawn(1);
        }
        else
        {
           // c2Cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        if (c3 > c3Threshold)
        {
            // c3Cube.GetComponent<MeshRenderer>().material.color = Color.green;
            spawnScript.Spawn(2);
        }
        else
        {
           // c3Cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        if (c4 > c4Threshold)
        {
            //c4Cube.GetComponent<MeshRenderer>().material.color = Color.yellow;
            spawnScript.Spawn(3);
        }
        else
        {
           // c4Cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        if (c5 > c5Threshold)
        {
            // c5Cube.GetComponent<MeshRenderer>().material.color = Color.black;
            spawnScript.Spawn(4);
        }
        else
        {
           // c5Cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    public float getC1()
    {
        return c1;
    }
    public float getC2()
    {
        return c2;
    }
    public float getC3()
    {
        return c3;
    }
    public float getC4()
    {
        return c4;
    }
    public float getC5()
    {
        return c5;
    }
}