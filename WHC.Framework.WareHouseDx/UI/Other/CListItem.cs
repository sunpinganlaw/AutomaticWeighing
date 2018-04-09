using System;
using System.Collections.Generic;
using System.Text;

namespace WHC.WareHouseMis.UI
{
    public class CListItem
    {
        public CListItem(string text, string value)
        {
            this.text = text;
            this.value = value;
        }

        public CListItem(string text)
        {
            this.text = text;
            this.value = text;
        }

        private string text;
        private string value;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return Text.ToString();
        }

    }
}
