using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml;

namespace WebFox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XxeTest1 : ControllerBase
    {

        [HttpGet("{xmlString}")]
        public void DoXxe(String xmlString)
        {
            XmlDocument xmlDoc = new XmlDocument();
            
            // create secure settings
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Ignore;
            
            // wrap XML string in a secure reader
            using (var stringReader = new System.IO.StringReader(xmlString))
            using (var secureReader = XmlReader.Create(stringReader, settings))
            {
                xmlDoc.Load(secureReader);
            }
        }
    }
}