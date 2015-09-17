// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using Microsoft.Protocols.TestTools.StackSdk;
using Microsoft.Protocols.TestTools.StackSdk.Messages;

namespace Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Cifs
{
    /// <summary>
    /// Packets for SmbReadAndx Response
    /// </summary>
    public class SmbReadAndxResponsePacket : SmbBatchedResponsePacket
    {
        #region Fields

        private SMB_COM_READ_ANDX_Response_SMB_Parameters smbParameters;
        private SMB_COM_READ_ANDX_Response_SMB_Data smbData;

        #endregion


        #region Properties

        /// <summary>
        /// get or set the Smb_Parameters:SMB_COM_READ_ANDX_Response_SMB_Parameters
        /// </summary>
        public SMB_COM_READ_ANDX_Response_SMB_Parameters SmbParameters
        {
            get
            {
                return this.smbParameters;
            }
            set
            {
                this.smbParameters = value;
            }
        }


        /// <summary>
        /// get or set the Smb_Data:SMB_COM_READ_ANDX_Response_SMB_Data
        /// </summary>
        public SMB_COM_READ_ANDX_Response_SMB_Data SmbData
        {
            get
            {
                return this.smbData;
            }
            set
            {
                this.smbData = value;
            }
        }


        /// <summary>
        /// the SmbCommand of the andx packet.
        /// </summary>
        protected override SmbCommand AndxCommand
        {
            get
            {
                return this.SmbParameters.AndXCommand;
            }
        }


        /// <summary>
        /// Set the AndXOffset from batched request
        /// </summary>
        protected override ushort AndXOffset
        {
            get
            {
                return this.smbParameters.AndXOffset;
            }
            set
            {
                this.smbParameters.AndXOffset = value;
            }
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public SmbReadAndxResponsePacket()
            : base()
        {
            this.InitDefaultValue();
        }


        /// <summary>
        /// Constructor: Create a request directly from a buffer.
        /// </summary>
        public SmbReadAndxResponsePacket(byte[] data)
            : base(data)
        {
        }


        /// <summary>
        /// Deep copy constructor.
        /// </summary>
        public SmbReadAndxResponsePacket(SmbReadAndxResponsePacket packet)
            : base(packet)
        {
            this.InitDefaultValue();

            this.smbParameters.WordCount = packet.SmbParameters.WordCount;
            this.smbParameters.AndXCommand = packet.SmbParameters.AndXCommand;
            this.smbParameters.AndXReserved = packet.SmbParameters.AndXReserved;
            this.smbParameters.AndXOffset = packet.SmbParameters.AndXOffset;
            this.smbParameters.Available = packet.SmbParameters.Available;
            this.smbParameters.DataCompactionMode = packet.SmbParameters.DataCompactionMode;
            this.smbParameters.Reserved1 = packet.SmbParameters.Reserved1;
            this.smbParameters.DataLength = packet.SmbParameters.DataLength;
            this.smbParameters.DataOffset = packet.SmbParameters.DataOffset;

            if (packet.smbParameters.Reserved2 != null)
            {
                this.smbParameters.Reserved2 = new ushort[packet.smbParameters.Reserved2.Length];
                Array.Copy(packet.smbParameters.Reserved2,
                    this.smbParameters.Reserved2, packet.smbParameters.Reserved2.Length);
            }
            else
            {
                this.smbParameters.Reserved2 = new ushort[0];
            }
            this.smbData.ByteCount = packet.SmbData.ByteCount;

            if (packet.smbData.Pad != null)
            {
                this.smbData.Pad = new byte[packet.smbData.Pad.Length];
                Array.Copy(packet.smbData.Pad, this.smbData.Pad, packet.smbData.Pad.Length);
            }
            else
            {
                this.smbData.Pad = new byte[0];
            }

            if (packet.smbData.Data != null)
            {
                this.smbData.Data = new byte[packet.smbData.Data.Length];
                Array.Copy(packet.smbData.Data, this.smbData.Data, packet.smbData.Data.Length);
            }
            else
            {
                this.smbData.Data = new byte[0];
            }
        }

        #endregion


        #region override methods

        /// <summary>
        /// to create an instance of the StackPacket class that is identical to the current StackPacket. 
        /// </summary>
        /// <returns>a new Packet cloned from this.</returns>
        public override StackPacket Clone()
        {
            return new SmbReadAndxResponsePacket(this);
        }


        /// <summary>
        /// Encode the struct of SMB_COM_READ_ANDX_Response_SMB_Parameters into the struct of SmbParameters
        /// </summary>
        protected override void EncodeParameters()
        {
            this.smbParametersBlock = TypeMarshal.ToStruct<SmbParameters>(
                CifsMessageUtils.ToBytes<SMB_COM_READ_ANDX_Response_SMB_Parameters>(this.smbParameters));
        }


        /// <summary>
        /// Encode the struct of SMB_COM_READ_ANDX_Response_SMB_Data into the struct of SmbData
        /// </summary>
        protected override void EncodeData()
        {
            this.smbDataBlock.ByteCount = this.SmbData.ByteCount;
            this.smbDataBlock.Bytes = new byte[this.smbDataBlock.ByteCount];
            using (MemoryStream memoryStream = new MemoryStream(this.smbDataBlock.Bytes))
            {
                using (Channel channel = new Channel(null, memoryStream))
                {
                    channel.BeginWriteGroup();
                    if (this.smbData.Pad != null)
                    {
                        channel.WriteBytes(this.smbData.Pad);
                    }
                    if (this.smbData.Data != null)
                    {
                        channel.WriteBytes(this.smbData.Data);
                    }
                    channel.EndWriteGroup();
                }
            }
        }


        /// <summary>
        /// to decode the smb parameters: from the general SmbParameters to the concrete Smb Parameters.
        /// </summary>
        protected override void DecodeParameters()
        {
            if (this.smbParametersBlock.WordCount > 0)
            {
                this.smbParameters = TypeMarshal.ToStruct<SMB_COM_READ_ANDX_Response_SMB_Parameters>(
                     TypeMarshal.ToBytes(this.smbParametersBlock));
            }
        }


        /// <summary>
        /// to decode the smb data: from the general SmbDada to the concrete Smb Data.
        /// </summary>
        protected override void DecodeData()
        {
            this.smbData.ByteCount = this.smbDataBlock.ByteCount;
            using (MemoryStream memoryStream = new MemoryStream(this.smbDataBlock.Bytes))
            {
                using (Channel channel = new Channel(null, memoryStream))
                {
                    this.smbData.Pad = channel.ReadBytes(this.smbData.ByteCount - this.smbParameters.DataLength);
                    this.smbData.Data = channel.ReadBytes(this.smbParameters.DataLength);
                }
            }
        }

        #endregion


        #region initialize fields with default value

        /// <summary>
        /// init packet, set default field data
        /// </summary>
        private void InitDefaultValue()
        {
            this.smbParameters.AndXCommand = SmbCommand.SMB_COM_NO_ANDX_COMMAND;
            this.smbData.Pad = new byte[0];
            this.smbData.Data = new byte[0];
        }

        #endregion
    }
}
