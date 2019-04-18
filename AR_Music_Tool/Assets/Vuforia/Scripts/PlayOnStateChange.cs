using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//namespace CoroutineChain
//{
public class PlayOnStateChange : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject checkNext;
    public GameObject drawingLine;
    public Transform lilCubeTransform;

    // EventManagerScript noteList = GetComponentInChildren<EventManagerScript>();
    //noteList.AddtoList(player);
    // public GameObject noteList;

    public AudioClip noteClip;
    public AudioClip drumClip;


    public Dropdown dropdown;

    private int dropValue;
    
    // Start is called before the first frame update

    private float pitchFloat;
    private float speedFloat;
    private float VolumeFloat;
    private float distortFloat;

    private float shakeSpeed = 30f;
    private float shakeAmount = .01f;

    private bool isShake;


    private AudioSource source;

    private AudioEchoFilter distort;

    void Start()
    {
        source = GetComponent<AudioSource>();
        distort = GetComponent<AudioEchoFilter>();
        source.enabled = false;
        distort.enabled = false;

        

    }

    private void Update()
    {
        dropValue = dropdown.GetComponent<Dropdown>().value;


        if (!checkNext)
        {

        }
        else
        {
            pitchFloat = checkNext.GetComponent<CheckNext>().pitchChange;
            speedFloat = checkNext.GetComponent<CheckNext>().speedChange;
            distortFloat = checkNext.GetComponent<CheckNext>().distortChange;

        }
        //  Debug.Log("this is the speedFloat"+ speedFloat);
        if (isShake)
        {
            Vector3 shake = transform.position;
            shake.x = 0;
            shake.z = 0;
            shake.y = .25f + (Mathf.Sin(Time.time * shakeSpeed) * shakeAmount);
            checkNext.transform.localPosition = shake;
            StartCoroutine(waitOneSec());

        }
    }

    public void Initialized()
    {
        if (!source)
        {
            Debug.Log("no Source");
        }
        else
        {
            source.enabled = true;
            distort.enabled = true;
            gameManager.GetComponent<EventManagerScript>().AddtoList(this);
            drawingLine.GetComponent<DrawLine>().AddPosList(lilCubeTransform);
            
        }
    
    }
    public void Terminate()
    {

        if (!source)
        {
            Debug.Log("no Source");
        }
        else
        {
            source.enabled = false;
            distort.enabled = false;
            gameManager.GetComponent<EventManagerScript>().DeList(this);
            drawingLine.GetComponent<DrawLine>().DeListPos(lilCubeTransform);


        }
    }
    /*
    public void PlayOnAppear()
    {
        source.clip = appearClip;
        source.Play();
    }*/

    public IEnumerator PlayOnAppear()
    {
        if (dropValue == 0)
        {
            source.clip = noteClip;
        }
        if(dropValue == 1)
        {
            source.clip = drumClip;
        }
        //Debug.Log(pitchFloat);
        source.pitch = pitchFloat;
        distort.delay = distortFloat;
        Debug.Log(distortFloat);

        isShake = true;


        source.Play();
        yield return new WaitForSeconds(speedFloat);

    }

    public IEnumerator waitOneSec()
    {


        yield return new WaitForSeconds(1f);
        isShake = false;

    }


}
//}