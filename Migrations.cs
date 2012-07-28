using Kobowi.Pushover.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Kobowi.Pushover {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable(typeof (PushoverSettingsPartRecord).Name,
                                      table => table.ContentPartRecord()
                                                   .Column<string>("ApiKey"));
            ContentDefinitionManager.AlterPartDefinition(typeof (PushoverSettingsPart).Name, part => part.Attachable());
            return 1;
        }
    }
}