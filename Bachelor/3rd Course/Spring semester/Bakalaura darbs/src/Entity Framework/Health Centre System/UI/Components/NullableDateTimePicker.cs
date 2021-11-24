using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace HealthSystem.UI.Components {
    public partial class NullableDateTimePicker : DateTimePicker {

        private bool isNull;
        private string nullValue;
        private string customFormat;
        private string formatAsString;
        private DateTimePickerFormat format = DateTimePickerFormat.Long;

        public NullableDateTimePicker() : base() {
            base.Format = DateTimePickerFormat.Custom;
            NullValue = " ";
            Format = DateTimePickerFormat.Long;
        }

        public new Object Value {
            get {
                if (isNull)
                    return null;
                else
                    return base.Value;
            }
            set {
                if (value == null || value == DBNull.Value) {
                    SetToNullValue();
                } else {
                    SetToDateTimeValue();
                    base.Value = (DateTime)value;
                }
            }
        }

        public new DateTimePickerFormat Format {
            get { return format; }
            set {
                format = value;
                SetFormat();
                OnFormatChanged(EventArgs.Empty);
            }
        }

        public new String CustomFormat {
            get { return customFormat; }
            set { customFormat = value; }
        }

        public String NullValue {
            get { return nullValue; }
            set { nullValue = value; }
        }

        private string FormatAsString {
            get { return formatAsString; }
            set {
                formatAsString = value;
                base.CustomFormat = value;
            }
        }

        private void SetFormat() {
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            DateTimeFormatInfo dtf = ci.DateTimeFormat;
            switch (format) {
                case DateTimePickerFormat.Long:
                    FormatAsString = dtf.LongDatePattern;
                    break;
                case DateTimePickerFormat.Short:
                    FormatAsString = dtf.ShortDatePattern;
                    break;
                case DateTimePickerFormat.Time:
                    FormatAsString = dtf.ShortTimePattern;
                    break;
                case DateTimePickerFormat.Custom:
                    FormatAsString = this.CustomFormat;
                    break;
            }
        }

        private void SetToNullValue() {
            isNull = true;
            base.CustomFormat = (nullValue == null || nullValue == String.Empty) ? " " : "'" + nullValue + "'";
        }

        private void SetToDateTimeValue() {
            if (isNull) {
                SetFormat();
                isNull = false;
                base.OnValueChanged(new EventArgs());
            }
        }

        protected override void OnCloseUp(EventArgs e) {
            if (Control.MouseButtons == MouseButtons.None) {
                if (isNull) {
                    SetToDateTimeValue();
                    isNull = false;
                }
            }
            base.OnCloseUp(e);
        }

        protected override void OnKeyUp(KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                this.Value = null;
                OnValueChanged(EventArgs.Empty);
            }
            base.OnKeyUp(e);
        }
    }
}
