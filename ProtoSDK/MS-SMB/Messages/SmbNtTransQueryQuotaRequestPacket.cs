// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Cifs;

namespace Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Smb
{
    /// <summary>
    /// query quota. 
    /// </summary>
    public class SmbNtTransQueryQuotaRequestPacket : Cifs.SmbNtTransactRequestPacket
    {
        #region Fields

        private NT_TRANSACT_QUERY_QUOTA_Request_NT_Trans_Parameters ntTransParameters;

        #endregion

        #region Properties

        /// <summary>
        /// get or set the ntTransParameters:NT_TRANSACT_QUERY_QUOTA_Request_NT_Trans_Parameters 
        /// </summary>
        public NT_TRANSACT_QUERY_QUOTA_Request_NT_Trans_Parameters NtTransParameters
        {
            get
            {
                return this.ntTransParameters;
            }
            set
            {
                this.ntTransParameters = value;
            }
        }


        #endregion
        
        #region Constructor

        /// <summary>
        /// Constructor. 
        /// </summary>
        public SmbNtTransQueryQuotaRequestPacket()
            : base()
        {
        }


        /// <summary>
        /// Constructor: Create a request directly from a buffer. 
        /// </summary>
        public SmbNtTransQueryQuotaRequestPacket(byte[] data)
            : base(data)
        {
        }


        /// <summary>
        /// Deep copy constructor. 
        /// </summary>
        public SmbNtTransQueryQuotaRequestPacket(SmbNtTransQueryQuotaRequestPacket packet)
            : base(packet)
        {
        }


        #endregion

        #region override methods

        /// <summary>
        /// to create an instance of the StackPacket class that is identical to the current StackPacket. 
        /// </summary>
        /// <returns>a new Packet cloned from this. </returns>
        public override StackPacket Clone()
        {
            return new SmbNtTransQueryQuotaRequestPacket(this);
        }


        /// <summary>
        /// Encode the struct of NtTransParameters into the byte array in SmbData.NT_Trans_Parameters 
        /// </summary>
        protected override void EncodeNtTransParameters()
        {
            this.smbData.NT_Trans_Parameters =
                CifsMessageUtils.ToBytes<NT_TRANSACT_QUERY_QUOTA_Request_NT_Trans_Parameters>(
                this.ntTransParameters);
        }


        /// <summary>
        /// Encode the struct of NtTransData into the byte array in SmbData.NT_Trans_Data 
        /// </summary>
        protected override void EncodeNtTransData()
        {
        }


        /// <summary>
        /// to decode the NtTrans parameters: from the general NtTransParameters to the concrete NtTrans Parameters. 
        /// </summary>
        protected override void DecodeNtTransParameters()
        {
            this.ntTransParameters =
                CifsMessageUtils.ToStuct<NT_TRANSACT_QUERY_QUOTA_Request_NT_Trans_Parameters>(
                this.smbData.NT_Trans_Parameters);
        }


        /// <summary>
        /// to decode the NtTrans data: from the general NtTransDada to the concrete NtTrans Data. 
        /// </summary>
        protected override void DecodeNtTransData()
        {
        }


        #endregion
    }
}
