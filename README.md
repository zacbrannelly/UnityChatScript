# Unity ChatScript Plugin
Native plugin for Unity to use ChatScript. 
The native `chatscript.dll` has been compiled from [this](https://github.com/zacbrannelly/ChatScript) fork of `ChatScript`

## Requirements
- Only built to work on Windows 64bit
- Unity 2017+

## How to import
- Copy the `Plugins` & `StreamingAssets` folder into your assets folder
- Now check that you can use the `UnityChatScript` namespace in a script
- If that works you are good to go!

## How to use 
- Create an empty gameobject and add the `ChatScript` component. 
- Then create and add a new script called `TestComponent` and do the following: 
```csharp
using UnityChatScript;

public class TestComponent : MonoBehaviour
{
	public void Start() 
	{
		var chatScript = GetComponent<ChatScript>();
		
		Debug.Log(chatScript.Query("Hello there", "Guest", "Harry"));
	}
}
```
- This should show a response in the console. 
- To create new bots, have a separate ChatScript installation, build your bot in there and copy the `TOPICS` & `RAWDATA` folder across to `StreamingAssets/chatscript/`
