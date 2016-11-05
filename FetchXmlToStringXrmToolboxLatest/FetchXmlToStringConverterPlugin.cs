﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using System.ComponentModel.Composition;

namespace FetchXmlToStringXrmToolboxLatest
{
    [Export(typeof(IXrmToolBoxPlugin)),
    ExportMetadata("SmallImageBase64", "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"),
    ExportMetadata("BigImageBase64", "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"),
    ExportMetadata("BackgroundColor", "Lavender"),
    ExportMetadata("PrimaryFontColor", "#000000"),
    ExportMetadata("SecondaryFontColor", "DarkGray"),
    ExportMetadata("Name", "FetchXML to C#/JS string converter"),
    ExportMetadata("Description", "XRMToolBox plugin to convert from FetchXML to C#/JS string")]
    public class FetchXmlToStringConverterPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new FetchXmlToStringUserControl();
        }
    }
}