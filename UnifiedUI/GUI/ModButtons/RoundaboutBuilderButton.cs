using ColossalFramework.UI;
using KianCommons;
using System;
using System.Linq;
using System.Collections.Generic;

namespace UnifiedUI.GUI.ModButtons {
    public class RoundaboutBuilderButton : GenericModButton {
        public static RoundaboutBuilderButton Instance;
        public RoundaboutBuilderButton() : base() => Instance = this;
        public override string SpritesFileName => "uui_roundabout_builder.png";
        public override string Tooltip => "Roundabout builder";

        UIPanel UIWindow =>
            KianCommons.UI.UIUtils.GetCompenentsWithName<UIPanel>("RAB_ToolOptionsPanel")
            ?.FirstOrDefault()
            ?? throw new Exception("Could not found RAB_ToolOptionsPanel");

        public override IEnumerable<UIComponent> GetOriginalButtons() =>
            UIView.GetAView()
            .GetComponentsInParent<UIButton>(includeInactive: true)
            .Where(c => c.name == "RoundaboutButton")
            .Select(c => c as UIComponent);

        protected override void OnClick(UIMouseEventParameter p) {
            // Commented out to ignore base behaviour
            // base.OnClick(p);
            var type = UIWindow.GetType();
            var methodInfo = type.GetMethod("Toggle");
            methodInfo.Invoke(UIWindow, null);
            OnRefresh(ToolsModifierControl.toolController.CurrentTool);
        }

        public override void OnRefresh(ToolBase newTool) {
            HandleOriginalButton();
            Log.Debug("RoundaboutBuilderButton.OnToolChanged(): newTool.namespace = " + newTool?.GetType()?.Namespace ?? "null");
            IsActive = newTool?.GetType()?.Namespace?.StartsWith("RoundaboutBuilder") ?? false;
        }
    }
}