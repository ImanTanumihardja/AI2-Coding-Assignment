# AI2 VR Internship Interview

**Objectives:** Create a Unity scene in VR where the player can move around, pick up trash, and put it into a
garbage bin.

**Stretch Goals:** 
	1. Implement a scoreboard that tracks how many pieces of trash have been successfully
	moved to the trash can.
	2. Support different types of pieces of trash, which may have different shapes, materials,
	colors, or physical properties.
	3. Add in appropriate sound effects for various actions that happen as you pick up and put
	away trash. 

**How to Run Project:**

	*Unity:*
		(Needs Oculus Link to be setup: https://youtu.be/sSD798Ov2oY)
		1.) Open project with Unity 2021.1.21.
		2.) Connect Oculus to your computer using USB cable.
		3.) Make sure you are in the Oculus Link in the Oculus.
		4.) Press the play button in the editor while wearing the Oculus.
		5.) Now you can play using the Oculus. 
		
	*Build:* 
		(Needs Oculus to be in developer mode (if using Oculus) and ADB to be installed: https://developer.oculus.com/documentation/native/android/mobile-device-setup/)
		1.) Open ADB in the terminal.
		2.) Connect Device to computer using USB cable.
		3.) Run the installation command: 
			adb install /path/to/AI2 Coding Assignment/Builds/JanitorSimulator.apk
		(For Oculus)
		4.) In the Oculus go to apps.
		5.) Click the dropdown in the top right corner.
		6.) Click Unknown Sources.
		7.) Click the app (should be called AI2).	

**How to Play:**
	*Left Hand:* 
		Trigger: activate teleport mode
		Grip: pick up objects
		Primary Button: cancel teleport mode

	*Right Hand:*
		Trigger: activate teleport mode
		Grip: pick up objects
		Primary Button: cancel teleport mode
		Thumbstick: snap turn

**Unity Version:** 2021.1.21

**Hardware:** Oculus Quest 2

**External Resources:** 
	XR Interaction Toolkit
	XR Plugin Management
	Oculus XR Plugin
	Snaps Prototype | Office
	Trash Low Poly Cartoon Pack

**Styling Decisions:**
	Most of the game logic is within the GameManager class. The GameManager controls what happens when the game starts and ends. The game starts when the player presses 
	the start button and doing so invokes the onStartGame event in the GameManager and this triggers the trash to spawn, the music to play, and the score text to appear.
	The game ends when the player has successfully put all the trash into the bin, and this invokes the onEndGame event in the GameManager which stops the music and opens 
	the doors to restart the game. Since the GameManager handles most of what needs to happen in the game there is very little coupling which makes it easy to make 
	changes later. The GameManagers also keeps track of the score (amount of trash collected). There is another class called Bin which has an onCollected event that 
	triggers when a piece of trash is put in the Bin. The GameManager subscribes to this event and increments the score and plays effects when the event is triggered. 

	The scene has three main components: the Environment, the XR Rig, and the Canvas. The Environment holds all the gameobjects that make up the office scene; this includes 
	the tables, monitors, walls, the bin, and the trash pool. The XR Rig comes from the XR Plugin Management which contains all necessary objects to enable virtual reality. The 
	Canvas displays the start button and score text.

	There are three main types of gameobjects; grabbable, interactable, and static. The grabbable gameobjects are the pieces of trash. These gameobjects have a ridgebody, collider, halo, and
	XR Grab Interactable (which allows them to be grabbed). The interactable gameobject are the items in the scene that cannot be grabbed but can be moved. These gameobjects have a ridgebody and collider. The 
	static gameobjects are the items in the scene that cannot be moved or grabbed they are purely for decorations. 

**Demo Video:** https://youtu.be/Lt1L6o-86Ok