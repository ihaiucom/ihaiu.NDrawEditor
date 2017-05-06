using System;
namespace ihaiu.NDraws
{
    public sealed class NoteAttribute : Attribute
    {
        private readonly string text;
        public string Text
        {
            get
            {
                return this.text;
            }
        }
        public NoteAttribute(string text)
        {
            this.text = text;
        }
    }
}
