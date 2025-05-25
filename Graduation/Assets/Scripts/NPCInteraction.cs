using UnityEngine;
using UnityEngine.UI; // or TMPro if you're using TextMeshPro
using TMPro;


public class NPCInteraction : MonoBehaviour
{
    [Header("UI")]
    public GameObject promptUI; // Optional: world-space "..." or icon above NPC
    public TextMeshProUGUI dialogueTextUI; // The shared text in the UI Canvas

    [Header("Settings")]
    public float interactionDistance = 10f;
    [TextArea]
    public string npcLine = "Hi, traveler!"; // Custom text per NPC

    private Transform player;
    private bool isPlayerNear = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        promptUI?.SetActive(false);
        if (dialogueTextUI != null) dialogueTextUI.text = "";
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist <= interactionDistance)
        {
            if (!isPlayerNear)
            {
                ShowDialogue();
                isPlayerNear = true;
            }
        }
        else
        {
            if (isPlayerNear)
            {
                HideDialogue();
                isPlayerNear = false;
            }
        }
    }

    void ShowDialogue()
    {
        if (promptUI != null) promptUI.SetActive(true);
        if (dialogueTextUI != null) dialogueTextUI.text = npcLine;
    }

    void HideDialogue()
    {
        if (promptUI != null) promptUI.SetActive(false);
        if (dialogueTextUI != null) dialogueTextUI.text = "";
    }
}
