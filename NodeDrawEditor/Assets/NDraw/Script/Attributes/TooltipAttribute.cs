using System;
namespace ihaiu.NDraws
{
    public sealed class TooltipAttribute : Attribute
    {
        private readonly string text;
        public string Text
        {
            get
            {
                return this.text;
            }
        }
        public TooltipAttribute(string text)
        {
            this.text = text;
        }
    }
}
