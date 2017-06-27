using System;
using System.Diagnostics;
using BMapBinding;
using UIKit;
using CoreGraphics;

namespace test.iOS
{
    class GeneralDelegate : BMKGeneralDelegate
    {
    	public override void OnGetNetworkState(int iError)
    	{
    		Debug.WriteLine("OnGetNetworkState: " + iError);
    	}

    	public override void OnGetPermissionState(int iError)
    	{
    		Debug.WriteLine("OnGetPermissionState: " + iError);
        }
    }

    class GeoCodeSearchDelegate : BMKGeoCodeSearchDelegate
    {
        public override void OnGetGeoCodeResult(BMKGeoCodeSearch searcher, BMKGeoCodeResult result, BMKSearchErrorCode error)
        {
            Debug.WriteLine(result.Location);
        }
    }

    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            BMKMapManager mgr = new BMKMapManager();
            mgr.Start("B3iCnaZ9pv6UDbenWBEHdfY36dsVLUnM", new GeneralDelegate());

            UIButton btn = new UIButton {Frame = new CGRect(0, 0, 100, 100)};
            btn.BackgroundColor = UIColor.Red;
            btn.SetTitle("search", UIControlState.Normal);
            View.AddSubview(btn);
            btn.AddTarget((sender, e) => {
                BMKGeoCodeSearch search = new BMKGeoCodeSearch();
                //search.Init();
                search.Delegate = new GeoCodeSearchDelegate();
                search.GeoCode(new BMKGeoCodeSearchOption { City = "北京市", Address = "海淀区上地10街10号" });
            }, UIControlEvent.TouchUpInside);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}