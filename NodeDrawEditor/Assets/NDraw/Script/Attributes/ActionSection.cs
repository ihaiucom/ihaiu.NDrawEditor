using System;
namespace ihaiu.NDraws
{
    public sealed class ActionSection : Attribute
    {
        private readonly string section;
        public string Section
        {
            get
            {
                return this.section;
            }
        }
        public ActionSection(string section)
        {
            this.section = section;
        }
    }
}
