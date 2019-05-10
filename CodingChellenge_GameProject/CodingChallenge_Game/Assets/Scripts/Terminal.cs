using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Terminal : MonoBehaviour
{
    private bool isInteractable;
    private DescriptionControl description;
    public GameObject SceneTransitionCanvas;
    public InputField _inputField;
    public TextMeshProUGUI _textMesh;
    private int numberOfCommands = 0;
    private int ntTerminalWasOpened = 0;
    private ConditionChecker condition;
    private Scene activeScene;

    void Start()
    {
        description = GetComponent<DescriptionControl>();
    }

    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();

        if (description.GetTimesDescritpionWasPoped() > 0 && isInteractable &&
        Input.GetButtonDown("Use"))
        {   
            SceneTransitionCanvas.GetComponent<Animator>().SetBool("toTerminal", true);
            ntTerminalWasOpened++;
        }

        if (description.GetTimesDescritpionWasPoped() > 0 && isInteractable &&
        Input.GetButtonDown("Use") && ntTerminalWasOpened > 0 && 
        SceneTransitionCanvas.GetComponent<Animator>().GetBool("exitTerminal"))
        {   
            SceneTransitionCanvas.GetComponent<Animator>().SetBool("exitTerminal", false);
            _inputField.ActivateInputField();
            _inputField.Select();
            ntTerminalWasOpened++;
        }

        if(SceneTransitionCanvas.GetComponent<Animator>().GetBool("toTerminal")
        && Input.GetButtonDown("Cancel"))
        {
            SceneTransitionCanvas.GetComponent<Animator>().SetBool("exitTerminal", true);
            SceneTransitionCanvas.GetComponent<Animator>().SetBool("toTerminal", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isInteractable = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = false;
        }
    }

    public void ToScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void ActivateInput()
    {
        _inputField.Select();
    }

    public void OnTextEnter() 
    {

        if (condition.GetNTTerminalWasUsed() == 0 && activeScene.buildIndex == 7)
            {
            if (_inputField.text == "shell")
            {
               DisplayText("...", _textMesh, "ACCESS GRANTED...\n"+
                                          "       FOR MORE INFORMATION TYPE 'HELP'");
               numberOfCommands++;
            }
            else if (numberOfCommands == 0)
            {
                DisplayText("..", _textMesh, "ACCESS DENIED");
                DisplayDelayedText(2f, "...", _textMesh, "ACCESS KEY REQUIRED");
            }
            else if (_inputField.text == "help" && numberOfCommands == 1)
            {
               DisplayText("..", _textMesh, "LIST OF AVAILIBLE COMMANDS:\n"+
                                            " 'SYSTEMS' | 'CONTROLS' | 'CHANGE USER'");
             numberOfCommands++;
            }
            else if (numberOfCommands == 1)
            {
                DisplayText("..", _textMesh, "WRONG INPUT");
                DisplayDelayedText(2f, "...", _textMesh, " FOR MORE INFORMATION TYPE 'HELP'");
            }
            else if (_inputField.text == "systems" && numberOfCommands == 2)
            {
                DisplayText(".......", _textMesh, "OPEN, KILL, EDIT\n"+
                                              "22101...........SPEAKERS\n"+
                                              "22014...........VENTIALTION\n"+
                                              "55142...........DOOR\n"+
                                              "55468...........HEATING");
                numberOfCommands++;
            }
            else if (numberOfCommands == 2 && !(_inputField.text == "controls" || _inputField.text == "change user"))
            {
                DisplayText("..", _textMesh, "WRONG INPUT");
                DisplayDelayedText(2f, "..", _textMesh, "LIST OF AVAILIBLE COMMANDS:\n"+
                                                        " 'SYSTEMS' | 'CONTROLS' | 'CHANGE USER'");
            }
            else if (numberOfCommands == 2 && (_inputField.text == "controls" || _inputField.text == "change user"))
            {
                DisplayText("..", _textMesh, "ACCESS DENIED");
                DisplayDelayedText(2f, "..", _textMesh, "LIST OF AVAILIBLE COMMANDS:\n"+
                                                    " 'SYSTEMS' | 'CONTROLS' | 'CHANGE USER'");
            }
            else if (_inputField.text == "open 55142" && numberOfCommands == 3)
            {
                DisplayText(".......", _textMesh, "DOOR OPENED");
                SceneTransitionCanvas.GetComponent<Animator>().SetBool("openDoor", true);
                condition.TerminalWasUsed();
            }
            else if (numberOfCommands == 3 && !(_inputField.text.Contains("speakers") ||
                _inputField.text.Contains("22101") || _inputField.text.Contains("open") ||
                _inputField.text.Contains("kill") || _inputField.text.Contains("edit") || 
                _inputField.text.Contains("ventilation") || _inputField.text.Contains("heating") ||
                _inputField.text.Contains("kill")))
            {
                DisplayText("..", _textMesh, "WRONG INPUT");
                DisplayDelayedText(2f, ".......", _textMesh, "OPEN, KILL, EDIT\n"+
                                              "22101...........SPEAKERS\n"+
                                              "22014...........VENTIALTION\n"+
                                              "55142...........DOOR\n"+
                                              "55468...........HEATING");
            }
            else if (numberOfCommands == 3 && _inputField.text.Contains("speakers") ||
                _inputField.text.Contains("22101") || _inputField.text.Contains("open") ||
                _inputField.text.Contains("kill") || _inputField.text.Contains("edit") || 
                _inputField.text.Contains("ventilation") || _inputField.text.Contains("heating") ||
                _inputField.text.Contains("kill"))
            {
                DisplayText("..", _textMesh, "CAN'T PERFORM THAT ACTION");
                DisplayDelayedText(2f, ".......", _textMesh, "OPEN, KILL, EDIT\n"+
                                              "22101...........SPEAKERS\n"+
                                              "22014...........VENTIALTION\n"+
                                              "55142...........DOOR\n"+
                                              "55468...........HEATING");
            }
            else 
            {
                DisplayText("...", _textMesh, "WRONG INPUT!");
            }
        }
        else 
        {
            DisplayText("..", _textMesh, "ACCES DENIED");
        }

        if (condition.GetNTTerminalWasUsed() == 1 && activeScene.buildIndex == 7)
            {
            if (_inputField.text == "shell")
            {
               DisplayText("...", _textMesh, "ACCESS GRANTED...\n"+
                                          "       FOR MORE INFORMATION TYPE 'HELP'");
               numberOfCommands++;
            }
            else if (numberOfCommands == 0)
            {
                DisplayText("..", _textMesh, "ACCESS DENIED");
                DisplayDelayedText(2f, "...", _textMesh, "ACCESS KEY REQUIRED");
            }
            else if (_inputField.text == "help" && numberOfCommands == 1)
            {
               DisplayText("..", _textMesh, "LIST OF AVAILIBLE COMMANDS:\n"+
                                            " 'SYSTEMS' | 'CONTROLS' | 'CHANGE USER'");
             numberOfCommands++;
            }
            else if (numberOfCommands == 1)
            {
                DisplayText("..", _textMesh, "WRONG INPUT");
                DisplayDelayedText(2f, "...", _textMesh, " FOR MORE INFORMATION TYPE 'HELP'");
            }
            else if (_inputField.text == "systems" && numberOfCommands == 2)
            {
               DisplayText(".......", _textMesh, "OPEN, KILL, EDIT\n"+
                                              "22101...........SPEAKERS\n"+
                                              "78412...........CAMERA_1\n"+
                                              "22410...........VENTIALTION\n"+
                                              "55787...........CALL");
                numberOfCommands++;
            }
            else if (numberOfCommands == 2 && !(_inputField.text == "controls" || _inputField.text == "change user"))
            {
                DisplayText("..", _textMesh, "WRONG INPUT");
                DisplayDelayedText(2f, "..", _textMesh, "LIST OF AVAILIBLE COMMANDS:\n"+
                                                        " 'SYSTEMS' | 'CONTROLS' | 'CHANGE USER'");
            }
            else if (numberOfCommands == 2 && (_inputField.text == "controls" || _inputField.text == "change user"))
            {
                DisplayText("..", _textMesh, "ACCESS DENIED");
                DisplayDelayedText(2f, "..", _textMesh, "LIST OF AVAILIBLE COMMANDS:\n"+
                                                    " 'SYSTEMS' | 'CONTROLS' | 'CHANGE USER'");
            }
            else if (_inputField.text == "kill 75412" && numberOfCommands == 3)
            {
                DisplayText("....", _textMesh, "CAMERA KILLED");
                SceneTransitionCanvas.GetComponent<Animator>().SetBool("openDoor", true);
                condition.TerminalWasUsed();
            }
            else if (numberOfCommands == 3 && !(_inputField.text.Contains("speakers") ||
                _inputField.text.Contains("22101") || _inputField.text.Contains("open") ||
                _inputField.text.Contains("kill") || _inputField.text.Contains("edit") || 
                _inputField.text.Contains("ventilation") || _inputField.text.Contains("call") ||
                _inputField.text.Contains("kill")))
            {
                DisplayText("..", _textMesh, "WRONG INPUT");
                DisplayDelayedText(2f, ".......", _textMesh, "OPEN, KILL, EDIT\n"+
                                              "22101...........SPEAKERS\n"+
                                              "78412...........CAMERA_1\n"+
                                              "22410...........VENTIALTION\n"+
                                              "55787...........CALL");
            }
            else if (numberOfCommands == 3 && _inputField.text.Contains("speakers") ||
                _inputField.text.Contains("22101") || _inputField.text.Contains("open") ||
                _inputField.text.Contains("kill") || _inputField.text.Contains("edit") || 
                _inputField.text.Contains("ventilation") || _inputField.text.Contains("call") ||
                _inputField.text.Contains("kill"))
            {
                DisplayText("..", _textMesh, "CAN'T PERFORM THAT ACTION");
                DisplayDelayedText(2f, ".......", _textMesh, "OPEN, KILL, EDIT\n"+
                                              "22101...........SPEAKERS\n"+
                                              "78412...........CAMERA_1\n"+
                                              "22410...........VENTIALTION\n"+
                                              "55787...........CALL");
            }
            else 
            {
                DisplayText("...", _textMesh, "WRONG INPUT!");
            }
        }
        else 
        {
            DisplayText("...", _textMesh, "ACCESS DENIED");
        }
    }

    IEnumerator LoadingText(string text, TextMeshProUGUI textMesh, string displayText) 
    {
        
        string currentText = "";
        for (int i = 0; i <= text.Length; i++)
        {
            currentText = text.Substring(0, i);
            textMesh.text = currentText;
            yield return new WaitForSeconds(0.4f);
        }
        textMesh.text = displayText;
    }

    private void DisplayText(string text, TextMeshProUGUI textMesh, string displayText) 
    {
        StartCoroutine(LoadingText(text, textMesh, displayText));
        _inputField.text = "";
        _inputField.ActivateInputField();
        _inputField.Select();
    }

    IEnumerator DelayText(float delay, string text, TextMeshProUGUI textMesh, string displayText) 
    {
        yield return new WaitForSeconds(delay);
        string currentText = "";
        for (int i = 0; i <= text.Length; i++)
        {
            currentText = text.Substring(0, i);
            textMesh.text = currentText;
            yield return new WaitForSeconds(0.4f);
        }
        textMesh.text = displayText;
        _inputField.text = "";
    }

    private void DisplayDelayedText(float delay, string text, TextMeshProUGUI textMesh, string displayText) 
    {
        StartCoroutine(DelayText(delay, text, textMesh, displayText));
        _inputField.text = "";
        _inputField.ActivateInputField();
        _inputField.Select();
    }

}
