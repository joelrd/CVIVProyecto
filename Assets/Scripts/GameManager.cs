using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private int _score;

    private string _currentDoorId;

    private void Awake( ) {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this);
        }
    }

    void Start( ) {
        _score = 0;
    }

    public void ChangeScenes(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }

    public int GetScore( ) {
        return _score;
    }

    public void AddScore(int points) {
        _score += points;
    }

    public void ResetScore( ) {
        _score = 0;
    }

    public void SetDoor(string doorId) {
        _currentDoorId = doorId;
    }

    public string GetDoor( ) {
        return _currentDoorId;
    }
}
