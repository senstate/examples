using Godot;
using Senstate.CSharp_Client;
using Senstate.NetStandard;
using System;

public class Button : Godot.Button
{
	private int counter = 0;
	private bool toggeled = false;
	private Watcher stringWatcher;
	private Watcher countWatcher;
	
	
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		   var webSocket = new NetStandardWebSocketImplementation();
   webSocket.ExceptionThrown += (sender, e) =>  // Optional if you want to catch Connection issues
   {
	  throw e.Exception;
   };

   SenstateContext.SerializerInstance = new NetStandardJsonNetImplementation();
   SenstateContext.WebSocketInstance = webSocket;
   SenstateContext.RegisterApp("Godot");

   stringWatcher = new Watcher(
	  new WatcherMeta
	  {
		 Tag = "Text label",
		 Type = WatcherType.String, // or Number / Json
	  }
   );

countWatcher = new Watcher(
	  new WatcherMeta
	  {
		 Tag = "Click Counter",
		 Type = WatcherType.Number, // or Number / Json
	  }
   );
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

private void _on_Button_pressed()
{
	toggeled = !toggeled;
	
updateLabel();

	// Replace with function body.
}

private void updateLabel() {
	var parent = GetParent();
	
		 var label = parent.GetNode<Label>("Label");
		label.Text = toggeled ? "Toggled" : "Not"; 
		
		stringWatcher.SendData(label.Text);
		
		var counterLabel = parent.GetNode<Label>("Counter");
		
		counterLabel.Text = $"{counter++}";
		
		countWatcher.SendData(counter);
}

}
