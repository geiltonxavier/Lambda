﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Lambda.Core.DTO;

namespace Lambda.Web.Infraetrutura.Utils
{
    public class Serializador
    {
        public static string SerializarAutenticacaoModel(AutenticacaoModel autenticacaoModel)
        {
            var serializer = new XmlSerializer(typeof(AutenticacaoModel));
            var sw = new StringWriter();
            var xw = XmlWriter.Create(sw);
            serializer.Serialize(xw, autenticacaoModel);
            var autenticacaoModelSerializado = sw.ToString();
            return autenticacaoModelSerializado;
        }

        public static AutenticacaoModel DeserializarAutenticacaoModel(string autenticacaoModelSerializado)
        {
            var serializer = new XmlSerializer(typeof(AutenticacaoModel));
            var autenticacaoModel =
                (AutenticacaoModel)serializer.Deserialize(new StringReader(autenticacaoModelSerializado));
            return autenticacaoModel;
        }

    }
}