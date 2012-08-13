using Kobowi.Pushover.Models;
using Kobowi.Pushover.ViewModels;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Kobowi.Pushover.Drivers {
    public class PushoverUserPartDriver : ContentPartDriver<PushoverUserPart> {
        protected override DriverResult Editor(PushoverUserPart part, dynamic shapeHelper) {
            return ContentShape("Parts_PushoverUserPart_Edit",
                                () => shapeHelper.EditorTemplate(
                                    TemplateName: "Parts/PushoverUserPart",
                                    Prefix: Prefix,
                                    Model: new PushoverUserPartEditor {
                                        UserKey = part.UserKey
                                    }));
        }

        protected override DriverResult Editor(PushoverUserPart part, IUpdateModel updater, dynamic shapeHelper) {
            var model = new PushoverUserPartEditor();
            if(updater.TryUpdateModel(model, Prefix, null, null)) {
                part.UserKey = model.UserKey;
            }
            return Editor(part, shapeHelper);
        }
    }
}