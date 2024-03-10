using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageDecode.Processor.Converters
{
    internal class CurrentTimeConverter : IMessageConverter
    {
        public void Convert(Section section)
        {
            //2BC9A606 as whole? or split
            var blah = new char[] { '06', 'A6', 'C9', '2B' };
            blah.Reverse
            var val = int.Parse(new string(blah), System.Globalization.NumberStyles.HexNumber);
            // foreach(var b in )
            // {
            //     var val = int.Parse(hexVal, System.Globalization.NumberStyles.HexNumber);

            //     //TODO convert this to int then string then back to int and take away from 2000!!!! 734635526 should be the thing
            // }
        }
    }
}
