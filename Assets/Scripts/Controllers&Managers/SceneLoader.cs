using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    #region SINGLETON
    public static SceneLoader instance = null;

    private void MakeSingleton ( )
    {
        if ( instance == null )
        {
            instance = this;
        }
        else if ( instance != this )
        {
            Destroy ( gameObject );
        }
    }
    #endregion

    public Image loadingFiller;

    [SerializeField]
    private string sceneName;

    [SerializeField]
    private int sceneIndex;

    [SerializeField]
    private bool loadingScene = false;

    public TextMeshProUGUI loadingTextMesh;

    private void Awake ( )
    {
        MakeSingleton ( );
    }

    private void OnEnable ( )
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDisable ( )
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    public void SceneLoaded ( Scene s, LoadSceneMode lsm )
    {
        if ( s.buildIndex != 0 )
        {
            UIController.instance.ActivateUIElement ( UIElements.MenuButton );
            UIController.instance.ActivateUIElement ( UIElements.Loading );
        }
    }

    public void SetSceneToLoad ( SceneNames sceneName )
    {
        sceneIndex = ( int ) sceneName;
        this.sceneName = sceneName.ToString ( );

        if ( !loadingScene )
        {
            UIController.instance.ActivateUIElement ( UIElements.Loading );

            loadingScene = true;

            loadingTextMesh.text = "Loading " + this.sceneName;

            StartCoroutine ( LoadNewScene ( ) );

        }

    }

    IEnumerator LoadNewScene ( )
    {

        yield return new WaitForSeconds ( 3 );

        AsyncOperation async = SceneManager.LoadSceneAsync ( sceneIndex );

        while ( !async.isDone )
        {

            Debug.Log ( async.progress );
            loadingFiller.fillAmount = async.progress;
            yield return null;
        }

    }

}
