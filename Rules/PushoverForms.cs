using System.Web.Mvc;
using Orchard.DisplayManagement;
using Orchard.Forms.Services;
using Orchard.Localization;
using Pushover;

namespace Kobowi.Pushover.Rules {
    public class PushoverForms : IFormProvider {

        private readonly dynamic _shape;

        public Localizer T { get; set; }

        public PushoverForms(IShapeFactory shapeFactory) {
            _shape = shapeFactory;
            T = NullLocalizer.Instance;
        }

        #region IFormProvider Members

        public void Describe(DescribeContext context) {
            var form = _shape.Form(
                Id: "PushoverMessageSettings",
                _User: _shape.TextBox(
                    Id: "PushoverUser", Name: "PushoverUser",
                    Size: 255, Rows: 1,
                    Title: T("Pushover user key"),
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

            form._Priority.Add(new SelectListItem {Value = MessagePriority.Normal.ToString(), Text = "Normal"});
            form._Priority.Add(new SelectListItem { Value = MessagePriority.High.ToString(), Text = "High" });

            context.Form("PushoverMessageSettings",
                         shape => form);

        }

        #endregion
    }
}