using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    [SerializeField] private Image tutorialInGameImage;



    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;


    public bool isDumpsterOpen = false;



    private IInteractable _interactable;



    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    


    private void Start()
    {
        ScoreManager.Instance.ResetScore();
        Timer.Instance.ResetTimer();

        AudioManager.Instance.PlayMusic("In Game");

        Invoke(nameof(ShowTutorialInGame), 1f);
    }



    private void Update()
    {
        // kan gue nyari tiap frame ada ga Trigger yang overlap sama layer Interactable
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius,
                    _colliders, _interactableMask);


        // yo kalo ada
        if (_numFound > 0)
        {
            // gue ambil IInteractablenya, supaya bisa pake fungsi yang ada di IInteractable, yaitu InteractionPrompt, sama Interact
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null) // kalo ada komponent IInteractable di gameobject yang overlap
            {
                // gue pasttin dulu, promptnya udah muncul apa belom, kalo belom ya munculin
                // tapih, kalo Dumpsternya juga belum kebuka, karna kalo kebuka gabole dimunculin
                if (!_interactionPromptUI.IsDisplayed && isDumpsterOpen == false)
                {
                    // nah jadi ini gue munculin
                    // karna dumpster belum kebuka, sama promptnya juga belom ada
                    _interactionPromptUI.SetUp(_interactable.InteractionPrompt);
                }

                // ini buat ngurus interactnya pake F
                if (Input.GetKeyDown(KeyCode.F)) _interactable.Interact(this);
            }
        }
        // kalo gada
        else
        {
            // kalau masih ada IInteractable yg kesimpan, biar ga bug, kita null in dulu
            if (_interactable != null) _interactable = null;

            // trus kalo promptnya aktif, yo matiin, biar ga riweh
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.CloseDisplayed();
        }
    }



    public void ShowTutorialInGame()
    {
        StartCoroutine(ShowImage(tutorialInGameImage, 3f));
    }



    public IEnumerator ShowImage(Image _image, float time)
    {
        _image.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(time);
        _image.gameObject.SetActive(false);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
