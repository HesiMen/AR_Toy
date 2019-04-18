using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EventManagerScript : MonoBehaviour
{
    public List<PlayOnStateChange> notes; // AudioPlayer
    bool allNotesFinished = true;
    [HideInInspector]
    public bool playAllNotes = false;


    void Start()
    {

    }

    void Update()
    {
        Debug.Log(playAllNotes);
        if (Input.GetKeyDown(KeyCode.L) && allNotesFinished)
        {
            allNotesFinished = false;
            StartCoroutine(PlayNotes());
        }

        if (playAllNotes)
        {
            if (allNotesFinished)
            {
                allNotesFinished = false;
                if (notes != null)
                {
                    StartCoroutine(PlayNotes());
                }
                else
                {

                    Debug.Log("Nothing on the List");
                }
            }
        }
        else
        {
            if (allNotesFinished)
            {
                allNotesFinished = true;
                if (notes != null)
                {
                    StopCoroutine(PlayNotes());
                }
                else
                {
                    Debug.Log("Nothing on the List");
                }
            }
        }



    }

    IEnumerator PlayNotes()
    {
        foreach (PlayOnStateChange note in notes)
        {
            //Add Pulse HERE
            yield return note.PlayOnAppear();
        }

        allNotesFinished = true;
    }

    public void AddtoList(PlayOnStateChange notesAdded)
    {
        Debug.Log("note Added");
        notes.Add(notesAdded);


    }

    public void DeList(PlayOnStateChange notesSubtracted)
    {

        notes.Remove(notesSubtracted);

    }


    public void PlayEvent()
    {
        StartCoroutine(PlayNotes());
        if(playAllNotes == true)
        {
            playAllNotes = false;
        }
    }


    public void LoopPlayEvent()
    {
        StartCoroutine(PlayNotes());
        playAllNotes = true;
    }

    public void StopEvent()
    {
        playAllNotes = false;

    }


}


