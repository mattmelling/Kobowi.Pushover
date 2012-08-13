using System.Web.Mvc;
using Kobowi.Pushover.Services;
using Orchard.DisplayManagement;
using Orchard.Forms.Services;
using Orchard.Localization;
using Pushover;

namespace Kobowi.Pushover.Rules {
    public class PushoverForms : IFormProvider {

        private readonly dynamic _shape;
        private readonly IPushoverService _pushover;

        public Localizer T { get; set; }

        public PushoverForms(IShapeFactory shapeFactory, IPushoverService pushover) {
            _shape = shapeFactory;
            _pushover = pushover;
            T = NullLocalizer.Instance;
        }

        #region IFormProvider Members

        public void Describe(DescribeContext context) {
            var form = _shape.Form(
                Id: "PushoverMessageSettings",
                _UserSelect: _shape.SelectList(
                    Id: "UserSelect", Name: "UserSelect",
                    Title: T("Select a User...")
                ),
                _User: _shape.TextBox(
                    Id: "PushoverUser", Name: "PushoverUser",
                    Size: 255, Rows: 1,
                    Title: T("... or enter a Pushover user key"),
                    Classes: new[] {"tokenized"}),
                _Title: _shape.TextBox(
                    Id: "MessageTitle", Name: "MessageTitle",
                    Title: T("Message Title"),
                    Classes: new[] {"tokenized"}),
                _Message: _shape.TextArea(
                    Id: "MessageBody", Name: "MessageBody",
                    Title: T("Message Body"),
                    Classes: new[] {"tokenized"}
                    ),
                _Url: _shape.TextBox(
                    Id: "MessageUrl", Name: "MessageUrl",
                    Title: T("Message URL"),
                    Classes: new[] {"tokenized"}
                    ),
                _UrlTitle: _shape.TextBox(
                    Id: "MessageUrlTitle", Name: "MessageUrlTitle",
                    Title: T("Message URL Title"),
                    Classes: new[] {"tokenized"}
                    ),
                _Priority: _shape.SelectList(
                    Id: "Priority", Name: "Priority",
                    Title: T("Message Priority")
                    ),
                    _Timestamp: _shape.TextBox(
                    Id: "Timestamp", Name: "Timestamp",
                    Title: T("Timestamp"),
                    Description: T("Leave blank for the current date and time"),
                    Classes: new[] {"tokenized"})
                );

            form._Priority.Add(new SelectListItem {Value = MessagePriority.Normal.ToString(), Text = T("Normal").Text});
            form._Priority.Add(new SelectListItem {Value = MessagePriority.High.ToString(), Text = T("High").Text});

            form._UserSelect.Add(new SelectListItem {Value = "", Text = T("None").Text});
            foreach (var user in _pushover.GetPushoverUsers())
                form._UserSelect.Add(new SelectListItem {Value = user.UserKey, Text = user.DisplayText});

            context.Form("PushoverMessageSettings",
                         shape => form);
        }

        #endregion
    }
}