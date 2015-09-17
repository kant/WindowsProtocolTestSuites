// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
namespace Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Fscc
{
    /// <summary>
    /// the response packet of FileMailslotSetInformation 
    /// </summary>
    public class FsccFileMailslotSetInformationResponsePacket : FsccEmptyPacket
    {
        #region Properties

        /// <summary>
        /// the command of fscc packet 
        /// </summary>
        public override uint Command
        {
            get
            {
                return (uint)FileInformationCommand.FileMailslotSetInformation;
            }
        }


        #endregion

        #region Constructors

        /// <summary>
        /// default constructor 
        /// </summary>
        public FsccFileMailslotSetInformationResponsePacket()
            : base()
        {
        }


        #endregion
    }
}
