using Kobowi.Pushover.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Kobowi.Pushover.Drivers {
    public class PushoverSettingsPartDriver : ContentPartDriver<PushoverSettingsPart> {

        protected override string Prefix {
            get {
                if (!string.IsNullOrEmpty(base.Prefix))
                    return base.Prefix + ".PushoverSettings";
                return "PushoverSettings";
            }
        }

        protected override DriverResult Editor(PushoverSettingsPart part, dynamic shapeHelper) {
            return ContentShape("Parts_PushoverSettingsPart_Edit",
                                () => shapeHelper.EditorTemplate(
                                    TemplateName: "Parts/PushoverSettingsPart",
                                    Prefix: Prefix,
                                    Model: part
                                          ));
        }

        protected override DriverResult Editor(PushoverSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}