using Godot;


//Stores references to XR Camera Rig nodes for ease of access when referencing.
//Instead of referencing every single node here - and thus treating the scene 
//as several separate components - you simply reference the CameraRig and
//request the nodes you want
public partial class CameraRig : XROrigin3D
{
    public XRCamera3D Camera { get; private set; }

    public XRController3D LeftController { get; private set; }
    public XRController3D LeftAim { get; private set; }
    public Node3D LeftWrist { get; private set; }

    public XRController3D RightController { get; private set; }
    public XRController3D RightAim { get; private set; }
    public Node3D RightWrist { get; private set; }


    public override void _Ready()
    {
        //get references to all camera rig nodes
        Camera = GetNode<XRCamera3D>("Camera");

        LeftController = GetNode<XRController3D>("LeftHand");
        LeftAim = GetNode<XRController3D>("LeftAim");
        LeftWrist = LeftController.GetNode<Node3D>("LeftWrist");

        RightController = GetNode<XRController3D>("RightHand");
        LeftAim = GetNode<XRController3D>("RightAim");
        RightWrist = RightController.GetNode<Node3D>("RightWrist");


        //configure the rig to use XR
        StartRigOpenXR();
    }

    private void StartRigOpenXR()
    {
        XRInterface _xrInterface = XRServer.FindInterface("OpenXR");
        if (_xrInterface != null && _xrInterface.IsInitialized())
        {
            GD.Print("OpenXR initialized successfully");


            // Turn off v-sync!
            DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Disabled);
            // Change our viewport to output to the HMD
            GetViewport().UseXR = true;
        }
        else
        {
            GD.Print("OpenXR not initialized, please check if your headset is connected");
        }
    }

    #region Getters
    public XRCamera3D GetCamera()
    {
        return Camera;
    }

    public XRController3D GetLeftController()
    {
        return LeftController;
    }
    public XRController3D GetRightController()
    { 
        return RightController; 
    }

    public Node3D GetLeftWrist()
    {
        return LeftWrist;
    }
    public Node3D GetRightWrist()
    {
        return RightWrist;
    }
    #endregion Getters
}
