// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Fscc
{
    /// <summary>
    /// the response packet of FileSfioVolumeInformation 
    /// </summary>
    public class FsccFileSfioVolumeInformationResponsePacket : FsccEmptyPacket
    {
        #region Properties

        /// <summary>
        /// the command of fscc packet 
        /// </summary>
        public override uint Command
        {
            get
            {
                return (uint)FileInformationCommand.FileSfioVolumeInformation;
            }
        }


        #endregion

        #region Constructors

        /// <summary>
        /// default constructor 
        /// </summary>
        public FsccFileSfioVolumeInformationResponsePacket()
            : base()
        {
            throw new NotImplementedException("Windows file systems do not implement this file information class");
        }


        #endregion
    }
}
