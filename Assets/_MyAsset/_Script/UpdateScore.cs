using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security;
using System.Collections;

public class UpdateScore : MonoBehaviour {

    private string SecretKey = "123456";
	private string RegisterPHP_Url = "https://immersivemedia.ph/potatocornerDB/V4pc_Register.php";


    protected string UUID = "";
    protected string Firstname = "";
    protected string Lastname = "";
    protected string Email = "";
    protected int HighScore = 0;
	protected int Duration = 0;
	protected string BDay = "BDay";

    private bool isRegister = false;
	public static bool ConnectionSuccessful = false;
	public static bool UpdateRegistration = false;

	// Use this for initialization
	void Start () {
		if (ConnectionSuccessful == false) {
			isRegister = false;
			UUID = SystemInfo.deviceUniqueIdentifier;
			Firstname = PlayerPrefs.GetString("Firstname");
			Lastname = PlayerPrefs.GetString("Lastname");
			Email = PlayerPrefs.GetString("Email");

			HighScore = ZPlayerPrefs.GetInt("ScoreCount");
			Duration = PlayerPrefs.GetInt("TimeCount");

			BDay = MainMenu.BDay_Input_YearInt+"-"+MainMenu.BDay_Input_MonthInt+"-"+MainMenu.BDay_Input_DayInt;
			int TotalScore = ZPlayerPrefs.GetInt("ScoreCount");
			int TotalPoints = TotalScore / 5;
			//setting points to limits 179
			if (TotalPoints >= 99) {
				StartCoroutine (RegisterProcess ());
			} else if(MainMenu.isFirstTime == true){
				StartCoroutine (RegisterProcess ());
			}
		}
	}

	void Update(){
		if(UpdateRegistration == true){
			UpdateRegistration = false;
			StartCoroutine (RegisterProcess ());
		}
	}
        
    IEnumerator RegisterProcess()
    {
        if (isRegister)
            yield return null;

        isRegister = true;
       
        //Used for security check for authorization to modify database
        string hash = Md5Sum(UUID + Firstname + SecretKey).ToLower();

        //Assigns the data we want to save
        //Where -> Form.AddField("name" = matching name of value in SQL database
        WWWForm mForm = new WWWForm();
        mForm.AddField("UUID", UUID); // adds the player name to the form
        mForm.AddField("Firstname", Firstname); // adds the player password to the form
        mForm.AddField("Lastname", Lastname); // adds the kill total to the form
        mForm.AddField("Email", Email); // adds the death Total to the form
        mForm.AddField("HighScore", HighScore); // adds the score Total to the form
		mForm.AddField("Duration", Duration); // adds the score Total to the form
		mForm.AddField("BDay", BDay); // adds the score Total to the form

		string FBUserID = PlayerPrefs.GetString ("FB_UserID_2");
		string FBName = PlayerPrefs.GetString ("FB_Name_2");
		string FBEmailAddress = PlayerPrefs.GetString ("FB_Email_Address_2");

		mForm.AddField("FBUserID", FBUserID); // adds the score Total to the form
		mForm.AddField("FBName", FBName); // adds the score Total to the form
		mForm.AddField("FBEmailAddress", FBEmailAddress); // adds the score Total to the form

        mForm.AddField("hash", hash); // adds the security hash for Authorization

        //Creates instance of WWW to runs the PHP script to save data to mySQL database
        WWW www = new WWW(RegisterPHP_Url, mForm);
		if (TestingScript.isTesting == true) {
			Debug.Log ("Processing...");
		}
        yield return www;

		if (TestingScript.isTesting == true) {
			Debug.Log ("" + www.text);
		}
        if (www.text == "Done")
        {
			if (TestingScript.isTesting == true) {
				Debug.Log ("Registered Successfully Save Data.");
			}
			ConnectionSuccessful = true;
        }
        else
        {
			if (TestingScript.isTesting == true) {
				Debug.Log (www.text);
			}
			ConnectionSuccessful = false;

        }
        isRegister = false;
    }
    
    /// <summary>
    /// Md5s Security Features
    /// </summary>
    public string Md5Sum(string input)
    {
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++) { sb.Append(hash[i].ToString("X2")); }
        return sb.ToString();
    }
}
