using System;
using System.ServiceModel.Channels;
using System.Xml;
using SoapCore.Extensibility;

namespace SoapCore
{
	public class SoapOptions
	{
		public Type ServiceType { get; set; }
		public string Path { get; set; }
		public SoapEncoderOptions[] EncoderOptions { get; set; }
		public SoapSerializer SoapSerializer { get; set; }
		public bool CaseInsensitivePath { get; set; }
		public ISoapModelBounder SoapModelBounder { get; set; }
		public Binding Binding { get; set; }

		[Obsolete]
		public int BufferThreshold { get; set; } = 1024 * 30;
		[Obsolete]
		public long BufferLimit { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether publication of service metadata on HTTP GET request is activated
		/// <para>Defaults to true</para>
		/// </summary>
		public bool HttpGetEnabled { get; set; } = true;

		/// <summary>
		/// Gets or sets a value indicating whether publication of service metadata on HTTPS GET request is activated
		/// <para>Defaults to true</para>
		/// </summary>
		public bool HttpsGetEnabled { get; set; } = true;

		public bool OmitXmlDeclaration { get; set; } = true;

		public bool IndentXml { get; set; } = true;

		public XmlNamespaceManager XmlNamespacePrefixOverrides { get; set; }
		public WsdlFileOptions WsdlFileOptions { get; set; }

		public static SoapOptions FromSoapCoreOptions<T>(SoapCoreOptions opt)
		{
			return FromSoapCoreOptions(opt, typeof(T));
		}

		public static SoapOptions FromSoapCoreOptions(SoapCoreOptions opt, Type serviceType)
		{
			var soapOptions = new SoapOptions
			{
				ServiceType = serviceType,
				Path = opt.Path,
				EncoderOptions = opt.EncoderOptions,
				SoapSerializer = opt.SoapSerializer,
				CaseInsensitivePath = opt.CaseInsensitivePath,
				SoapModelBounder = opt.SoapModelBounder,
				Binding = opt.Binding,
#pragma warning disable CS0612 // Type or member is obsolete
				BufferThreshold = opt.BufferThreshold,
				BufferLimit = opt.BufferLimit,
#pragma warning restore CS0612 // Type or member is obsolete
				HttpsGetEnabled = opt.HttpsGetEnabled,
				HttpGetEnabled = opt.HttpGetEnabled,
				OmitXmlDeclaration = opt.OmitXmlDeclaration,
				IndentXml = opt.IndentXml,
				XmlNamespacePrefixOverrides = opt.XmlNamespacePrefixOverrides
			};

			return soapOptions;
		}
	}
}
