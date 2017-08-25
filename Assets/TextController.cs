//
//  TextController.cs
//  Text101
//
//  Created on August 24, 2017 by Animesh Mishra
//  Copyright (c) 2017 Animesh Ltd
//  All Rights Reserved
//

using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    public Text description;
    public Text prompt;

    private enum States
    {
        startPending,
        cell,
        mirror,
        sheets_0,
        lock_0,
        cell_mirror,
        sheets_1,
        lock_1,
        freedom
    };
    private States myState;

    // Use this for initialization
    void Start()
    {
        myState = States.startPending;
        description.text = "";
        prompt.text = "Press Space to start...";
    }

    // Update is called once per frame
    void Update()
    {
        switch (myState)
        {
            case States.startPending:
                if (Input.GetKeyDown(KeyCode.Space)) describeCell();
                break;


            // In cell and related states
            case States.cell:
                if (Input.GetKeyDown(KeyCode.S)) describeSheets0();
                else if (Input.GetKeyDown(KeyCode.M)) describeMirror();
                else if (Input.GetKeyDown(KeyCode.L)) describeLock0();
                break;
            case States.sheets_0:
                if (Input.GetKeyDown(KeyCode.R)) describeCell();
                break;
            case States.mirror:
                if (Input.GetKeyDown(KeyCode.T)) describeCellMirror();
                else if (Input.GetKeyDown(KeyCode.R)) describeCell();
                break;
            case States.lock_0:
                if (Input.GetKeyDown(KeyCode.R)) describeCell();
                break;


            // In cell holding mirror and related states
            case States.cell_mirror:
                if (Input.GetKeyDown(KeyCode.S)) describeSheets1();
                else if (Input.GetKeyDown(KeyCode.L)) describeLock1();
                break;
            case States.sheets_1:
                if (Input.GetKeyDown(KeyCode.R)) describeCellMirror();
                break;
            case States.lock_1:
                if (Input.GetKeyDown(KeyCode.O)) describeFreedom();
                else if (Input.GetKeyDown(KeyCode.R)) describeCellMirror();
                break;

            // Freedom
            case States.freedom:
                if (Input.GetKeyDown(KeyCode.Space)) describeCell();
                break;
        }
    }

    #region State handlers

    public void describeCell()
    {
        myState = States.cell;
        description.text = "You are in a prison cell, and you want to escape. " +
                           "There are some dirty sheets on the bed, a mirror " +
                           "on the wall, and the door is locked from the outside.";
        prompt.text = "Press S to inspect sheets, M to inspect mirror, and L " +
                      "to inspect lock";
    }

    public void describeMirror()
    {
        myState = States.mirror;
        description.text = "The dirty old mirror on the wall seems loose.";
        prompt.text = "Press T to take the mirror, or R return to romaing your cell";

    }

    public void describeSheets0()
    {
        myState = States.sheets_0;
        description.text = "You can't believe you sleep in these things. Surely it's " +
                           "time somebody change them. The pleasures of thug life " +
                           "I guess!";
        prompt.text = "Press R to return to romaing your cell";
    }

    public void describeLock0()
    {
        myState = States.lock_0;
        description.text = "This is one of those button locks. You have no idea what " +
                           "the combination is. You wish you could somehow see where " +
                           "the dirty fingerprints were, maybe that would help.";
        prompt.text = "Press R to return to roaming your cell";

    }

    public void describeCellMirror()
    {
        myState = States.cell_mirror;
        description.text = "You are still in your cell, and you STILL want to escape! " +
                           "There are some dirty sheets on the bed, a mark where the " +
                           "mirror was, and that pesky door is still there, and firmly " +
                           "locked!";
        prompt.text = "Press S to inspect sheets, or L to inspect lock";

    }

    public void describeSheets1()
    {
        myState = States.sheets_1;
        description.text = "Holding the mirror in your hand doesn't make the sheets " +
                           "look any better.";
        prompt.text = "Press R to return to romaing your cell";
    }

    public void describeLock1()
    {
        myState = States.lock_1;
        description.text = "You carefully put the mirror through the bars, and turn " +
                           "it round so you can see the lock. You can just make out " +
                           "fingerprints around the buttons. You press the dirty buttons, " +
                           "and hear a click.";
        prompt.text = "Press O to open, or R to return to romaing your cell.";
    }

    public void describeFreedom()
    {
        myState = States.freedom;
        description.text = "They may take your life, but they'll never take your " +
                           "FREEEEDOM!!!!!!";
        prompt.text = "Press Space to restart the game...";
    }

    #endregion
}