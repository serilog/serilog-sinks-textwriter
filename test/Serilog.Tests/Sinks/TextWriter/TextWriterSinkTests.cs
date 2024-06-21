﻿using System;
using System.Globalization;
using System.IO;
using Serilog.Formatting.Display;
using Xunit;
using Serilog.Tests.Support;

namespace Serilog.Tests.Sinks.TextWriter
{
    public class TextWriterSinkTests
    {
        [Fact]
        public void EventsAreWrittenToTheTextWriter()
        {
            var sw = new StringWriter();

            var log = new LoggerConfiguration()
                .WriteTo.TextWriter(sw)
                .CreateLogger();

            var mt = Some.String();
            log.Information(mt);

            var s = sw.ToString();
            Assert.Contains(mt, s);
        }

        [Fact]
        public void EventsAreWrittenToTheTextWriterUsingFormatProvider()
        {
            var sw = new StringWriter();

            var french = new CultureInfo("fr-FR");
            var log = new LoggerConfiguration()
                .WriteTo.TextWriter(sw, formatProvider: french)
                .CreateLogger();

            var mt = String.Format(french, "{0}", 12.345);
            log.Information("{0}", 12.345);

            var s = sw.ToString();
            Assert.Contains(mt, s);
        }

        [Fact]
        public void CustomFormatter_EventsAreWrittenToTheTextWriter()
        {
            var sw = new StringWriter();

            var formatter = new MessageTemplateTextFormatter("{Message}", null);
            var log = new LoggerConfiguration()
                .WriteTo.TextWriter(formatter, sw)
                .CreateLogger();

            var mt = Some.String();
            log.Information(mt);

            var s = sw.ToString();
            Assert.Contains(mt, s);
        }

        [Fact]
        public void CustomFormatter_EventsAreWrittenToTheTextWriterUsingFormatProvider()
        {
            var sw = new StringWriter();

            var french = new CultureInfo("fr-FR");
            var formatter = new MessageTemplateTextFormatter("{Message}", french);
            var log = new LoggerConfiguration()
                .WriteTo.TextWriter(formatter, sw)
                .CreateLogger();

            var mt = String.Format(french, "{0}", 12.345);
            log.Information("{0}", 12.345);

            var s = sw.ToString();
            Assert.Contains(mt, s);
        }
    }
}
