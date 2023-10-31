using Godot;


//Stores references to XR Camera Rig nodes for ease of access when referencing.
//Instead of referencing every single node here - and thus treating the scene 
//as several separate components - you simply reference the CameraRig and
//request the nodes you want
public partial class CameraRig : XROrigin3D
{
    public XRCamera3D Camera { get; private set; }

    public XRController3D LeftController { get; private set; }
    public Node3D LeftWrist { get; private set; }

    public XRController3D RightController { get; private set; }
    public Node3D RightWrist { get; private set; }


    public override void _Ready()
    {
        //get references to all camera rig nodes
        Camera = GetNode<XRCamera3D>("Camera");

        LeftController = GetNode<XRController3D>("LeftHand");
        LeftWrist = LeftController.GetNode<Node3D>("LeftWrist");

        RightController = GetNode<XRController3D>("RightHand");
        RightWrist = RightController.GetNode<Node3D>("RightWrist");
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
