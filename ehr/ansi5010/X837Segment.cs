using System;

namespace EMR.WebAPI.ehr.ansi5010
{
    public class X837Segment
    {
        public X837Segment(string position, string segment, string name, bool mandatory, string max, string loop, bool loopMandatory, string loopRepeat, X837Element[] elements, X837Segment[] loopSegments)
        {
            this.Position = position;
            this.Segment = segment;
            this.Name = name;
            this.Mandatory = mandatory;
            this.Nomax = max.Contains(">");
            this.Max = this.Nomax ? Int32.Parse(max.Replace(">", null)) : Int32.Parse(max);
            this.Loop = loop;
            this.LoopMandatory = loopMandatory;
            this.LoopRepeat = loopRepeat;
            this.Elements = elements;
            this.LoopSegments = loopSegments;
        }

        public string Position { get; set; }
        public string Segment { get; set; }
        public string Name { get; set; }
        public bool Mandatory { get; set; }
        public int Max { get; set; }
        public bool Nomax { get; set; }
        public string Loop { get; set; }
        public bool LoopMandatory { get; set; }
        public string LoopRepeat { get; set; }
        public X837Element[] Elements { get; set; }
        public X837Segment[] LoopSegments { get; set; }

        public string findElement(string segmentname, string elementname, string elementvalue)
        {
            if (Segment.Equals(segmentname))
            {
                foreach (X837Element elem in Elements)
                {
                    if (elem.Position.Equals(elementname))
                    {
                        return elem.formatValue(elementvalue);
                    }
                }
                return null;
            }
            else
            {
                foreach(X837Segment loopseg in LoopSegments)
                {
                    string findEl = loopseg.findElement(segmentname, elementname, elementvalue);
                    if(findEl != null)
                    {
                        return findEl;
                    }
                }
                return null;
            }
        }

    }
}