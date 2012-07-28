using Orchard.ContentManagement;

namespace Kobowi.Pushover.Models
{
    public class PushoverSettingsPart : ContentPart<PushoverSettingsPartRecord> {
        public string ApiKey {
            get { return Record.ApiKey; }
            set { Record.ApiKey = value; }
        }
    }
}