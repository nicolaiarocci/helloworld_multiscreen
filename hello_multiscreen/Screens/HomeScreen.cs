
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace hello_multiscreen
{
	public partial class HomeScreen : UIViewController
	{
		HelloWorldScreen helloWorldScreen;
		HelloUniverseScreen helloUniverseScreen;

		public HomeScreen () : base ("HomeScreen", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			//--- when the hello world button is clicket
			this.btnHelloWorld.TouchUpInside += (sender, e) => {
				//--- instantiate a new helloWorldScreen if it's null
				// (it might not be null if they've navigated backwards
				if(this.helloWorldScreen == null) { 
					this.helloWorldScreen = new HelloWorldScreen(); 
				}
				//--- push our helloWorldScreen to the navigation
				// controller and pass a true so it navigates
				this.NavigationController.PushViewController(this.helloWorldScreen, true);
			};

			//--- same thing, but the hello universe screen
			this.btnHelloUniverse.TouchUpInside += (sender, e) => {
				if(this.helloUniverseScreen == null) { 
					this.helloUniverseScreen = new HelloUniverseScreen(); 
				}
				this.NavigationController.PushViewController (this.helloUniverseScreen, true);
			};
		}

		public override void ViewWillAppear(bool animated) 
		{
			base.ViewWillAppear (animated);
			this.NavigationController.SetNavigationBarHidden (true, animated); 
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear (animated);
			this.NavigationController.SetNavigationBarHidden (false, animated);
		}

	}
}