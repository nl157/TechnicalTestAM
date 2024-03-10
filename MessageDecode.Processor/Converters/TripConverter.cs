﻿using MessageDecode.Models;
using MessageDecode.Processor.Interfaces;

namespace MessageDecode.Processor.Converters
{
    internal class TripConverter : IMessageConverter
    {
        public void Convert(Section section)
        {
            section.Value = (bool?)HexConverter.ConvertToBool(section.GroupedBytes!.First());
        }
    }
}
