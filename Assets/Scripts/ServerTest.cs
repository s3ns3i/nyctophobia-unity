using UnityEngine;
using System.Collections;
using System.Net;
using System.Collections.Specialized;
using System.Text;

public class ServerTest : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		using (var client = new WebClient())
		{
			var values = new NameValueCollection();
			values["test"] = "hello123";

			var response = client.UploadValues("http://ggulivrr.uni.lodz.pl", values);

			var responseString = Encoding.Default.GetString(response);

			Debug.Log(responseString);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
