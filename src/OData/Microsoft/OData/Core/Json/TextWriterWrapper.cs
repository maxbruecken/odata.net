//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation. All rights reserved.  
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

#if SPATIAL
namespace Microsoft.Data.Spatial
#else
namespace Microsoft.OData.Core.Json
#endif
{
    #region Namespaces
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    #endregion Namespaces

    /// <summary>
    /// Writes text non indented
    /// </summary>
    internal abstract class TextWriterWrapper : TextWriter
    {
        /// <summary>
        /// The underlying writer to write to.
        /// </summary>
        protected TextWriter writer;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="formatProvider">An System.IFormatProvider object that controls formatting.</param>
        protected TextWriterWrapper(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        /// <summary>
        /// Returns the Encoding for the given writer.
        /// </summary>
        public override Encoding Encoding
        {
            get
            {
                return this.writer.Encoding;
            }
        }

        /// <summary>
        /// Returns the new line character.
        /// </summary>
        public override string NewLine
        {
            get
            {
                return this.writer.NewLine;
            }
        }

        /// <summary>
        /// Increases the level of indentation applied to the output.
        /// </summary>
        public virtual void IncreaseIndentation()
        {
        }

        /// <summary>
        /// Decreases the level of indentation applied to the output.
        /// </summary>
        public virtual void DecreaseIndentation()
        {
        }

        /// <summary>
        /// Clears the buffer of the current writer.
        /// </summary>
        public override void Flush()
        {
            this.writer.Flush();
        }

        /// <summary>
        /// Closes or disposes the underlying writer.
        /// </summary>
        protected static void InternalCloseOrDispose()
        {
            Debug.Assert(false, "Should never call Close or Dispose on the TextWriter.");

            // This is done to make sure we don't accidently close or dispose the underlying stream.
            // Since we don't own the stream, we should never close or dispose it.
            throw new NotImplementedException();
        }
    }
}

