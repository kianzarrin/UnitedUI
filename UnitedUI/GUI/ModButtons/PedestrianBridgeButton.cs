namespace UnitedUI.GUI.ModButtons {
    public class PedestrianBridgeButton : GenericButton {
        public static PedestrianBridgeButton Instance;
        public PedestrianBridgeButton() : base() => Instance = this;
        public override string SpritesFileName => "B.png";
        public override string Tooltip => "Automatic Pedestrian bridge builder";
        public override ToolBase Tool => GetTool("PedBridgeTool");
        
    }
}
