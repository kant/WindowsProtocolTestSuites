// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Fscc
{
    /// <summary>
    /// the response packet of FSCTL_QUERY_ALLOCATED_RANGES 
    /// </summary>
    public class FsccFsctlQueryAllocatedRangesResponsePacket : FsccStandardPacket<FSCTL_QUERY_ALLOCATED_RANGES_Reply>
    {
        #region Properties

        /// <summary>
        /// the command of fscc packet 
        /// </summary>
        public override uint Command
        {
            get
            {
                return (uint)FsControlCommand.FSCTL_QUERY_ALLOCATED_RANGES;
            }
        }


        #endregion

        #region Constructors

        /// <summary>
        /// default constructor 
        /// </summary>
        public FsccFsctlQueryAllocatedRangesResponsePacket()
            : base()
        {
        }


        #endregion
    }
}
