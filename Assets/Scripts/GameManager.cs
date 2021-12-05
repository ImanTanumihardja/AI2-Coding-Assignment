using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The <c>GameManager<c> class controls the flow of the game.
    /// </summary>

    public UnityEvent onStartGame;
    public UnityEvent onEndGame;

    [SerializeField] private Transform trashPool;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource scoreAudio;
    [SerializeField] private ParticleSystem scorePS;
    [SerializeField] private ScreenFader screenFader;

    private int score = 0;
    private int totalCount;

    private void Awake()
    {
        Bin.onCollectedEvent += TrashCollected;
    }

    private void OnDestroy()
    {
        Bin.onCollectedEvent -= TrashCollected;
    }

    public void StartGame()
    {
        onStartGame?.Invoke();

        totalCount = trashPool.childCount;

        // Spawn tash
        foreach (Transform trash in trashPool)
        {
            Behaviour halo = (Behaviour) trash.gameObject.GetComponent("Halo");
            halo.enabled = true;

            float x = Random.Range(-4.5f, 4.5f);
            float y = Random.Range(0.0f, 2.0f);
            float z = Random.Range(-7.5f, 7.5f);
            trash.transform.position = new Vector3(x, y, z);
        }

        // Fade in score text
        StartCoroutine(Fade());
    }

    public void Restart()
    {
        StartCoroutine(RestartScene());
    }

    private IEnumerator RestartScene()
    {
        // Fade Black
        yield return screenFader.StartFadeIn();

        yield return new WaitForSeconds(1);

        // Reload Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        yield return null;
    }

    private void TrashCollected()
    {
        // Increment score and display updated score
        score++;
        scoreText.text = $"Trash Collected: {score}";

        // Play effects
        scoreAudio.Play();
        scorePS.Play();

        // Player finished
        if (score == totalCount)
        {
            scoreText.text = "Done";
            onEndGame?.Invoke();
        }

        Debug.LogFormat(this, "Trash Collected: {0}", score);
    }

    private IEnumerator Fade()
    {
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime;
            scoreText.color = new Color(0, 0, 0, timer);
            
            yield return null;
        }
    }
}
