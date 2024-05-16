#region Previas
using UnityEngine; 
using System.Collections; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
#endregion
public class pause_manager_ui : MonoBehaviour {
    public Canvas canvasPausa;
	#region Unity
	void Start(){
	canvasPausa.enabled = false;
	Time.timeScale = 1;
	}
	void Update(){
		if (Input.GetButtonDown ("Cancel")){
			Pause();}
			}

	#endregion
	#region Pause		
    public void Pause(){
        canvasPausa.enabled = !canvasPausa.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1: 0;
		}
	#endregion
	#region quality	
	public void antiAliasing_Quality (int Level){
	QualitySettings.antiAliasing = Level;
	}
	public void scene(string name){ 
	SceneManager.LoadScene (name);
	}
	public void Vsync(int Vsync){
	QualitySettings.vSyncCount = Vsync;
	}	
	public void Quit(){
     #if UNITY_EDITOR 
    EditorApplication.isPlaying = false;
    #else
    Application.Quit();
	#endif
	}
	#endregion
}