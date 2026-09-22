using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;

    static public int SCORE
    {
        get {  return _SCORE; }
        set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", SCORE);
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = $"High Score: {value:#,0}";
            }
        }
    }

    private void Awake()
    {
        _UI_TEXT = GetComponent<Text>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public void TRY_SET_HIGH_SCORE(int score)
    {
        if (score <= SCORE) return;
        SCORE = score;
    }

    [Tooltip("Reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
        }
    }
}
