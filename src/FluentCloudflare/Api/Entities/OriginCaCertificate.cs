using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Api.Entities
{
    public class OriginCaCertificate
    {
        /// <summary>
        /// The x509 serial number of the Origin CA certificate
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// PEM. The Origin CA certificate. Will be newline-encoded.
        /// </summary>
        public string Certificate { get; set; }
        
        /// <summary>
        /// Array of hostnames or wildcard names (e.g., *.example.com) bound to the certificate
        /// </summary>
        public List<string> Hostnames { get; set; }

        /// <summary>
        /// When the certificate will expire.
        /// While this should actually be a <see cref="DateTime"/>, it is implemented as string because the Cloudflare API does
        /// a) not behave as documented in it's own documentation and b) does return a format that is understood by common
        /// json parsers.
        /// See https://github.com/cloudflare/cloudflare-go/issues/190
        /// </summary>
        public string ExpiresOn { get; set; }
        
        /// <summary>
        /// Signature type desired on certificate ("origin-rsa" (rsa), "origin-ecc" (ecdsa), or "keyless-certificate" (for Keyless SSL servers)
        /// </summary>
        public OriginCaCertificateRequestType? RequestType { get; set; }

        /// <summary>
        /// The number of days for which the certificate should be valid. Default value: 5475; Valid values: 7, 30, 90, 365, 730, 1095, 5475
        /// </summary>
        public int? RequestedValidity { get; set; }

        /// <summary>
        /// PEM. The Certificate Signing Request (CSR). Must be newline-encoded.
        /// </summary>
        public string Csr { get; set; }
    }
}
