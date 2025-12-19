using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class YarnscriptFunctions
{
    [YarnFunction("GetQuestString")] 
    public static string QuestString(string animal, string state)
    {
        switch (animal)
        {
            case "rabbit":
                switch (state)
                {
                    case "nothing":
                        return "- Get berries from the forest";
                    case "item":
                        return "- Retrieve the rabbit from the ocean";
                    case "animal":
                        return "- Deliver the rabbit to the control room";
                    case "done":
                        return "- Rabbit successfuly rescued";
                    default:
                        return "Imposible state";
                }
            case "snake":
                switch (state)
                {
                    case "nothing":
                        return "- Get the snake net from the messa";
                    case "item":
                        return "- Retrieve the snake from the mountains";
                    case "animal":
                        return "- Deliver the snake to the control room";
                    case "done":
                        return "- Snake successfuly rescued";
                    default:
                        return "Imposible state";
                }
            case "goat":
                switch (state)
                {
                    case "nothing":
                        return "- Get hay from the mountains";
                    case "item":
                        return "- Retrieve the goat from the messa";
                    case "animal":
                        return "- Deliver the goat to the control room";
                    case "done":
                        return "- Goat successfuly rescued";
                    default:
                        return "Imposible state";
                }
            case "monkey":
                switch (state)
                {
                    case "nothing":
                        return "- Get the vase from the ocean";
                    case "item":
                        return "- Retrieve the monkey from the forest";
                    case "animal":
                        return "- Deliver the monkey to the control room";
                    case "done":
                        return "- Monkey successfuly rescued";
                    default:
                        return "Imposible state";
                }
            default:
                return "Imposible animal";
        }
    }
    [YarnCommand("DisablePlayerControl")]
    public static void DisablePlayerControl()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerInput>().enabled = false;
    }

    [YarnCommand("FadeOut")] 
    public static void FadeOut()
    {
        GameObject FadeOutScreen = GameObject.FindGameObjectWithTag("Finish");
        GameObject Sound = GameObject.FindGameObjectWithTag("Sound");

        Sound.SetActive(false);
        FadeOutScreen.GetComponent<Animator>().SetTrigger("YouMadeIt");
        FadeOutScreen.GetComponent<AudioSource>().Play();
    }
    
    [YarnCommand("CloseGame")] 
    public static void CloseGame()
    {
        Application.Quit();
    }
}
