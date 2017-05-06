using System;
namespace ihaiu.NDraws
{

    public sealed class TitleAttribute : Attribute
    {
        private readonly string text;
        public string Text
        {
            get
            {
                return this.text;
            }
        }
        public TitleAttribute(string text)
        {
            this.text = text;
        }
    }
}
