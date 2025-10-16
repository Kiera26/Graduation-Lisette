using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    [Header("UI")]
    public GameObject promptUI;
    public TextMeshProUGUI dialogueTextUI;

    [Header("Settings")]
    public float interactionDistance = 10f;
    [TextArea]
    public string npcLine = "Hi, traveler!";

    [Header("Audio")]
    public AudioSource interactionAudioSource; // Assign AudioSource directly here

    private Transform player;
    private bool isPlayerNear = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        promptUI?.SetActive(false);
        if (dialogueTextUI != null) dialogueTextUI.text = "";

        if (interactionAudioSource == null)
        {
            Debug.LogWarning($"{name}: interactionAudioSource is not assigned!");
        }
        else
        {
            // Optional: configure audio source settings here if needed
            interactionAudioSource.playOnAwake = false;
            interactionAudioSource.loop = false;
        }
    }

    void Update()
    {
        if (player == null) return;

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

        if (interactionAudioSource != null)
        {
            interactionAudioSource.Play();
            Debug.Log($"{name}: Played interaction sound.");
        }
    }

    void HideDialogue()
    {
        if (promptUI != null) promptUI.SetActive(false);
        if (dialogueTextUI != null) dialogueTextUI.text = "";
    }
}
